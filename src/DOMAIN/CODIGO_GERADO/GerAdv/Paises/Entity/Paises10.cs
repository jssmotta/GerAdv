using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBPaises : MenphisSI.GerAdv.DBPaises, IDBPaises
{
    public DBPaises() : base()
    {
    }

    public DBPaises(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBPaises(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBPaises(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBPaises(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}