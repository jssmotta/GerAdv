using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBApenso : MenphisSI.GerAdv.DBApenso, IDBApenso
{
    public DBApenso() : base()
    {
    }

    public DBApenso(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBApenso(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBApenso(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBApenso(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}