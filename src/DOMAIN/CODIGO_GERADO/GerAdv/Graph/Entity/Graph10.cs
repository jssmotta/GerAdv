using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBGraph : MenphisSI.GerAdv.DBGraph, IDBGraph
{
    public DBGraph() : base()
    {
    }

    public DBGraph(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBGraph(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBGraph(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBGraph(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}