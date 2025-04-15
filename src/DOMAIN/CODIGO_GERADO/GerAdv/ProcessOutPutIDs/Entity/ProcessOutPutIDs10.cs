using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBProcessOutPutIDs : MenphisSI.GerAdv.DBProcessOutPutIDs, IDBProcessOutPutIDs
{
    public DBProcessOutPutIDs() : base()
    {
    }

    public DBProcessOutPutIDs(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBProcessOutPutIDs(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBProcessOutPutIDs(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBProcessOutPutIDs(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}