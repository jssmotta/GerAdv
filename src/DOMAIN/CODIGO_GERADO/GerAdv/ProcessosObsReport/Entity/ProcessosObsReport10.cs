using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBProcessosObsReport : MenphisSI.GerAdv.DBProcessosObsReport, IDBProcessosObsReport
{
    public DBProcessosObsReport() : base()
    {
    }

    public DBProcessosObsReport(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBProcessosObsReport(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBProcessosObsReport(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBProcessosObsReport(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}