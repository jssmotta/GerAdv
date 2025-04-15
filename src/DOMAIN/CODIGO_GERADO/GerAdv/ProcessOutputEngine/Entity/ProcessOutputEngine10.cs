using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBProcessOutputEngine : MenphisSI.GerAdv.DBProcessOutputEngine, IDBProcessOutputEngine
{
    public DBProcessOutputEngine() : base()
    {
    }

    public DBProcessOutputEngine(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBProcessOutputEngine(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBProcessOutputEngine(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBProcessOutputEngine(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}