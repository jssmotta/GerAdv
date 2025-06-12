using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBProValores : MenphisSI.GerAdv.DBProValores, IDBProValores
{
    public DBProValores() : base()
    {
    }

    public DBProValores(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBProValores(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBProValores(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBProValores(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}