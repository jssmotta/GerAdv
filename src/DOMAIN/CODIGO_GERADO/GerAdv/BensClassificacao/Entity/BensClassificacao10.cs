using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBBensClassificacao : MenphisSI.GerAdv.DBBensClassificacao, IDBBensClassificacao
{
    public DBBensClassificacao() : base()
    {
    }

    public DBBensClassificacao(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBBensClassificacao(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBBensClassificacao(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBBensClassificacao(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}