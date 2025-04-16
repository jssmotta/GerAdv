using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBApenso2 : MenphisSI.GerAdv.DBApenso2, IDBApenso2
{
    public DBApenso2() : base()
    {
    }

    public DBApenso2(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBApenso2(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBApenso2(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBApenso2(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}