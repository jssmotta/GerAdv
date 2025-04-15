using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBUF : MenphisSI.GerAdv.DBUF, IDBUF
{
    public DBUF() : base()
    {
    }

    public DBUF(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBUF(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBUF(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBUF(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}