using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBOperadorGruposAgendaOperadores : MenphisSI.GerAdv.DBOperadorGruposAgendaOperadores, IDBOperadorGruposAgendaOperadores
{
    public DBOperadorGruposAgendaOperadores() : base()
    {
    }

    public DBOperadorGruposAgendaOperadores(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBOperadorGruposAgendaOperadores(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBOperadorGruposAgendaOperadores(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBOperadorGruposAgendaOperadores(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}