using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBDocsRecebidosItens : MenphisSI.GerAdv.DBDocsRecebidosItens, IDBDocsRecebidosItens
{
    public DBDocsRecebidosItens() : base()
    {
    }

    public DBDocsRecebidosItens(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBDocsRecebidosItens(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBDocsRecebidosItens(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBDocsRecebidosItens(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}