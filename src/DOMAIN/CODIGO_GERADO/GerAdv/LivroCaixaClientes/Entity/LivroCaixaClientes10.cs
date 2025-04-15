using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBLivroCaixaClientes : MenphisSI.GerAdv.DBLivroCaixaClientes, IDBLivroCaixaClientes
{
    public DBLivroCaixaClientes() : base()
    {
    }

    public DBLivroCaixaClientes(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBLivroCaixaClientes(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBLivroCaixaClientes(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBLivroCaixaClientes(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}