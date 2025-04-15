using MenphisSI.DB;

namespace MenphisSI.GerAdv.Wheres;
public static partial class AgendaSemana
{
    public static List<AgendaSemanaResponse> ReadList(string where, SqlConnection oCnn)
    {
        var dbList = ListaAgendaSemana(sqlWhere: where, oCnn: oCnn);
        var result = new List<AgendaSemanaResponse>();
        foreach (var dbRec in dbList)
        {

            var agendasemana = new AgendaSemanaResponse
            {
                Id = dbRec.ID,
                Data = dbRec.FData,
                Funcionario = dbRec.FFuncionario,
                Hora = dbRec.FHora,
                TipoCompromisso = dbRec.FTipoCompromisso,
                Compromisso = dbRec.FCompromisso,
                Concluido = dbRec.FConcluido,
                Liberado = dbRec.FLiberado,
                Cancelou = dbRec.FCancelou,
                NaoCompareceu = dbRec.FNaoCompareceu,
                Importante = dbRec.FImportante,
                HoraFinal = dbRec.FHoraFinal,
                Nome = dbRec.FNome ?? string.Empty,
            };
            result.Add(agendasemana);
        }
        return result;
    }

    private static List<DBAgendaSemana> ListaAgendaSemana(string sqlWhere, SqlConnection oCnn)
    {
        var result = new List<DBAgendaSemana>();

        var sql = $@"
            SELECT  [xxxCodigo]
      ,[xxxData]
      ,[xxxFuncionario]
      ,[xxxHora]
      ,[xxxTipoCompromisso]
      ,[xxxCompromisso]
      ,[xxxConcluido]
      ,[xxxLiberado]
      ,[xxxCancelou]
      ,[xxxRecibo]
      ,[xxxNaoCompareceu]
      ,[xxxImportante]
      ,[xxxHoraFinal]
      ,[xxxNome]
      ,[xxxProntuario]
      ,[xxxCliente]
        ,[xxxNomeCliente]
      ,[xxxTipo]                
            FROM
                dbo.AgendaSemana
            WHERE
                {sqlWhere} 
           ORDER BY YEAR([xxxData]), MONTH([xxxData]), DAY([xxxData]), CONVERT(TIME, [xxxHora]), [xxxFuncionario];";


        var data = ConfiguracoesDBT.GetDataTable2(sql, oCnn);
        if (data is null)
            return result;
        foreach (DataRow row in data.Rows)
        {
            var dbRec = new DBAgendaSemana
            {
                ID = row["xxxCodigo"] != DBNull.Value ? Convert.ToInt32(row["xxxCodigo"].ToString()) : 0,
                FFuncionario = row["xxxFuncionario"] != DBNull.Value ? Convert.ToInt32(row["xxxFuncionario"]) : 0,
                FTipoCompromisso = row["xxxTipoCompromisso"] != DBNull.Value ? Convert.ToInt32(row["xxxTipoCompromisso"].ToString()) : 0,
                FCompromisso = row["xxxCompromisso"] != DBNull.Value ? row["xxxCompromisso"]?.ToString() ?? "": "",
                FConcluido = row["xxxConcluido"] != DBNull.Value && Convert.ToBoolean(row["xxxConcluido"]),
                FLiberado = row["xxxLiberado"] != DBNull.Value && Convert.ToBoolean(row["xxxLiberado"]),
                FCancelou = row["xxxCancelou"] != DBNull.Value && Convert.ToBoolean(row["xxxCancelou"]),
                FNaoCompareceu = row["xxxNaoCompareceu"] != DBNull.Value && Convert.ToBoolean(row["xxxNaoCompareceu"]),
                FImportante = row["xxxImportante"] != DBNull.Value && Convert.ToBoolean(row["xxxImportante"]),
                FNome = row["xxxNome"] != DBNull.Value ? row["xxxNome"].ToString() : "",
                FData = row["xxxData"] != DBNull.Value ? DateTime.Parse(row["xxxData"]?.ToString() ?? "").ToString("dd/MM/yyyy HH:mm:ss") : "",
                FHora = row["xxxHora"] != DBNull.Value ? DateTime.Parse(row["xxxHora"]?.ToString()??"").ToString("dd/MM/yyyy HH:mm:ss") : "",
                FHoraFinal = row["xxxHoraFinal"] != DBNull.Value ? DateTime.Parse(row["xxxHoraFinal"]?.ToString()??"").ToString("dd/MM/yyyy HH:mm:ss"):""
            };

            var prontuario = DBNull.Value == row["xxxProntuario"] ? "" : $"{row["xxxProntuario"]}";
            string cNome;
            if (prontuario == "10000")
            {
                cNome = DBNull.Value == row["xxxNomeCliente"] ? "" : row["xxxNomeCliente"].ToString();
                dbRec.FNome = cNome;
            }
             


            result.Add(dbRec);
        }

        return result;
    }
}