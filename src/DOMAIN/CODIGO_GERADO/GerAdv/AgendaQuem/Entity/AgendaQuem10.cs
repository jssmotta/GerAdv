using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBAgendaQuem : MenphisSI.GerAdv.DBAgendaQuem, IDBAgendaQuem
{
    public DBAgendaQuem() : base()
    {
    }

    public DBAgendaQuem(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBAgendaQuem(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBAgendaQuem(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBAgendaQuem(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}