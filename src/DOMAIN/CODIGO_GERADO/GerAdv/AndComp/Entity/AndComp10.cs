using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBAndComp : MenphisSI.GerAdv.DBAndComp, IDBAndComp
{
    public DBAndComp() : base()
    {
    }

    public DBAndComp(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBAndComp(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBAndComp(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBAndComp(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}