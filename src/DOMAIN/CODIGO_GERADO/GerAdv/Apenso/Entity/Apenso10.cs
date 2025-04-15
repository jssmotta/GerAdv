using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBApenso : MenphisSI.GerAdv.DBApenso, IDBApenso
{
    public DBApenso() : base()
    {
    }

    public DBApenso(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBApenso(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBApenso(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBApenso(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}