using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBParteCliente : MenphisSI.GerAdv.DBParteCliente, IDBParteCliente
{
    public DBParteCliente() : base()
    {
    }

    public DBParteCliente(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBParteCliente(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBParteCliente(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBParteCliente(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}