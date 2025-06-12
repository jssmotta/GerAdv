using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBAgendaStatus : MenphisSI.GerAdv.DBAgendaStatus, IDBAgendaStatus
{
    public DBAgendaStatus() : base()
    {
    }

    public DBAgendaStatus(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBAgendaStatus(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBAgendaStatus(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBAgendaStatus(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}