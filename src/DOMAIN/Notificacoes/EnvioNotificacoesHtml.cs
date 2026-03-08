namespace Domain.BaseCommon.Helpers;

public partial class EnvioNotificacoes
{

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

