using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBLivroCaixa : MenphisSI.GerAdv.DBLivroCaixa, IDBLivroCaixa
{
    public DBLivroCaixa() : base()
    {
    }

    public DBLivroCaixa(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBLivroCaixa(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBLivroCaixa(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBLivroCaixa(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}