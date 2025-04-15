using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBAgendaFinanceiro : MenphisSI.GerAdv.DBAgendaFinanceiro, IDBAgendaFinanceiro
{
    public DBAgendaFinanceiro() : base()
    {
    }

    public DBAgendaFinanceiro(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBAgendaFinanceiro(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBAgendaFinanceiro(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBAgendaFinanceiro(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}