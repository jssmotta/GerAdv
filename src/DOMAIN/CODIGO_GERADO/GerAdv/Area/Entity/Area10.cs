using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBArea : MenphisSI.GerAdv.DBArea, IDBArea
{
    public DBArea() : base()
    {
    }

    public DBArea(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBArea(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBArea(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBArea(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}