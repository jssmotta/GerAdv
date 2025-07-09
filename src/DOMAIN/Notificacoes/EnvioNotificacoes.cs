using MenphisSI.GerEntityTools.Entity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using DBAdvogados = MenphisSI.GerAdv.DBAdvogados;
using DBFuncionarios = MenphisSI.GerAdv.DBFuncionarios;
using DBOperador = MenphisSI.GerAdv.DBOperador;

namespace Domain.BaseCommon.Helpers;

public enum E_TIPO_ENVIO
{
    NOVOS = 1,
    DIA = 2
}

public class EnvioNotificacoes
{
    private string ConteudoHtml(string operador, E_TIPO_ENVIO tipo, string uri, MsiSqlConnection oCnn)
    {
        var ds = ObterCompromissos(oCnn, tipo, uri, operador);
        if (ds.Rows.Count == 0)
        {
            return "";
        }
        return CriarTabelaDaAgendaHtml(ds, operador, ds.Rows.Count);
    }

    private void TestaViews(string uri)
    {

        string createViewScript1 = $@"
            IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'dbo.AgendaRelatorio'))
BEGIN
    EXEC('CREATE VIEW [dbo].[AgendaRelatorio] AS 
        SELECT 
            qa.*, 
            vp.advNome AS xxxNomeAdvogado,
            vp.forNome AS xxxNomeForo,
            vp.jusNome AS xxxNomeJustica,
            vp.areDescricao AS xxxNomeArea
        FROM [dbo].[view_QAgenda] qa
        JOIN [dbo].[agenda] a ON a.ageCodigo = qa.vqaCodigo
        LEFT JOIN [dbo].[view_QProcessos] vp ON a.ageIDInsProcesso = vp.insCodigo;');
END;

                    ;";

        string createViewScript2 = @"
               IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'dbo.AgendaSemana'))
