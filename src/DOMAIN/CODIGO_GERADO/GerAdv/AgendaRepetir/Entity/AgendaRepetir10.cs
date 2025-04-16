using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBAgendaRepetir : MenphisSI.GerAdv.DBAgendaRepetir, IDBAgendaRepetir
{
    public DBAgendaRepetir() : base()
    {
    }

    public DBAgendaRepetir(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBAgendaRepetir(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBAgendaRepetir(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBAgendaRepetir(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}