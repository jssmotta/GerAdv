using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBProBarCODE : MenphisSI.GerAdv.DBProBarCODE, IDBProBarCODE
{
    public DBProBarCODE() : base()
    {
    }

    public DBProBarCODE(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBProBarCODE(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBProBarCODE(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBProBarCODE(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}