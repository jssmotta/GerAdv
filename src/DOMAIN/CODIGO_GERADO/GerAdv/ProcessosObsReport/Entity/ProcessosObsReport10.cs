using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBProcessosObsReport : MenphisSI.GerAdv.DBProcessosObsReport, IDBProcessosObsReport
{
    public DBProcessosObsReport() : base()
    {
    }

    public DBProcessosObsReport(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBProcessosObsReport(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBProcessosObsReport(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBProcessosObsReport(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}