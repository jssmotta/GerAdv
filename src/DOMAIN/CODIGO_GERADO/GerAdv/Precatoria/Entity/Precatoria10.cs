using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBPrecatoria : MenphisSI.GerAdv.DBPrecatoria, IDBPrecatoria
{
    public DBPrecatoria() : base()
    {
    }

    public DBPrecatoria(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBPrecatoria(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBPrecatoria(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBPrecatoria(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}