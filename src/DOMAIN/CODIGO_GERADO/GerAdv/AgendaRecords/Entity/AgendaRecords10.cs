using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBAgendaRecords : MenphisSI.GerAdv.DBAgendaRecords, IDBAgendaRecords
{
    public DBAgendaRecords() : base()
    {
    }

    public DBAgendaRecords(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBAgendaRecords(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBAgendaRecords(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBAgendaRecords(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}