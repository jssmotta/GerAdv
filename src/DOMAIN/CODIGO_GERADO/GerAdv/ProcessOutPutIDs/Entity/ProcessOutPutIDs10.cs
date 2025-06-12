using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBProcessOutPutIDs : MenphisSI.GerAdv.DBProcessOutPutIDs, IDBProcessOutPutIDs
{
    public DBProcessOutPutIDs() : base()
    {
    }

    public DBProcessOutPutIDs(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBProcessOutPutIDs(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBProcessOutPutIDs(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBProcessOutPutIDs(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}