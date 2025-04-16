using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBBensClassificacao : MenphisSI.GerAdv.DBBensClassificacao, IDBBensClassificacao
{
    public DBBensClassificacao() : base()
    {
    }

    public DBBensClassificacao(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBBensClassificacao(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBBensClassificacao(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBBensClassificacao(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}