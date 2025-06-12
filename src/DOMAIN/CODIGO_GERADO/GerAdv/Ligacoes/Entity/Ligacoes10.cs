using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBLigacoes : MenphisSI.GerAdv.DBLigacoes, IDBLigacoes
{
    public DBLigacoes() : base()
    {
    }

    public DBLigacoes(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBLigacoes(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBLigacoes(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBLigacoes(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}