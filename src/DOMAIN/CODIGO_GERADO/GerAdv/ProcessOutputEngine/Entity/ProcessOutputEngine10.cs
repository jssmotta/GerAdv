using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBProcessOutputEngine : MenphisSI.GerAdv.DBProcessOutputEngine, IDBProcessOutputEngine
{
    public DBProcessOutputEngine() : base()
    {
    }

    public DBProcessOutputEngine(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBProcessOutputEngine(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBProcessOutputEngine(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBProcessOutputEngine(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}