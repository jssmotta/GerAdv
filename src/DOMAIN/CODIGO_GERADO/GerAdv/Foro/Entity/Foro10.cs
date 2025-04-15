using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBForo : MenphisSI.GerAdv.DBForo, IDBForo
{
    public DBForo() : base()
    {
    }

    public DBForo(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBForo(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBForo(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBForo(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}