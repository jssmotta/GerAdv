using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBAgenda2Agenda : MenphisSI.GerAdv.DBAgenda2Agenda, IDBAgenda2Agenda
{
    public DBAgenda2Agenda() : base()
    {
    }

    public DBAgenda2Agenda(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBAgenda2Agenda(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBAgenda2Agenda(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBAgenda2Agenda(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}