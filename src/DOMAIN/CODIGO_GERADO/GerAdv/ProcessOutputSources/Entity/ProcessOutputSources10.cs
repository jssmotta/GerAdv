using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBProcessOutputSources : MenphisSI.GerAdv.DBProcessOutputSources, IDBProcessOutputSources
{
    public DBProcessOutputSources() : base()
    {
    }

    public DBProcessOutputSources(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBProcessOutputSources(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBProcessOutputSources(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBProcessOutputSources(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}