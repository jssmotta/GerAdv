using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBUltimosProcessos : MenphisSI.GerAdv.DBUltimosProcessos, IDBUltimosProcessos
{
    public DBUltimosProcessos() : base()
    {
    }

    public DBUltimosProcessos(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBUltimosProcessos(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBUltimosProcessos(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBUltimosProcessos(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}