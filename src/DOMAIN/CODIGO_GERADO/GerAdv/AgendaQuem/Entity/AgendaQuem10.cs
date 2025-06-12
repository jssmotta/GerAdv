using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBAgendaQuem : MenphisSI.GerAdv.DBAgendaQuem, IDBAgendaQuem
{
    public DBAgendaQuem() : base()
    {
    }

    public DBAgendaQuem(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBAgendaQuem(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBAgendaQuem(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBAgendaQuem(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}