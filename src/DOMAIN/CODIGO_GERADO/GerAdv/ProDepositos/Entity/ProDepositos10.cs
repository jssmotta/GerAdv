using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBProDepositos : MenphisSI.GerAdv.DBProDepositos, IDBProDepositos
{
    public DBProDepositos() : base()
    {
    }

    public DBProDepositos(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBProDepositos(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBProDepositos(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBProDepositos(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}