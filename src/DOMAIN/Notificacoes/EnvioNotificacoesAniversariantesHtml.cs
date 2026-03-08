namespace Domain.BaseCommon.Helpers;

public partial class EnvioNotificacoesAniversariantes
{
    private string CriarTabelaDaAgendaHtml(DataTable compromissos, string nome, int total, string mensagem, string extraHeader)
    {
        var estiloTabela = ObterEstiloTabelaCss();
        var builder = new StringBuilder(estiloTabela);

        // Adiciona o cabeçalho da tabela
        builder.AppendLine("<table class='tabAniversariantes'><thead>");
        builder.AppendLine("<tr>");
        builder.AppendLine($"<th width=\"4%\">#</th>");
        builder.AppendLine($"<th width=\"78%\">Aniversariante{(total == 1 ? "" : "s")} nos próximos 7 dias {extraHeader}</h1></th>");
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
        if (mensagem.Length > 0) builder.AppendLine($"<span><b>{nome.Split(' ')[0]}, {mensagem}</b></span>");
        return builder.ToString();
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

}
