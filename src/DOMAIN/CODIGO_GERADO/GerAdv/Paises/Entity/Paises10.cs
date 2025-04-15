using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBPaises : MenphisSI.GerAdv.DBPaises, IDBPaises
{
    public DBPaises() : base()
    {
    }

    public DBPaises(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBPaises(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBPaises(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBPaises(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}