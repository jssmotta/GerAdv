using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBParteClienteOutras : MenphisSI.GerAdv.DBParteClienteOutras, IDBParteClienteOutras
{
    public DBParteClienteOutras() : base()
    {
    }

    public DBParteClienteOutras(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBParteClienteOutras(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBParteClienteOutras(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBParteClienteOutras(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}