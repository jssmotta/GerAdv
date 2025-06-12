using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBProObservacoes : MenphisSI.GerAdv.DBProObservacoes, IDBProObservacoes
{
    public DBProObservacoes() : base()
    {
    }

    public DBProObservacoes(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBProObservacoes(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBProObservacoes(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBProObservacoes(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}