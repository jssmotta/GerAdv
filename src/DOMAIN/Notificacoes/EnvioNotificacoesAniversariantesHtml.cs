namespace Domain.BaseCommon.Helpers;

public partial class EnvioNotificacoesAniversariantes
{
    private string CriarTabelaDaAgendaHtml(DataTable compromissos, string nome, int total, string mensagem, string extraHeader)
    {
        var builder = new StringBuilder();
        builder.AppendLine(HeaderAniversariantes(compromissos, nome, total, extraHeader));

        int contador = 0;
        foreach (DataRow linha in compromissos.Rows)
        {
            contador++;
            var nomeAniversariante = linha[0]?.ToString() ?? "";
            var mes = Convert.ToInt32(linha[1]);
            var dia = Convert.ToInt32(linha[2]);
            var isHoje = dia == DateTime.Now.Day && mes == DateTime.Now.Month;

            builder.AppendLine(AddAniversariante(contador, nomeAniversariante, dia, mes, isHoje));
        }

        // Mensagem final
        if (mensagem.Length > 0)
        {
            builder.AppendLine($@"
<tr>
  <td style=""padding: 24px 0 0 0;"">
    <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""background-color: #fff3ed; border-radius: 12px;"">
      <tr>
        <td style=""padding: 16px 20px;"">
          <span style=""font-size: 13px; color: #e8581c; line-height: 1.5;"">{nome.Split(' ')[0]}, {mensagem}</span>
        </td>
      </tr>
    </table>
  </td>
</tr>");
        }

        return builder.ToString();
    }

    private static string AddAniversariante(int contador, string nomeAniversariante, int dia, int mes, bool isHoje)
    {
        var corBorda = isHoje ? "#e8581c" : "#e5e5ea";
        var corFundo = isHoje ? "#fff3ed" : "#f9f9fb";
        var estrela = isHoje
            ? @" <span style=""color: #ff3b30; font-size: 16px; vertical-align: middle;"">★</span>"
            : "";
        var badgeHoje = isHoje
            ? @"<td style=""background-color: #e8581c; border-radius: 6px; padding: 3px 10px; margin-bottom: 10px;""><span style=""font-size: 11px; font-weight: 600; color: #ffffff; text-transform: uppercase; letter-spacing: 0.3px;"">Hoje!</span></td>"
            : "<td></td>";

        var sb = new StringBuilder();

        sb.AppendLine($@"
<tr>
  <td style=""padding: 8px 0;"">
    <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""background-color: {corFundo}; border-radius: 14px; border: 1px solid {corBorda};"">
      <tr>
        <td style=""padding: 20px;"">

          <!-- Badge Hoje -->
          <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" style=""margin-bottom: 10px;"">
            <tr>
              {badgeHoje}
            </tr>
          </table>

          <!-- #N + Data -->
          <table role=""presentation"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
            <tr>
              <td><span style=""font-size: 11px; font-weight: 600; color: #8e8e93; text-transform: uppercase; letter-spacing: 0.5px;"">#{contador} · Aniversário</span>{estrela}</td>
              <td align=""right""><span style=""font-size: 11px; font-weight: 600; color: #8e8e93; text-transform: uppercase; letter-spacing: 0.3px;"">Data</span></td>
            </tr>
            <tr>
              <td style=""padding-top: 2px;""><span style=""font-size: 16px; font-weight: 600; color: #1c1c1e;"">{nomeAniversariante}</span></td>
              <td align=""right"" style=""padding-top: 2px;""><span style=""font-size: 16px; font-weight: 600; color: {(isHoje ? "#e8581c" : "#1c1c1e")};"">{dia:D2}/{mes:D2}</span></td>
            </tr>
          </table>

        </td>
      </tr>
    </table>
  </td>
</tr>");

        return sb.ToString();
    }

    private string HeaderAniversariantes(DataTable compromissos, string nome, int total, string extraHeader)
    {
        var totalHoje = compromissos.AsEnumerable()
            .Count(r =>
            {
                var mes = Convert.ToInt32(r[1]);
                var dia = Convert.ToInt32(r[2]);
                return dia == DateTime.Now.Day && mes == DateTime.Now.Month;
            });

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
            {total} aniversariante{(total == 1 ? "" : "s")} nos próximos 7 dias {extraHeader}
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
                      <span style=""font-size: 13px; color: #8e8e93;"">Total</span><br>
                      <span style=""font-size: 24px; font-weight: 700; color: #1c1c1e;"">{total}</span>
                    </td>
                    {(totalHoje == 0 ? "" : $@"
                    <td align=""center"">
                      <span style=""font-size: 13px; color: #8e8e93;"">Hoje</span><br>
                      <span style=""font-size: 24px; font-weight: 700; color: #e8581c;"">{totalHoje}</span>
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