using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBGUTAtividades : MenphisSI.GerAdv.DBGUTAtividades, IDBGUTAtividades
{
    public DBGUTAtividades() : base()
    {
    }

    public DBGUTAtividades(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBGUTAtividades(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBGUTAtividades(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBGUTAtividades(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}