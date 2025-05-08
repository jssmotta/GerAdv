using MenphisSI.GerEntityTools.Entity;
using DBAdvogados = MenphisSI.GerAdv.DBAdvogados;
using DBFuncionarios = MenphisSI.GerAdv.DBFuncionarios;
using DBOperador = MenphisSI.GerAdv.DBOperador;

namespace Domain.BaseCommon.Helpers;
public class EnvioNotificacoesAniversariantes
{
    private string ConteudoHtml(string operador, int advogado, string uri, SqlConnection oCnn)
    {
        var ds = ObterAniversariantes(oCnn, uri, operador, advogado);
        if (ds.Rows.Count == 0)
        {
            return "";
        }
        return CriarTabelaDaAgendaHtml(ds, operador, ds.Rows.Count);
    }

    private string ConteudoHtmlFuncionarios(string operador, int advogado, string uri, SqlConnection oCnn)
    {
        var ds = ObterAniversariantesFuncionarios(oCnn, uri, operador, advogado);
        if (ds.Rows.Count == 0)
        {
            return "";
        }
        return CriarTabelaDaAgendaHtml(ds, operador, ds.Rows.Count);
    }

    private void TestaViews(string uri)
    {

        string createViewScript1 = $@"
            IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'dbo.NotificarAniversariantes'))
