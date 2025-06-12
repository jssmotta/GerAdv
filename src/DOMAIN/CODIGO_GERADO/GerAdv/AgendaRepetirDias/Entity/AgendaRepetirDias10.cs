using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBAgendaRepetirDias : MenphisSI.GerAdv.DBAgendaRepetirDias, IDBAgendaRepetirDias
{
    public DBAgendaRepetirDias() : base()
    {
    }

    public DBAgendaRepetirDias(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBAgendaRepetirDias(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBAgendaRepetirDias(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBAgendaRepetirDias(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}