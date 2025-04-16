using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBPenhoraStatus : MenphisSI.GerAdv.DBPenhoraStatus, IDBPenhoraStatus
{
    public DBPenhoraStatus() : base()
    {
    }

    public DBPenhoraStatus(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBPenhoraStatus(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBPenhoraStatus(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBPenhoraStatus(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}