using System.Text.RegularExpressions;

namespace Domain.BaseCommon.Helpers;

public partial class EnvioNotificacoes
{
    // Modelo para os dados extraídos do HTML legado
    private class CompromissoData
    {
        public string Para { get; set; } = "";
        public string Cliente { get; set; } = "";
        public string ParteContraria { get; set; } = "";
        public string Comarca { get; set; } = "";
        public string Foro { get; set; } = "";
        public string TipoCompromisso { get; set; } = "";  // ex: "Prazo"
        public string Compromisso { get; set; } = "";       // ex: "Peticionar"
        public string TipoAcao { get; set; } = "";          // ex: "Execução de Título Extrajudicial"
        public string NumeroProcesso { get; set; } = "";
        public string LinkProcesso { get; set; } = "";
        public string IconeCompromisso { get; set; } = "";   // URL da img
        public string IconeCiente { get; set; } = "";         // URL da img ciente
        public string IconeEletronico { get; set; } = "";     // URL da img eletrônico
        public string Status { get; set; } = "";
    }

    private CompromissoData ParseCompromissoHtml(string html)
    {
        var data = new CompromissoData();

        // Limpa aspas duplicadas do legado
        html = html.Replace("\"\"", "\"");

        // Para: (primeira célula colspan=3)
        var matchPara = Regex.Match(html, @"<b>Para:&nbsp;(.*?)</b>", RegexOptions.IgnoreCase);
        if (matchPara.Success)
            data.Para = matchPara.Groups[1].Value.Trim().TrimEnd('-');

        // Cliente (td após "Cliente:")
        var matchCliente = Regex.Match(html, @"Cliente:</b>.*?</tr>\s*<tr>.*?<td[^>]*>(.*?)</td>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        if (matchCliente.Success)
            data.Cliente = StripHtml(matchCliente.Groups[1].Value).Trim();

        // Parte contrária
        var matchParte = Regex.Match(html, @"Parte contr.*?</td>\s*<td[^>]*>(.*?)</td>.*?</tr>\s*<tr>.*?<td[^>]*>.*?</td>\s*<td[^>]*><span>(.*?)</span>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        if (matchParte.Success)
            data.ParteContraria = StripHtml(matchParte.Groups[2].Value).Trim();

        // Comarca
        var matchComarca = Regex.Match(html, @"Comarca:&nbsp;(.*?)</b>", RegexOptions.IgnoreCase);
        if (matchComarca.Success)
            data.Comarca = matchComarca.Groups[1].Value.Trim();

        // Foro (dentro da terceira td da segunda linha de dados)
        var matchForo = Regex.Match(html, @"Foro:\s*(.*?)(?:<img|</td>)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        if (matchForo.Success)
            data.Foro = StripHtml(matchForo.Groups[1].Value).Trim().TrimEnd('-', ' ');

        // Tipo de compromisso + texto (ex: "Prazo ... Peticionar")
        var matchTipoComp = Regex.Match(html, @"title=""(Prazo|Audiência|Providência|Reunião|Diligência|Outros)""", RegexOptions.IgnoreCase);
        if (matchTipoComp.Success)
            data.TipoCompromisso = matchTipoComp.Groups[1].Value;
         

        // Compromisso (texto após "Compromisso:<br />")
        var matchComp = Regex.Match(html, @"Compromisso:\s*(?:<br\s*/?>)?\s*(.*?)</td>",
            RegexOptions.Singleline | RegexOptions.IgnoreCase);
        if (matchComp.Success)
            data.Compromisso = StripHtmlKeepImages(matchComp.Groups[1].Value).Trim();  // ← mata os <img>

        // Tipo de ação
        var matchAcao = Regex.Match(html, @"Compromisso:.*?</td>\s*<td[^>]*>(.*?)</td>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        if (matchAcao.Success)
            data.TipoAcao = StripHtml(matchAcao.Groups[1].Value).Trim();

        // Número do processo e link
        var matchProcesso = Regex.Match(html, @"Processo/Adm\.\s*n.\s*<a[^>]*href=""([^""]*?)""[^>]*>(.*?)</a>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        if (matchProcesso.Success)
        {
            data.LinkProcesso = matchProcesso.Groups[1].Value;
            data.NumeroProcesso = StripHtml(matchProcesso.Groups[2].Value).Trim();
        }

        // Ícones
        var matchIconeComp = Regex.Match(html, @"<img[^>]*src=""(https://cdn1\.advocati\.net\.br/msi/v20/agenda/\d+\.webp)""", RegexOptions.IgnoreCase);
        if (matchIconeComp.Success)
            data.IconeCompromisso = matchIconeComp.Groups[1].Value;

        var matchIconeCiente = Regex.Match(html, @"<img[^>]*src=""(https://cdn1\.advocati\.net\.br/msi/v20/agenda/ciente\.webp)""", RegexOptions.IgnoreCase);
        if (matchIconeCiente.Success)
            data.IconeCiente = matchIconeCiente.Groups[1].Value;

        var matchIconeEletronico = Regex.Match(html, @"<img[^>]*src=""(https://cdn1\.advocati\.net\.br/msi/v20/Processus/eletronico\.webp)""", RegexOptions.IgnoreCase);
        if (matchIconeEletronico.Success)
            data.IconeEletronico = matchIconeEletronico.Groups[1].Value;

        // Status
        var matchStatus = Regex.Match(html, @"Status do compromisso:\s*(?:<br\s*/?>)?\s*(.*?)</td>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        if (matchStatus.Success)
            data.Status = StripHtml(matchStatus.Groups[1].Value).Trim();

        return data;
    }

    private static string StripHtml(string html)
    {
        return Regex.Replace(html, "<.*?>", "").Replace("&nbsp;", " ").Replace("&#186;", "º").Trim();
    }

    private string CriarTabelaDaAgendaHtml(DataTable compromissos, string nome, int total)
    {
        var builder = new StringBuilder();
        builder.AppendLine(HeaderAgenda(compromissos, nome, total));

        int contador = 0;
        foreach (DataRow linha in compromissos.Rows)
        {
            contador++;
            var data = (DateTime)linha[0];
            var htmlLegado = linha[1]?.ToString() ?? "";
            var comp = ParseCompromissoHtml(htmlLegado);

            builder.AppendLine(AddCompromisso(contador, data, comp));
        }

        return builder.ToString();
    }
    private static string StripHtmlKeepImages(string html)
    {
        // Remove todas as tags EXCETO <img>
        var result = Regex.Replace(html, @"<(?!img\b)[^>]+>", "", RegexOptions.IgnoreCase);
        return result.Replace("&nbsp;", " ").Replace("&#186;", "º").Trim();
    }
    private static string AddCompromisso(int contador, DateTime data, CompromissoData comp)
    {
        var isHoje = data.Date == DateTime.Now.Date;
        var isAtrasado = data.Date < DateTime.Now.Date;

        var corBorda = isAtrasado ? "#ff3b30" : isHoje ? "#007aff" : "#e5e5ea";
        var corFundo = isAtrasado ? "#fff5f5" : isHoje ? "#f0f5ff" : "#f9f9fb";
        var corData = isAtrasado ? "#ff3b30" : isHoje ? "#007aff" : "#1c1c1e";
        var labelData = isAtrasado ? "Atrasado" : "Data";

        var badgePrimaria = isAtrasado
            ? @"<td style=""background-color: #ff3b30; border-radius: 6px; padding: 3px 10px;""><span style=""font-size: 11px; font-weight: 600; color: #ffffff; text-transform: uppercase; letter-spacing: 0.3px;"">Atrasado</span></td><td style=""padding-left: 6px;"">"
            : isHoje
                ? @"<td style=""background-color: #007aff; border-radius: 6px; padding: 3px 10px;""><span style=""font-size: 11px; font-weight: 600; color: #ffffff; text-transform: uppercase; letter-spacing: 0.3px;"">Hoje</span></td><td style=""padding-left: 6px;"">"
                : "<td>";

        var corSeparador = isAtrasado ? "#ffcdd2" : isHoje ? "#b3d4ff" : "#e5e5ea";
 

        var (corBadgeTipo, corTextoBadge) = comp.TipoCompromisso switch
        {
            "Prazo" => ("#ff0000", "#ffffff"),
            "Audiência" => ("#ffcc00", "#1c1c1e"),
            "Providência" => ("#34c759", "#ffffff"),
            _ => ("#8e8e93", "#ffffff")
        };

        var badgeTipo = !string.IsNullOrEmpty(comp.TipoCompromisso)
            ? $@"<span style=""background-color: {corBadgeTipo}; border-radius: 6px; padding: 3px 10px; font-size: 11px; font-weight: 600; color: {corTextoBadge}; text-transform: uppercase; letter-spacing: 0.3px; display: inline-block;"">{comp.TipoCompromisso}</span>"
            : "";

        var iconeEletronico = !string.IsNullOrEmpty(comp.IconeEletronico)
            ? $@" <img src=""{comp.IconeEletronico}"" alt=""e"" width=""14"" height=""14"" style=""vertical-align: middle;"" />"
            : "";

        var iconeCiente = !string.IsNullOrEmpty(comp.IconeCiente)
            ? $@" <img src=""{comp.IconeCiente}"" alt=""ciente"" width=""14"" height=""14"" style=""vertical-align: middle;"" />"
            : "";

        var iconeCompromisso = !string.IsNullOrEmpty(comp.IconeCompromisso)
    ? $@" <img src=""{comp.IconeCompromisso}"" alt=""{comp.TipoCompromisso}"" width=""14"" height=""14"" style=""vertical-align: middle;"" />"
    : "";

        var linkProcesso = !string.IsNullOrEmpty(comp.NumeroProcesso)
            ? $@"<a href=""{comp.LinkProcesso}"" target=""_blank"" style=""color: #e8581c; text-decoration: none; font-weight: 500;"">{comp.NumeroProcesso}</a>"
            : "";


        var sb = new StringBuilder();

        sb.AppendLine($@"
<tr>
  <td class=""card-padding"">
    <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""background-color: {corFundo}; border-radius: 14px; border: 1px solid {corBorda};"">
      <tr>
        <td style=""padding: 20px;"">

          <!-- Badges -->
          <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" style=""margin-bottom: 10px;"">
            <tr>
              {badgePrimaria}{badgeTipo}</td>
            </tr>
          </table>

          <!-- #N + Data -->
          <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
            <tr>
              <td><span style=""font-size: 11px; font-weight: 600; color: #8e8e93; text-transform: uppercase; letter-spacing: 0.5px;"">#{contador} · {comp.TipoCompromisso}</span>{iconeCiente}{iconeCompromisso}</td>
              <td align=""right""><span style=""font-size: 12px; color: {corData};"">{labelData}</span></td>
            </tr>
            <tr>
              <td style=""padding-top: 2px;""><span style=""font-size: 16px; font-weight: 600; color: #1c1c1e;"">{comp.Compromisso}</span></td>
              <td align=""right"" style=""padding-top: 2px;""><span style=""font-size: 16px; font-weight: 600; color: {corData};"">{data:dddd, dd/MM/yyyy}</span></td>
            </tr>
          </table>

          <!-- Cliente vs Parte contrária -->
          <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""margin-top: 12px;"">
            <tr>
              <td style=""width: 50%; vertical-align: top;"">
                <span style=""font-size: 11px; font-weight: 600; color: #8e8e93; text-transform: uppercase; letter-spacing: 0.3px;"">Cliente</span><br>
                <span style=""font-size: 13px; color: #1c1c1e;"">{comp.Cliente}</span>
              </td>
              <td style=""width: 50%; vertical-align: top; padding-left: 12px;"">
                <span style=""font-size: 11px; font-weight: 600; color: #8e8e93; text-transform: uppercase; letter-spacing: 0.3px;"">Parte contrária</span><br>
                <span style=""font-size: 13px; color: #1c1c1e;"">{comp.ParteContraria}</span>
              </td>
            </tr>
          </table>

          <div style=""height: 1px; background-color: {(isAtrasado ? "#ffcdd2" : "#e5e5ea")}; margin: 14px 0;""></div>

          <!-- Processo + Comarca -->
          <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
            <tr>
              <td style=""vertical-align: top;"">
                <span style=""font-size: 11px; font-weight: 600; color: #8e8e93; text-transform: uppercase; letter-spacing: 0.3px;"">Processo</span>{iconeEletronico}<br>
                {linkProcesso}
              </td>
              <td align=""right"" style=""vertical-align: top;"">
                <span style=""font-size: 11px; font-weight: 600; color: #8e8e93; text-transform: uppercase; letter-spacing: 0.3px;"">Tipo de ação</span><br>
                <span style=""font-size: 12px; color: #636366;"">{comp.TipoAcao}</span>
              </td>
            </tr>
          </table>

          <!-- Comarca/Foro -->
          <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""margin-top: 8px;"">
            <tr>
              <td>
                <span style=""font-size: 11px; font-weight: 600; color: #8e8e93; text-transform: uppercase; letter-spacing: 0.3px;"">Comarca</span><br>
                <span style=""font-size: 12px; color: #636366;"">{comp.Comarca}</span>
              </td>
            </tr>
          </table>

        </td>
      </tr>
    </table>
  </td>
</tr>");

        return sb.ToString();
    }

    private string HeaderAgenda(DataTable compromissos, string nome, int total)
    {
        var totalAtrasados = compromissos.AsEnumerable()
            .Count(r => r[0] != DBNull.Value && ((DateTime)r[0]).Date < DateTime.Now.Date);

        var totalHoje = compromissos.AsEnumerable()
            .Count(r => r[0] != DBNull.Value && ((DateTime)r[0]).Date == DateTime.Now.Date);

        var totalFuturos = compromissos.AsEnumerable()
            .Count(r => r[0] != DBNull.Value && ((DateTime)r[0]).Date > DateTime.Now.Date);

        var sb = new StringBuilder();

        sb.AppendLine($@"
          <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" style=""margin-bottom: 6px;"">
            <tr>
              <td style=""background-color: #fff3ed; border-radius: 6px; padding: 3px 10px;"">
                <span style=""font-size: 11px; font-weight: 600; color: #e8581c; text-transform: uppercase; letter-spacing: 0.3px;"">ADVOCATI.NET - Mais tempo para melhor advogar.</span>
              </td>
            </tr>
          </table>

          <h1 style=""margin: 0 0 6px 0; font-size: 22px; font-weight: 700; color: #1c1c1e; line-height: 1.3;"">
            {total} compromisso{(total == 1 ? "" : "s")} para {nome}
          </h1>
          <p style=""margin: 0 0 4px 0; font-size: 16px; color: #8e8e93;"">
            {DateTime.Now.ToString("MMMM", new CultureInfo("pt-BR")).ToUpper()} {DateTime.Now.Year}
          </p>

          <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""background-color: #f9f9fb; border-radius: 12px; margin-top: 16px;"">
            <tr>
              <td style=""padding: 16px 20px;"">
                <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
                  <tr>
                    <td>
                      <span class=""resumo-label"" style=""font-size: 13px; color: #8e8e93;"">Total</span><br>
                      <span class=""resumo-valor"" style=""font-size: 24px; font-weight: 700; color: #1c1c1e;"">{total}</span>
                    </td>
                    {(totalHoje == 0 ? "" : $@"
                    <td align=""center"">
                      <span class=""resumo-label"" style=""font-size: 13px; color: #8e8e93;"">Hoje</span><br>
                      <span class=""resumo-valor"" style=""font-size: 24px; font-weight: 700; color: #e8581c;"">{totalHoje}</span>
                    </td>")}
                    {(totalAtrasados == 0 ? "" : $@"
                    <td align=""center"">
                      <span class=""resumo-label"" style=""font-size: 13px; color: #8e8e93;"">Atrasados</span><br>
                      <span class=""resumo-valor"" style=""font-size: 24px; font-weight: 700; color: #ff3b30;"">{totalAtrasados}</span>
                    </td>")}
                   
                  </tr>
                </table>
              </td>
            </tr>
          </table>

          <div style=""height: 1px; background-color: #e5e5ea; margin: 24px 0 0 0;""></div>");

        return sb.ToString();

       
    }
}