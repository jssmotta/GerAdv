using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBProcessOutputSources : MenphisSI.GerAdv.DBProcessOutputSources, IDBProcessOutputSources
{
    public DBProcessOutputSources() : base()
    {
    }

    public DBProcessOutputSources(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBProcessOutputSources(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBProcessOutputSources(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBProcessOutputSources(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}