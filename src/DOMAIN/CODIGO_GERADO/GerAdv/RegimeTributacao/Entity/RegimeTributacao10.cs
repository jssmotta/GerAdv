using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBRegimeTributacao : MenphisSI.GerAdv.DBRegimeTributacao, IDBRegimeTributacao
{
    public DBRegimeTributacao() : base()
    {
    }

    public DBRegimeTributacao(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBRegimeTributacao(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBRegimeTributacao(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBRegimeTributacao(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}