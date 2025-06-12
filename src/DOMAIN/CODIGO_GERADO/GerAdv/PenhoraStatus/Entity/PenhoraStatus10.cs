using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBPenhoraStatus : MenphisSI.GerAdv.DBPenhoraStatus, IDBPenhoraStatus
{
    public DBPenhoraStatus() : base()
    {
    }

    public DBPenhoraStatus(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBPenhoraStatus(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBPenhoraStatus(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBPenhoraStatus(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}