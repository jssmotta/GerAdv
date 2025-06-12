using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBParteClienteOutras : MenphisSI.GerAdv.DBParteClienteOutras, IDBParteClienteOutras
{
    public DBParteClienteOutras() : base()
    {
    }

    public DBParteClienteOutras(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBParteClienteOutras(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBParteClienteOutras(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBParteClienteOutras(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}