using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBAndComp : MenphisSI.GerAdv.DBAndComp, IDBAndComp
{
    public DBAndComp() : base()
    {
    }

    public DBAndComp(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBAndComp(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBAndComp(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBAndComp(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}