using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBDocsRecebidosItens : MenphisSI.GerAdv.DBDocsRecebidosItens, IDBDocsRecebidosItens
{
    public DBDocsRecebidosItens() : base()
    {
    }

    public DBDocsRecebidosItens(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBDocsRecebidosItens(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBDocsRecebidosItens(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBDocsRecebidosItens(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}