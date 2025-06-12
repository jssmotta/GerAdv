using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBOponentes : MenphisSI.GerAdv.DBOponentes, IDBOponentes
{
    public DBOponentes() : base()
    {
    }

    public DBOponentes(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBOponentes(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBOponentes(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBOponentes(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}