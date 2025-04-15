using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBProcessOutputRequest : MenphisSI.GerAdv.DBProcessOutputRequest, IDBProcessOutputRequest
{
    public DBProcessOutputRequest() : base()
    {
    }

    public DBProcessOutputRequest(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBProcessOutputRequest(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBProcessOutputRequest(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBProcessOutputRequest(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}