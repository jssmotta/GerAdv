using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBFornecedores : MenphisSI.GerAdv.DBFornecedores, IDBFornecedores
{
    public DBFornecedores() : base()
    {
    }

    public DBFornecedores(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBFornecedores(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBFornecedores(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBFornecedores(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}