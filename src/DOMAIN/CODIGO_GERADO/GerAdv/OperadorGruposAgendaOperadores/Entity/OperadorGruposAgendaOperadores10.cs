using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBOperadorGruposAgendaOperadores : MenphisSI.GerAdv.DBOperadorGruposAgendaOperadores, IDBOperadorGruposAgendaOperadores
{
    public DBOperadorGruposAgendaOperadores() : base()
    {
    }

    public DBOperadorGruposAgendaOperadores(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBOperadorGruposAgendaOperadores(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBOperadorGruposAgendaOperadores(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBOperadorGruposAgendaOperadores(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}