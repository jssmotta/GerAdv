using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBProPartes : MenphisSI.GerAdv.DBProPartes, IDBProPartes
{
    public DBProPartes() : base()
    {
    }

    public DBProPartes(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBProPartes(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBProPartes(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBProPartes(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}