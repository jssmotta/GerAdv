using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBGUTPeriodicidadeStatus : MenphisSI.GerAdv.DBGUTPeriodicidadeStatus, IDBGUTPeriodicidadeStatus
{
    public DBGUTPeriodicidadeStatus() : base()
    {
    }

    public DBGUTPeriodicidadeStatus(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBGUTPeriodicidadeStatus(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBGUTPeriodicidadeStatus(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBGUTPeriodicidadeStatus(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}