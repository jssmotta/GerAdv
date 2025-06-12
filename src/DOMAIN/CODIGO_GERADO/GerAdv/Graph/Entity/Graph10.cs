using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBGraph : MenphisSI.GerAdv.DBGraph, IDBGraph
{
    public DBGraph() : base()
    {
    }

    public DBGraph(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBGraph(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBGraph(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBGraph(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}