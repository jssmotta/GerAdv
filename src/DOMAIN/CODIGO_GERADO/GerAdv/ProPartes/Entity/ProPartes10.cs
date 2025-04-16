using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBProPartes : MenphisSI.GerAdv.DBProPartes, IDBProPartes
{
    public DBProPartes() : base()
    {
    }

    public DBProPartes(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBProPartes(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBProPartes(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBProPartes(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}