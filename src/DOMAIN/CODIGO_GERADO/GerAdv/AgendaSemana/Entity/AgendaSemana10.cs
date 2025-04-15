using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBAgendaSemana : MenphisSI.GerAdv.DBAgendaSemana, IDBAgendaSemana
{
    public DBAgendaSemana() : base()
    {
    }

    public DBAgendaSemana(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBAgendaSemana(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBAgendaSemana(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBAgendaSemana(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}