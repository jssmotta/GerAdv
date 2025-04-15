using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBArea : MenphisSI.GerAdv.DBArea, IDBArea
{
    public DBArea() : base()
    {
    }

    public DBArea(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBArea(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBArea(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBArea(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}