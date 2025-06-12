using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBUF : MenphisSI.GerAdv.DBUF, IDBUF
{
    public DBUF() : base()
    {
    }

    public DBUF(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBUF(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBUF(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBUF(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}