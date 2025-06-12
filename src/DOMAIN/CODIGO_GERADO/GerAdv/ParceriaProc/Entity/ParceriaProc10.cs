using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBParceriaProc : MenphisSI.GerAdv.DBParceriaProc, IDBParceriaProc
{
    public DBParceriaProc() : base()
    {
    }

    public DBParceriaProc(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBParceriaProc(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBParceriaProc(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBParceriaProc(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}