using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBStatusHTrab : MenphisSI.GerAdv.DBStatusHTrab, IDBStatusHTrab
{
    public DBStatusHTrab() : base()
    {
    }

    public DBStatusHTrab(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBStatusHTrab(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBStatusHTrab(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBStatusHTrab(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}