BEGIN
    EXEC('CREATE VIEW [dbo].[AgendaSemana] 
    WITH SCHEMABINDING AS
    SELECT
        CASE WHEN f.funNome IS NULL THEN adv.advNome ELSE f.funNome END AS xxxParaNome,
        a.ageCodigo AS xxxCodigo,
        a.ageData AS xxxData, 
        a.ageFuncionario AS xxxFuncionario, 
        a.ageAdvogado AS xxxAdvogado,
        a.ageHora AS xxxHora, 
        a.ageTipoCompromisso AS xxxTipoCompromisso, 
        a.ageCompromisso AS xxxCompromisso, 
        a.ageConcluido AS xxxConcluido, 
        a.ageLiberado AS xxxLiberado,   
        a.ageImportante AS xxxImportante, 
        a.ageHrFinal AS xxxHoraFinal, 
        c.cliNome AS xxxNomeCliente, 
        t.tipDescricao AS xxxTipo
    FROM dbo.Agenda a
    LEFT JOIN dbo.Funcionarios f ON f.funCodigo = a.ageFuncionario
    LEFT JOIN dbo.Advogados adv ON adv.advCodigo = a.ageAdvogado
    LEFT JOIN dbo.Clientes c ON c.cliCodigo = a.ageCliente
    JOIN dbo.TipoCompromisso t ON t.tipCodigo = a.ageTipoCompromisso;');
END;


";
        using var conexao = Configuracoes.GetConnectionByUriRw(uri);
        ConfiguracoesDBT.ExecuteSqlCreate(createViewScript1, conexao);
        ConfiguracoesDBT.ExecuteSqlCreate(createViewScript2, conexao);
    }

    private DataTable ObterCompromissos(
        MsiSqlConnection conexao,
        E_TIPO_ENVIO tipo,
        string uri,
        string operador,
        int nTry = 0)
    {
        try
        {
            string whereClause = ConstruirCondicaoFiltro(tipo);
            string operadorSanitizado = operador.Replace("'", "''");

            string sql = $@"
SELECT [vqaData], [xxxBoxAudienciaMobile] 
FROM [dbo].[AgendaRelatorio]
LEFT JOIN [dbo].[Agenda] a ON vqaCodigo = a.ageCodigo
WHERE a.ageConcluido = 0 
     {whereClause}
     AND xxxParaNome LIKE '{operadorSanitizado}'
ORDER BY vqaData;";

            return ConfiguracoesDBT.GetDataTable2(sql, conexao)!;
        }
        catch (Exception)
        {
            if (++nTry > 3)
            {
                throw;
            }

            TestaViews(uri);
            return ObterCompromissos(conexao, tipo, uri, operador, nTry);
        }
    }
    
    private string ConstruirCondicaoFiltro(E_TIPO_ENVIO tipo)
    {
        if (tipo == E_TIPO_ENVIO.NOVOS)
        {
            return @"  AND (CAST(a.ageDtCad AS DATE) = CAST(GETDATE() AS DATE) 
                    OR CAST(a.ageDtAtu AS DATE) = CAST(GETDATE() AS DATE))";
        }

        int diasAFrente = (DateTime.Now.DayOfWeek == DayOfWeek.Monday) ? 8 : 5;

        return $@" AND vqaData >= DATEADD(DAY, -1, GETDATE()) 
                AND vqaData <= DATEADD(DAY, {diasAFrente}, GETDATE())";
    }

    private string CriarTabelaDaAgendaHtml(DataTable compromissos, string nome, int total)
    {
        var estiloTabela = ObterEstiloTabelaCss();
        var builder = new StringBuilder(estiloTabela);

        // Adiciona o cabeçalho da tabela
        builder.AppendLine("<table class='tabCompromissos'><thead>");
        builder.AppendLine("<tr>");
        builder.AppendLine($"<th width=\"100%\"><h1>{total} compromisso{(total == 1 ? "" : "s")} para {nome}</h1></th>");

        builder.AppendLine("</tr>");
        builder.AppendLine("</thead>");

        // Adiciona os dados da tabela
        int contador = 0;
        foreach (DataRow linha in compromissos.Rows)
        {
            contador++;

            builder.AppendLine("<tr>");
            builder.AppendLine($"<td>#{contador}){(DateTime)linha[0]:dd/MM/yyyy}</td>");
            builder.AppendLine("</tr>");

            builder.AppendLine("<tr>");
            builder.AppendLine($"<td>{linha[1]}</td>");
            builder.AppendLine("</tr>");
        }

        builder.AppendLine("</table>");
        var result = builder.ToString().Replace("INFORMAR RESULTADO", "").Replace("<tr><td colspan=\"\"3\"\"", "<tr style=\"display:none;\"><td colspan=\"0\"").Replace("\"\"", "\"");
        return result.Replace("MobileAndamentoRetorno.aspx?ageId=", "");
    }

    
    public int EnviarEmailsParaAdvogados(E_TIPO_ENVIO tipo, string uri, MsiSqlConnection oCnn)
    {
        string filtroOperadores = DBOperadorDicInfo.SituacaoSqlSim;        

        var reader = new MenphisSI.GerAdv.Readers.Operador();
        var readerAdv = new MenphisSI.GerAdv.Readers.Advogados();
        var readerFunc = new MenphisSI.GerAdv.Readers.Funcionarios();
        var operadores = reader.Listar(100, uri, filtroOperadores, [], "operNome");
        var servicoEmail = new SendEmailApi();
        var assunto = tipo == E_TIPO_ENVIO.NOVOS ? "Novos compromissos e atualizados do dia de hoje" : "Compromissos da Agenda do Advocati.NET para ";
        var count = 0;

        foreach (var operador in operadores)
        {
            if (string.IsNullOrEmpty(operador.EMailNet) || string.IsNullOrEmpty(operador.Nome))
            {
                continue;
            }

            var cNome = operador.CadID == 1 ?
                      readerAdv.ListarN(1, uri, DBAdvogadosDicInfo.CampoCodigo + "=" + operador.CadCod, [], DBAdvogadosDicInfo.Nome).ToList()?.FirstOrDefault()?.Nome() ?? ""
                    : readerFunc.ListarN(1, uri, DBFuncionariosDicInfo.CampoCodigo + "=" + operador.CadCod, [], DBFuncionariosDicInfo.Nome).ToList()?.FirstOrDefault()?.Nome() ?? "";

            if (cNome == null || cNome.Equals("")) continue;

            var conteudoHtml = ConteudoHtml(cNome, tipo, uri, oCnn);

            if (string.IsNullOrEmpty(conteudoHtml))
            {
                continue;
            }

            var email = new MenphisSI.Api.Models.SendEmail
            {
                ParaEmail = operador.EMailNet,
                ParaNome = cNome,
                Assunto = assunto + cNome,
                Mensagem = conteudoHtml,
                NomeDoMail = "ADVOCATI.NET - MENPHIS - SISTEMAS INTELIGENTES",
                Time2Live = 24
            };

#if (!DEBUG)
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
                        Assunto = assunto + cNome,
                        Mensagem = conteudoHtml,
                        NomeDoMail = uri.ToUpper() + " - ADVOCATI.NET - MENPHIS - SISTEMAS INTELIGENTES",
                        Time2Live = 24
                    };
                    _ = servicoEmail.Send(email2);
                }

            }

            count++;
        }

        return count;
    }

    private string ObterEstiloTabelaCss()
    {
        return @"<style>
       .tabCompromissos {
    width: 100%;
    border-collapse: collapse;
    font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;
    font-size: 14px;
    color: #333;
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}

.tabCompromissos thead {
    background-color: #f8f9fa;
    position: sticky;
    top: 0;
    z-index: 10;
}

.tabCompromissos th {
    padding: 12px 8px;
    text-align: left;
    border: 1px solid #ddd;
    font-weight: 600;
    color: #222;
}

.tabCompromissos td {
    padding: 10px 8px;
    border: 1px solid #ddd;
    vertical-align: top;
}

.tabCompromissos tr:nth-child(even) {
    background-color: #f8f9fa;
}

.tabCompromissos tr:hover {
    background-color: #f1f3f5;
}

/* Better Responsiveness for iPhone */
@media only screen and (max-width: 767px) {
    .tabCompromissos {
        font-size: 13px;
    }
    
    .tabCompromissos th, 
    .tabCompromissos td {
        font-size: 13px;
        padding: 8px 6px;
    }
    
    /* Inner table styles */
    .tabCompromissos td table {
        width: 100%;
    }
    
    .tabCompromissos td table td {
        padding: 6px 4px;
        word-break: break-word;
    }
    
    /* Ensure text doesn't overflow on small screens */
    .tabCompromissos td a {
        word-break: break-word;
    }
    
    /* Optimize font size for very small screens */
    @media only screen and (max-width: 375px) {
        .tabCompromissos {
            font-size: 12px;
        }
        
        .tabCompromissos th, 
        .tabCompromissos td {
            font-size: 12px;
            padding: 6px 4px;
        }
        
        .tabCompromissos td table td {
            padding: 5px 3px;
        }
    }
}

/* Add some visual enhancements */
.tabCompromissos tr td:first-child {
    font-weight: 600;
    background-color: #f8f9fa;
}

/* Better inner table styling */
.tabCompromissos td table {
    border-collapse: collapse;
    width: 100%;
}

.tabCompromissos td table tr:hover {
    background-color: transparent;
}

/* Style for the client name in inner tables */
.tabCompromissos td table td:first-child {
    font-weight: normal;
}

/* Better styling for links */
.tabCompromissos a {
    color: #0066cc;
    text-decoration: none;
}

.tabCompromissos a:hover {
    text-decoration: underline;
}

/* Style for color red spans */
.tabCompromissos span[style*=""color:red""] {
    color: #ff3b30 !important;
    font-weight: bold;
}

/* Better icon spacing */
.tabCompromissos img {
    vertical-align: middle;
    margin-right: 4px;
}

/* Fix for Safari on iOS */
@supports (-webkit-touch-callout: none) {
    .tabCompromissos {
        -webkit-text-size-adjust: 100%;
    }
}

/* Hide header elements */
.tabCompromissos td a[href*=""MobileAndamentoRetorno.aspx""] span,
.tabCompromissos td table tr:first-child td[colspan=""3""],
.tabCompromissos td table tr:nth-child(2) td[colspan=""3""] {
    display: none;
}

/* Additionally hide the ""INFORMAR RESULTADO"" text */
a[href*=""MobileAndamentoRetorno.aspx""] {
    display: none;
}
   </style> ";
    }

}
