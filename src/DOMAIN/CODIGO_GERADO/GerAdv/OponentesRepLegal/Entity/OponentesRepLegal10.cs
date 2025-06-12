using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBOponentesRepLegal : MenphisSI.GerAdv.DBOponentesRepLegal, IDBOponentesRepLegal
{
    public DBOponentesRepLegal() : base()
    {
    }

    public DBOponentesRepLegal(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBOponentesRepLegal(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBOponentesRepLegal(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBOponentesRepLegal(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}