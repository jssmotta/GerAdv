using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBAgendaRelatorio : MenphisSI.GerAdv.DBAgendaRelatorio, IDBAgendaRelatorio
{
    public DBAgendaRelatorio() : base()
    {
    }

    public DBAgendaRelatorio(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBAgendaRelatorio(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBAgendaRelatorio(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBAgendaRelatorio(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}