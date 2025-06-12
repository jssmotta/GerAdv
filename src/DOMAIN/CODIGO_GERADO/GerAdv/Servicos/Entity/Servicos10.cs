using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBServicos : MenphisSI.GerAdv.DBServicos, IDBServicos
{
    public DBServicos() : base()
    {
    }

    public DBServicos(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBServicos(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBServicos(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBServicos(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}