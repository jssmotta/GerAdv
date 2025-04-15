using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBEventoPrazoAgenda : MenphisSI.GerAdv.DBEventoPrazoAgenda, IDBEventoPrazoAgenda
{
    public DBEventoPrazoAgenda() : base()
    {
    }

    public DBEventoPrazoAgenda(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBEventoPrazoAgenda(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBEventoPrazoAgenda(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBEventoPrazoAgenda(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}