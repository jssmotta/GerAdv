// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
public partial class DBAgendaRecords
{
    public List<DBNomeID>? ListarNT(string cWhere, string cOrder, string joinSql, string? cCnn, bool caching = true, int max = 200)
    {
        throw new NotImplementedException();
    }

#region ListarDados_AgendaRecords
    public static async IAsyncEnumerable<DBAgendaRecords> ListarAsync(string? cSqlMain, string? cWhere, string? cOrder, string? cCnn)
    {
        var cSql = new StringBuilder(); // checkpoint 0x3
        if (!cSqlMain.IsEmpty())
        {
            cSql.Append(cSqlMain?.indexOf(CamposSqlX) == -1 ? cSqlMain.ToUpper()?.replace(" * ", CamposSqlX)?.replace($"{PTabelaNome}.*", CamposSqlX) : cSqlMain);
        }
        else
        {
            cSql.Append($"SELECT {CamposSqlX} FROM dbo.{PTabelaNome} (NOLOCK) ");
            if (!cWhere.IsEmpty())
            {
                if (!cWhere.ToUpper().Contains(TSql.Where))
                {
                    cSql.Append(TSql.Where);
                }

                cSql.Append(cWhere);
            }

            if (!cOrder.IsEmpty())
            {
                if (!cOrder.ToUpper().Contains(TSql.OrderBy))
                    cSql.Append(TSql.OrderBy);
                cSql.Append(cOrder);
            }
        }

        // checkpoint async 1.0
        using var oTCnn = ConfiguracoesDBT.GetConnection(cCnn);
        using var cmd = new SqlCommand
        {
            Connection = oTCnn,
            CommandText = ConfiguracoesDBT.CmdSql(cSql.ToString()),
            CommandTimeout = 0
        };
        using var dbRec = await cmd.ExecuteReaderAsync().ConfigureAwait(false);
        while (await dbRec.ReadAsync().ConfigureAwait(false))
        {
            yield return new DBAgendaRecords(dbRec);
        }
    }

    public static IEnumerable<DBAgendaRecords> Listar(string? cSqlMain, string? cWhere, string? cOrder, string? cCnn)
    {
        var cSql = new StringBuilder(); // checkpoint 0x3
        if (!cSqlMain.IsEmpty())
        {
            cSql.Append(cSqlMain?.indexOf(CamposSqlX) == -1 ? cSqlMain.ToUpper()?.replace(" * ", CamposSqlX)?.replace($"{PTabelaNome}.*", CamposSqlX) : cSqlMain);
        }
        else
        {
            cSql.Append($"SELECT {CamposSqlX} FROM dbo.{PTabelaNome} (NOLOCK) ");
            if (!cWhere.IsEmpty())
            {
                if (!cWhere.ToUpper().Contains(TSql.Where))
                {
                    cSql.Append(TSql.Where);
                }

                cSql.Append(cWhere);
            }

            if (!cOrder.IsEmpty())
            {
                if (!cOrder.ToUpper().Contains(TSql.OrderBy))
                    cSql.Append(TSql.OrderBy);
                cSql.Append(cOrder);
            }
        }

        using var oTCnn = ConfiguracoesDBT.GetConnection(cCnn);
        using var cmd = new SqlCommand
        {
            Connection = oTCnn,
            CommandText = ConfiguracoesDBT.CmdSql(cSql.ToString()),
            CommandTimeout = 0
        };
        var dbRec = cmd.ExecuteReader();
        while (dbRec.Read())
            yield return new DBAgendaRecords(dbRec);
    }
#endregion
}