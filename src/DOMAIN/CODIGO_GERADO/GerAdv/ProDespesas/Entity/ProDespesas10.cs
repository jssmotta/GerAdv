using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBProDespesas : MenphisSI.GerAdv.DBProDespesas, IDBProDespesas
{
    public DBProDespesas() : base()
    {
    }

    public DBProDespesas(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBProDespesas(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBProDespesas(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBProDespesas(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}