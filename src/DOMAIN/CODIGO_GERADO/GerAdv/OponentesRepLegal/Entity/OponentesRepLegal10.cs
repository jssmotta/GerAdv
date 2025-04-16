using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBOponentesRepLegal : MenphisSI.GerAdv.DBOponentesRepLegal, IDBOponentesRepLegal
{
    public DBOponentesRepLegal() : base()
    {
    }

    public DBOponentesRepLegal(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBOponentesRepLegal(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBOponentesRepLegal(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBOponentesRepLegal(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}