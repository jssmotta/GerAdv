using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBProcessOutputRequest : MenphisSI.GerAdv.DBProcessOutputRequest, IDBProcessOutputRequest
{
    public DBProcessOutputRequest() : base()
    {
    }

    public DBProcessOutputRequest(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBProcessOutputRequest(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBProcessOutputRequest(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBProcessOutputRequest(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}