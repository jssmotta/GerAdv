using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBRegimeTributacao : MenphisSI.GerAdv.DBRegimeTributacao, IDBRegimeTributacao
{
    public DBRegimeTributacao() : base()
    {
    }

    public DBRegimeTributacao(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBRegimeTributacao(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBRegimeTributacao(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBRegimeTributacao(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}