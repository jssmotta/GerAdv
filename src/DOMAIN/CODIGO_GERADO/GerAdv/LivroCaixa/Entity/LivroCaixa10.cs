using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBLivroCaixa : MenphisSI.GerAdv.DBLivroCaixa, IDBLivroCaixa
{
    public DBLivroCaixa() : base()
    {
    }

    public DBLivroCaixa(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBLivroCaixa(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBLivroCaixa(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBLivroCaixa(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}