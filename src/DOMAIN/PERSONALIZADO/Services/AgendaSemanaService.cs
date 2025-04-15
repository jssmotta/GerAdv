using System.Globalization;

namespace MenphisSI.GerAdv.Services;
public partial class AgendaSemanaService
{
    public Task<AgendaSemanaResponse?> GetById(int id, [FromRoute] string uri, CancellationToken token)
    {
        throw new NotImplementedException();
    }
#pragma warning disable CS8613 // Nullability of reference types in return type doesn't match implicitly implemented member.
    public async Task<IEnumerable<AgendaSemanaResponse?>?> Filter30(DateTime? data, int paciente, int isMobile, string uri) => !Uris.ValidaUri(uri, _uris)
            ? throw new Exception("AgendaSemana: URI inválida")
            : (IEnumerable<AgendaSemanaResponse?>?)await Task.Run(() =>
            {

                using var scope = Configuracoes.CreateConnectionScope(uri);
                var oCnn = scope.Connection;
                if (oCnn == null || (data == null))
                {
                    return null;
                }

                var cWhere = isMobile != 1 ? DevourerOne.AppendDataSqlBetween(data, ((DateTime)data).AddDays(31), $"[xxxData]") :
                     DevourerOne.AppendDataSqlDataIgual(data, $"[xxxData]");

                if (paciente > 0)
                {
                    var diaPrimeiroDosUltimos365Dias = Convert.ToDateTime("01/01/" + ((DateTime)data).AddDays(-365).Year);

                    cWhere = $" [xxxCliente] = {paciente}";
                    cWhere += TSql.And;
                    cWhere += DevourerOne.AppendDataSqlBetween(diaPrimeiroDosUltimos365Dias, ((DateTime)data), $"[xxxData]");
                }

                var result = GerAdv.Wheres.AgendaSemana.ReadList(cWhere, oCnn);

                return result;
            });
#pragma warning restore CS8613 // Nullability of reference types in return type doesn't match implicitly implemented member.

    public async Task<IEnumerable<MenuAgendaSemana>?>? Monta(DateTime dataInicial, bool isMobile, string uri)
    {
        if (!Uris.ValidaUri(uri, _uris))
        {
            throw new Exception("AgendaSemana: URI inválida");
        }

        var data = dataInicial;
        if (!isMobile)
        {
            while (data.DayOfWeek != DayOfWeek.Monday)
            {
                data = data.AddDays(-1);
            }
        }

        var dataFinal = data.AddDays(8);

        var sql = @$"SELECT [xxxCodigo]
      ,[xxxData]
      ,[xxxFuncionario]
      ,[xxxHora]
      ,[xxxTipoCompromisso]
      ,[xxxCompromisso]
      ,[xxxConcluido]
      ,[xxxLiberado]
      ,[xxxRecibo]
      ,[xxxCancelou]
      ,[xxxNaoCompareceu]
      ,[xxxImportante]
      ,[xxxHoraFinal]
      ,[xxxNome]
      ,[xxxTipo]
        ,[xxxNomeCliente]
      ,[xxxProntuario]
  FROM [dbo].[AgendaSemana]
  where  {(isMobile ? DevourerOne.AppendDataSqlDataIgual(data, "[xxxData]") :
                     DevourerOne.AppendDataSqlBetween(data, dataFinal, "[xxxData]"))}
    order by YEAR([xxxData]), MONTH([xxxData]), DAY([xxxData]), CONVERT(TIME, [xxxHora]), [xxxFuncionario]";
        ;

        using var oCnn = Configuracoes.GetConnectionByUri(uri);
        if (oCnn == null)
        {
            return null;
        }
        int nMax = isMobile ? 1 : 8;
        var menus = new List<MenuAgendaSemana>();
        for (int i = 0; i < nMax; i++)
        {
            var dia = data.AddDays(i);
            if (dia.DayOfWeek == DayOfWeek.Sunday) continue;
            var menu = new MenuAgendaSemana
            {
                Text = $"{dia.ToString("ddd", new CultureInfo("pt-BR"))[..1].ToUpper()}{dia.ToString("ddd", new CultureInfo("pt-BR"))[1..]}-{dia:dd-MM}",
                Items = []
            };
            menus.Add(menu);
            if (isMobile) break;
        }

        //   nMax = isMobile ? 2 : 9;

        var result = await ConfiguracoesDBT.GetDataTable2Async(sql, oCnn);
        try
        {
            var nIndex = -1;
            for (int i = 0; i < nMax; i++)
            {
                var dia = data.AddDays(i);
                if (dia.DayOfWeek == DayOfWeek.Sunday) continue;
                nIndex++;
                var menu = menus[nIndex];
                var items = new List<MenuAgendaSemana>
                    {
                        new MenuAgendaSemana { Text = "Novo compromisso...", Id = dia.Ticks }
                    };

                if (result != null)
                {
                    foreach (DataRow row in result.Rows)
                    {
                        if (DBNull.Value != row["xxxData"] && (Convert.ToDateTime(row["xxxData"]).Date == dia.Date))
                        {
                            var hora = DBNull.Value == row["xxxHora"] ? "" : $"{Convert.ToDateTime(row["xxxHora"]):HH:mm}";
                            var horaFinal = DBNull.Value == row["xxxHoraFinal"] ? " - " : $"-{Convert.ToDateTime(row["xxxHoraFinal"]):HH:mm} - ";
                            var concluido = DBNull.Value != row["xxxConcluido"] && !((bool)row["xxxConcluido"]) ? "" : "ok";
                            var cancelou = DBNull.Value != row["xxxCancelou"] && ((bool)row["xxxCancelou"]) ? " - [CANCELOU]" : "";
                            var recibo = DBNull.Value != row["xxxRecibo"] && ((bool)row["xxxRecibo"]) ? " - [RECIBO]" : "";
                            var icone = DBNull.Value == row["xxxTipoCompromisso"] ? "1" : row["xxxTipoCompromisso"];
                            var tipo = DBNull.Value == row["xxxTipo"] ? "(ERRO TIPO)" : row["xxxTipo"];
                            var prontuario = DBNull.Value == row["xxxProntuario"] ? "" : $" - {row["xxxProntuario"]}";
                            string cNome;
                            if (prontuario.Contains("10000"))
                            {
                                cNome = DBNull.Value == row["xxxNomeCliente"] ? "" : row["xxxNomeCliente"].ToString();
                            }
                            else
                            {
                                cNome = DBNull.Value == row["xxxNome"] ? "" : row["xxxNome"].ToString();
                            }
                            items.Add(new MenuAgendaSemana
                            {
                                Id = Convert.ToInt32(row["xxxCodigo"]),
                                Text = $"<span class='tipoCompromisso{icone}{concluido}'>&nbsp;</span> {hora}{horaFinal} {cNome} - {tipo} - {row["xxxCompromisso"]}{cancelou}{recibo}{prontuario}"
                            });
                        }
                    }

                    menu.Items = items;

                }
            }

            nIndex = -1;
            for (int i = 0; i < nMax; i++)
            {
                var dia = data.AddDays(i);
                if (dia.DayOfWeek == DayOfWeek.Sunday) continue;
                nIndex++;
                var menu = menus[nIndex];
                menus[nIndex].Text = $"{menus[nIndex].Text}({(menus[nIndex].Items.Count - 1 == 0 ? "0" : menus[nIndex].Items.Count - 1)})";
            }

            return menus;
        }
        catch
        {
            return null;
        }

    }
}