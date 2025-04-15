using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBStatusHTrab : MenphisSI.GerAdv.DBStatusHTrab, IDBStatusHTrab
{
    public DBStatusHTrab() : base()
    {
    }

    public DBStatusHTrab(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBStatusHTrab(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBStatusHTrab(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBStatusHTrab(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}