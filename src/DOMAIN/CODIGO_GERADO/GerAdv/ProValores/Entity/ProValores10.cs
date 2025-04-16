using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBProValores : MenphisSI.GerAdv.DBProValores, IDBProValores
{
    public DBProValores() : base()
    {
    }

    public DBProValores(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBProValores(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBProValores(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBProValores(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}