using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBAgendaStatus : MenphisSI.GerAdv.DBAgendaStatus, IDBAgendaStatus
{
    public DBAgendaStatus() : base()
    {
    }

    public DBAgendaStatus(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBAgendaStatus(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBAgendaStatus(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBAgendaStatus(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}