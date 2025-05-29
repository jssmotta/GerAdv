// ReSharper disable once CheckNamespace
namespace MenphisSI.GerAdv;
[Serializable]
// ReSharper disable once InconsistentNaming
public partial class DBAgendaSemana : XCodeIdBase
{
#region SQLDefinition_AgendaSemana
    public const string TabelaNome = "AgendaSemana";
    public DBAgendaSemana()
    {
    }

#endregion
    public DBAgendaSemana(in int nCodigo, MsiSqlConnection? oCnn) => Carregar(id: nCodigo, oCnn: oCnn);
#region ListarDados_AgendaSemana
    public static IEnumerable<DBAgendaSemana> Listar(string? cSqlMain, string? cWhere, string? cOrder, string? cCnn)
    {
        using var oTCnn = ConfiguracoesDBT.GetConnection(cCnn);
        var cSql = new StringBuilder(); // checkpoint 0x3
        cSql.Append(PTabelaNome);
        if (cWhere.NotIsEmpty())
        {
            if (cWhere?.ToUpper().IndexOf(TSql.Where) == -1 && PTabelaNome.ToUpper().IndexOf(TSql.Where) == -1)
            {
                cSql.Append(TSql.Where);
            }

            cSql.Append(cWhere);
        }

        if (cOrder.NotIsEmpty())
        {
            if (!cOrder!.ToUpper().Contains(TSql.OrderBy))
                cSql.Append(TSql.OrderBy);
            cSql.Append(cOrder);
        }

        using var cmd = new SqlCommand
        {
            Connection = oTCnn?.InnerConnection,
            CommandText = ConfiguracoesDBT.CmdSql(cSql.ToString()),
            CommandTimeout = 0
        };
        var dbRec = cmd.ExecuteReader();
        while (dbRec.Read())
            yield return new DBAgendaSemana(dbRec);
    }
#endregion
}