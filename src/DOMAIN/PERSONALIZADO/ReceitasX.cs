
// ReSharper disable once CheckNamespace
namespace MenphisSI.GerMDS;
public partial class DBReceitasX
{
    public static IEnumerable<DBReceitasX> ListarX(string? cSqlMain, string? cWhere, string? cOrder, string? cCnn)
    {
        var cSql = new StringBuilder(); // aqui 0x3
        if (!cSqlMain.IsEmpty())
        {
            cSql.Append(cSqlMain?.indexOf(CamposSqlX) == -1 ? cSqlMain.toUpper()?.replace(" * ", CamposSqlX)?.replace($"{PTabelaNome}.*", CamposSqlX) : cSqlMain);
        }
        else
        {
            cSql.Append($"SELECT {CamposSqlX} FROM dbo.{PTabelaNome} (NOLOCK) ");
            if (!cWhere.IsEmpty())
            {
                if (!cWhere.toUpper().Contains(TSql.Where))
                {
                    cSql.Append(TSql.Where);
                }

                cSql.Append(cWhere);
            }

            if (!cOrder.IsEmpty())
            {
                if (!cOrder.toUpper().Contains(TSql.OrderBy))
                    cSql.Append(TSql.OrderBy);
                cSql.Append(cOrder);
            }
            else
            {
                cSql.Append(TSql.OrderBy);
                cSql.Append($"{DBReceitasXDicInfo.DataEmissao}");
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
            yield return new DBReceitasX(dbRec);
    }

}
