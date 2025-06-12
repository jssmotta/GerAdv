using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBContratos : MenphisSI.GerAdv.DBContratos, IDBContratos
{
    public DBContratos() : base()
    {
    }

    public DBContratos(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBContratos(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBContratos(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBContratos(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}