BEGIN
    EXEC('CREATE VIEW [dbo].[NotificarAniversariantes] AS 
            SELECT DISTINCT
                c.cliCodigo,
                c.cliNome,
                DAY(c.cliDtNasc) as dia,
	            MONTH(c.cliDtNasc) as mes,
                a.advCodigo,
                a.advNome
            FROM
                dbo.Clientes c
            LEFT JOIN
                dbo.Processos p ON c.cliCodigo = p.proCliente
            LEFT JOIN
                dbo.Historico h ON p.proCodigo = h.hisProcesso
            LEFT JOIN
                dbo.Agenda ag ON c.cliCodigo = ag.ageCliente
            LEFT JOIN
                dbo.Advogados a ON a.advCodigo = p.proAdvogado OR a.advCodigo = ag.ageAdvogado
            left join
	            dbo.Operador o ON o.operCadCod = a.advCodigo AND o.operCadID=1
            WHERE
	            o.operSituacao=1 AND
                c.cliInativo=0 AND
                MONTH(c.cliDtNasc) = MONTH(GETDATE()) AND
                DAY(c.cliDtNasc) BETWEEN DAY(GETDATE()) AND DAY(DATEADD(DAY, 7, GETDATE()));	            
            ');
END;

                    ;";


        using var conexao = Configuracoes.GetConnectionByUriRw(uri);
        ConfiguracoesDBT.ExecuteSqlCreate(createViewScript1, conexao);        
    }

    private DataTable ObterAniversariantes(
        SqlConnection conexao,        
        string uri,
        string operador,
        int advogado,
        int nTry = 0)
    {
        try
        {
            string whereClause = ConstruirCondicaoFiltro(advogado);
            string operadorSanitizado = operador.Replace("'", "''");

            string sql = $@"
    SELECT distinct cliNome, mes, dia 
    FROM dbo.NotificarAniversariantes
    WHERE {whereClause}   
    ORDER BY mes, dia, cliNome;
";

            return ConfiguracoesDBT.GetDataTable2(sql, conexao)!;
        }
        catch (Exception)
        {
            if (++nTry > 3)
            {
                throw;
            }

            TestaViews(uri);
            return ObterAniversariantes(conexao, uri, operador, advogado, nTry);
        }
    }
    
    private string ConstruirCondicaoFiltro(int advogado)
    {
        return $"advCodigo={advogado}";
    }

    private string CriarTabelaDaAgendaHtml(DataTable compromissos, string nome, int total)
    {
        var estiloTabela = ObterEstiloTabelaCss();
        var builder = new StringBuilder(estiloTabela);

        // Adiciona o cabeçalho da tabela
        builder.AppendLine("<table class='tabAniversariantes'><thead>");
        builder.AppendLine("<tr>");
        builder.AppendLine($"<th width=\"4%\">#</th>");
        builder.AppendLine($"<th width=\"78%\">Aniversariante{(total == 1 ? "" : "s")} nos próximos 7 dias</h1></th>");
        builder.AppendLine("<th width=\"18%\">Dia/Mês </th>");
        builder.AppendLine("</tr>");
        builder.AppendLine("</thead>");

        // Adiciona os dados da tabela
        int contador = 0;
        foreach (DataRow linha in compromissos.Rows)
        {
            contador++;

            builder.AppendLine("<tr>");
            builder.AppendLine($"<td>{contador}</td>");
            builder.AppendLine($"<td>{linha[0]}</td>");
            builder.AppendLine($"<td>{linha[2]:D2}/{linha[1]:D2}</td>");
            builder.AppendLine("</tr>");
        }

        builder.AppendLine("</table>");
        builder.AppendLine($"<span><b>{nome.Split(' ')[0]}, você está recebendo aviso de aniversariantes somente de clientes ativos que você tem algum processo ou compromisso em nome deles.</b></span>");
        return builder.ToString();
    }

    
    public int EnviarEmailsParaAdvogados(string uri, SqlConnection oCnn)
    {
        string filtroOperadores = DBOperadorDicInfo.SituacaoSqlSim + TSql.And + DBOperadorDicInfo.CadIDSql(1);
        var operadores = DBOperador.Listar("", filtroOperadores, "operNome", Configuracoes.ConnectionString(uri));
        var servicoEmail = new SendEmailApi();
        var assunto = "Aniversariantes próximos 7 dias";
        var count = 0;

        foreach (var operador in operadores)
        {
            if (string.IsNullOrEmpty(operador.FEMailNet) || string.IsNullOrEmpty(operador.FNome))
            {
                continue;
            }

            var cNome = operador.FCadID == 1 ? DBAdvogados.ListarN(operador.FCadCod, oCnn).FNome
                                             : DBFuncionarios.ListarN(operador.FCadCod, oCnn).FNome;
            if (cNome == null || cNome.Equals("")) continue;

            var conteudoHtml = ConteudoHtml(cNome, operador.FCadID, uri, oCnn);

            if (string.IsNullOrEmpty(conteudoHtml))
            {
                continue;
            }

#if (!DEBUG)

            var email = new MenphisSI.Api.Models.SendEmail
            {
                ParaEmail = operador.FEMailNet,
                ParaNome = cNome,
                Assunto = assunto + " - " + cNome,
                Mensagem = conteudoHtml,
                NomeDoMail = "ADVOCATI.NET - MENPHIS - SISTEMAS INTELIGENTES",
                Time2Live = 24
            };


            _ = servicoEmail.Send(email);
#endif
            if (count == 0)
            {
#if (!DEBUG)
                if (uri.ToUpper().Equals("IBRADV"))
#endif
                {
                    var email2 = new MenphisSI.Api.Models.SendEmail
                    {
                        ParaEmail = "motta@menphis.com.br",
                        ParaNome = "Jefferson S. Motta",
                        Assunto = assunto + " - " + cNome,
                        Mensagem = conteudoHtml,
                        NomeDoMail = "NIVER - " + uri.ToUpper() + " - ADVOCATI.NET - MENPHIS - SISTEMAS INTELIGENTES",
                        Time2Live = 24
                    };
                    _ = servicoEmail.Send(email2);
                }

            }

            count++;

        #if (DEBUG)
            break;
            #endif
        }

        return count;
    }

    private string ObterEstiloTabelaCss()
    {
        return @"<style>
       .tabAniversariantes {
    width: 100%;
    border-collapse: collapse;
    font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;
    font-size: 14px;
    color: #333;
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}

.tabAniversariantes thead {
    background-color: #f8f9fa;
    position: sticky;
    top: 0;
    z-index: 10;
}

.tabAniversariantes th {
    padding: 12px 8px;
    text-align: left;
    border: 1px solid #ddd;
    font-weight: 600;
    color: #222;
}

.tabAniversariantes td {
    padding: 10px 8px;
    border: 1px solid #ddd;
    vertical-align: top;
}

.tabAniversariantes tr:nth-child(even) {
    background-color: #f8f9fa;
}

.tabAniversariantes tr:hover {
    background-color: #f1f3f5;
}

@media only screen and (max-width: 767px) {
    .tabAniversariantes {
        font-size: 13px;
    }
    
    .tabAniversariantes th, 
    .tabAniversariantes td {
        font-size: 13px;
        padding: 8px 6px;
    }    
    
    .tabAniversariantes td table {
        width: 100%;
    }
    
    .tabAniversariantes td table td {
        padding: 6px 4px;
        word-break: break-word;
    }    
    
    .tabAniversariantes td a {
        word-break: break-word;
    }    
    
    @media only screen and (max-width: 375px) {
        .tabAniversariantes {
            font-size: 12px;
        }
        
        .tabAniversariantes th, 
        .tabAniversariantes td {
            font-size: 12px;
            padding: 6px 4px;
        }
        
        .tabAniversariantes td table td {
            padding: 5px 3px;
        }
    }
}


.tabAniversariantes tr td:first-child {
    font-weight: 600;
    background-color: #f8f9fa;
}

.tabAniversariantes td table {
    border-collapse: collapse;
    width: 100%;
}

.tabAniversariantes td table tr:hover {
    background-color: transparent;
}

.tabAniversariantes td table td:first-child {
    font-weight: normal;
}

.tabAniversariantes a {
    color: #0066cc;
    text-decoration: none;
}

.tabAniversariantes a:hover {
    text-decoration: underline;
}

.tabAniversariantes span[style*=""color:red""] {
    color: #ff3b30 !important;
    font-weight: bold;
}

.tabAniversariantes img {
    vertical-align: middle;
    margin-right: 4px;
}

   </style> ";
    }

    public int EnviarEmailsParaFuncionarios(string uri, SqlConnection oCnn)
    {
        string filtroOperadores = DBOperadorDicInfo.SituacaoSqlSim + TSql.And + DBOperadorDicInfo.MasterSqlSim + TSql.And + DBOperadorDicInfo.CadIDSql(2);
        var operadores = DBOperador.Listar("", filtroOperadores, "operNome", Configuracoes.ConnectionString(uri));
        var servicoEmail = new SendEmailApi();
        var assunto = "Aniversariantes próximos 7 dias";
        var count = 0;

        foreach (var operador in operadores)
        {
            if (string.IsNullOrEmpty(operador.FEMailNet) || string.IsNullOrEmpty(operador.FNome))
            {
                continue;
            }

            var cNome = operador.FCadID == 1 ? DBAdvogados.ListarN(operador.FCadCod, oCnn).FNome
                                             : DBFuncionarios.ListarN(operador.FCadCod, oCnn).FNome;
            if (cNome == null || cNome.Equals("")) continue;

            var conteudoHtml = ConteudoHtmlFuncionarios(cNome, operador.FCadID, uri, oCnn);

            if (string.IsNullOrEmpty(conteudoHtml))
            {
                continue;
            }

#if (!DEBUG)

            var email = new MenphisSI.Api.Models.SendEmail
            {
                ParaEmail = operador.FEMailNet,
                ParaNome = cNome,
                Assunto = assunto + " - " + cNome,
                Mensagem = conteudoHtml,
                NomeDoMail = "ADVOCATI.NET - MENPHIS - SISTEMAS INTELIGENTES",
                Time2Live = 24
            };

            _ = servicoEmail.Send(email);
#endif 
            count++;
 
        }

        return count;
    }

    private DataTable ObterAniversariantesFuncionarios(
    SqlConnection conexao,
    string uri,
    string operador,
    int advogado,
    int nTry = 0)
    {
        try
        {
            
            string operadorSanitizado = operador.Replace("'", "''");

            string sql = $@"
    SELECT distinct cliNome, mes, dia 
    FROM dbo.NotificarAniversariantesFuncionarios    
    ORDER BY mes, dia, cliNome;
";

            return ConfiguracoesDBT.GetDataTable2(sql, conexao)!;
        }
        catch (Exception)
        {
            if (++nTry > 3)
            {
                throw;
            }

            TestaViewsFuncionarios(uri);
            return ObterAniversariantesFuncionarios(conexao, uri, operador, advogado, nTry);
        }
    }

    private void TestaViewsFuncionarios(string uri)
    {

        string createViewScript1 = $@"
            IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'dbo.NotificarAniversariantesFuncionarios'))
BEGIN
    EXEC('CREATE VIEW [dbo].[NotificarAniversariantesFuncionarios] AS 
            SELECT DISTINCT
                c.cliCodigo,
                c.cliNome,
                DAY(c.cliDtNasc) as dia,
	            MONTH(c.cliDtNasc) as mes                                
            FROM
                dbo.Clientes c
            
            WHERE	            
                c.cliInativo=0 AND
                MONTH(c.cliDtNasc) = MONTH(GETDATE()) AND
                DAY(c.cliDtNasc) BETWEEN DAY(GETDATE()) AND DAY(DATEADD(DAY, 7, GETDATE()));	            
            ');
END;

                    ;";


        using var conexao = Configuracoes.GetConnectionByUriRw(uri);
        ConfiguracoesDBT.ExecuteSqlCreate(createViewScript1, conexao);
    }

}