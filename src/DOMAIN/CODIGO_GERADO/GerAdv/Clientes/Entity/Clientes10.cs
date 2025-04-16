using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBClientes : MenphisSI.GerAdv.DBClientes, IDBClientes
{
    public DBClientes() : base()
    {
    }

    public DBClientes(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBClientes(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBClientes(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBClientes(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}