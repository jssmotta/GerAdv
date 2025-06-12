using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBApenso2 : MenphisSI.GerAdv.DBApenso2, IDBApenso2
{
    public DBApenso2() : base()
    {
    }

    public DBApenso2(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBApenso2(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBApenso2(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBApenso2(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}