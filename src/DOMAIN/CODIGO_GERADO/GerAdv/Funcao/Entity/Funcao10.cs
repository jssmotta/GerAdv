using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBFuncao : MenphisSI.GerAdv.DBFuncao, IDBFuncao
{
    public DBFuncao() : base()
    {
    }

    public DBFuncao(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBFuncao(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBFuncao(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBFuncao(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}