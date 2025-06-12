using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBAtividades : MenphisSI.GerAdv.DBAtividades, IDBAtividades
{
    public DBAtividades() : base()
    {
    }

    public DBAtividades(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBAtividades(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBAtividades(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBAtividades(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}