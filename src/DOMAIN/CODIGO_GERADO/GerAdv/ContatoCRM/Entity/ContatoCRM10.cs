using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBContatoCRM : MenphisSI.GerAdv.DBContatoCRM, IDBContatoCRM
{
    public DBContatoCRM() : base()
    {
    }

    public DBContatoCRM(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBContatoCRM(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBContatoCRM(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBContatoCRM(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}