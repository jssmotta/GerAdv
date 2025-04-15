using MenphisSI.GerEntityTools.Entity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using DBAdvogados = MenphisSI.GerAdv.DBAdvogados;
using DBFuncionarios = MenphisSI.GerAdv.DBFuncionarios;
using DBOperador = MenphisSI.GerAdv.DBOperador;

namespace Domain.BaseCommon.Helpers;

public class EnvioNotificacoes
{
    private string ConteudoHtml(string operador, string uri, SqlConnection oCnn)
    {
        var ds = ObterCompromissos(oCnn, uri, operador);
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

    private DataTable ObterCompromissos(SqlConnection conexao, string uri, string operador)
    {
        var nTry = 0;

        try
        {
            string sql = $@"
SELECT TOP (100) [vqaData], [xxxBoxAudienciaMobile] 
  FROM [dbo].[AgendaRelatorio]

  LEFT JOIN [dbo].[Agenda] a on vqaCodigo = a.ageCodigo

  WHERE ageConcluido = 0 
        AND vqaData >= DATEADD(DAY, -1, GETDATE()) and vqaData <=DATEADD(DAY, 8, GETDATE())   
        AND xxxParaNome like '{operador.Replace("'", "''")}'
  
  ORDER BY vqaData;

";

            var result = ConfiguracoesDBT.GetDataTable2(sql, conexao)!;

            return result;
        }
        catch (Exception ex)
        {
            nTry++;
            if (nTry > 3)
            {
                throw;
            }
            TestaViews(uri);
            return ObterCompromissos(conexao, uri, operador);
        }
    }

    private string CriarTabelaDaAgendaHtml(DataTable compromissos, string nome, int total)
    {
        var estiloTabela = ObterEstiloTabelaCss();
        var builder = new StringBuilder(estiloTabela);

        // Adiciona o cabeçalho da tabela
        builder.AppendLine("<table class='tabComrpomissos'><thead>");
        builder.AppendLine("<tr>");
        builder.AppendLine($"<th width=\"100%\"><h1>{total} compromisso{(total==1?"":"s")} para {nome}</h1></th>");

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
        return builder.ToString().Replace("INFORMAR RESULTADO", "").Replace("<tr><td colspan=\"\"3\"\"", "<tr style=\"display:none;\"><td colspan=\"0\"").Replace("\"\"","\"");
    }

    private string ObterEstiloTabelaCss()
    {
        return @"<style>
       .tabComrpomissos {
    width: 100%;
    border-collapse: collapse;
    font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, Helvetica, Arial, sans-serif;
    font-size: 14px;
    color: #333;
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}

.tabComrpomissos thead {
    background-color: #f8f9fa;
    position: sticky;
    top: 0;
    z-index: 10;
}

.tabComrpomissos th {
    padding: 12px 8px;
    text-align: left;
    border: 1px solid #ddd;
    font-weight: 600;
    color: #222;
}

.tabComrpomissos td {
    padding: 10px 8px;
    border: 1px solid #ddd;
    vertical-align: top;
}

.tabComrpomissos tr:nth-child(even) {
    background-color: #f8f9fa;
}

.tabComrpomissos tr:hover {
    background-color: #f1f3f5;
}

/* Better Responsiveness for iPhone */
@media only screen and (max-width: 767px) {
    .tabComrpomissos {
        font-size: 13px;
    }
    
    .tabComrpomissos th, 
    .tabComrpomissos td {
        font-size: 13px;
        padding: 8px 6px;
    }
    
    /* Inner table styles */
    .tabComrpomissos td table {
        width: 100%;
    }
    
    .tabComrpomissos td table td {
        padding: 6px 4px;
        word-break: break-word;
    }
    
    /* Ensure text doesn't overflow on small screens */
    .tabComrpomissos td a {
        word-break: break-word;
    }
    
    /* Optimize font size for very small screens */
    @media only screen and (max-width: 375px) {
        .tabComrpomissos {
            font-size: 12px;
        }
        
        .tabComrpomissos th, 
        .tabComrpomissos td {
            font-size: 12px;
            padding: 6px 4px;
        }
        
        .tabComrpomissos td table td {
            padding: 5px 3px;
        }
    }
}

/* Add some visual enhancements */
.tabComrpomissos tr td:first-child {
    font-weight: 600;
    background-color: #f8f9fa;
}

/* Better inner table styling */
.tabComrpomissos td table {
    border-collapse: collapse;
    width: 100%;
}

.tabComrpomissos td table tr:hover {
    background-color: transparent;
}

/* Style for the client name in inner tables */
.tabComrpomissos td table td:first-child {
    font-weight: normal;
}

/* Better styling for links */
.tabComrpomissos a {
    color: #0066cc;
    text-decoration: none;
}

.tabComrpomissos a:hover {
    text-decoration: underline;
}

/* Style for color red spans */
.tabComrpomissos span[style*=""color:red""] {
    color: #ff3b30 !important;
    font-weight: bold;
}

/* Better icon spacing */
.tabComrpomissos img {
    vertical-align: middle;
    margin-right: 4px;
}

/* Fix for Safari on iOS */
@supports (-webkit-touch-callout: none) {
    .tabComrpomissos {
        -webkit-text-size-adjust: 100%;
    }
}

/* Hide header elements */
.tabComrpomissos td a[href*=""MobileAndamentoRetorno.aspx""] span,
.tabComrpomissos td table tr:first-child td[colspan=""3""],
.tabComrpomissos td table tr:nth-child(2) td[colspan=""3""] {
    display: none;
}

/* Additionally hide the ""INFORMAR RESULTADO"" text */
a[href*=""MobileAndamentoRetorno.aspx""] {
    display: none;
}
   </style> ";
    }

    public int EnviarEmailsParaOperadores(string uri, SqlConnection oCnn)
    {
        

        string filtroOperadores = DBOperadorDicInfo.SituacaoSqlSim;
        var operadores = DBOperador.Listar("", filtroOperadores, "operNome", Configuracoes.ConnectionString(uri));
        var servicoEmail = new SendEmailApi();
        var assunto = "Compromissos da Agenda do Advocati.NET para ";
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

            var conteudoHtml = ConteudoHtml(cNome, uri, oCnn);

            if (string.IsNullOrEmpty(conteudoHtml))
            {
                continue;
            }

            var email = new MenphisSI.Api.Models.SendEmail
            {
                ParaEmail = operador.FEMailNet.Contains("@") ? "motta@menphis.com.br" : operador.FEMailNet,
                ParaNome = cNome,
                Assunto = assunto + cNome,
                Mensagem = conteudoHtml,
                NomeDoMail = "ADVOCATI.NET - MENPHIS - SISTEMAS INTELIGENTES",
                Time2Live = 24
            };

            _ = servicoEmail.Send(email);

            count++;
        }
        return count;
    }
}
