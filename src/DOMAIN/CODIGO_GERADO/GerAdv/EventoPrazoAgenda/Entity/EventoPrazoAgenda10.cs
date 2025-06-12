using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBEventoPrazoAgenda : MenphisSI.GerAdv.DBEventoPrazoAgenda, IDBEventoPrazoAgenda
{
    public DBEventoPrazoAgenda() : base()
    {
    }

    public DBEventoPrazoAgenda(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBEventoPrazoAgenda(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBEventoPrazoAgenda(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBEventoPrazoAgenda(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}