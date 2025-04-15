using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBPreClientes : MenphisSI.GerAdv.DBPreClientes, IDBPreClientes
{
    public DBPreClientes() : base()
    {
    }

    public DBPreClientes(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBPreClientes(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBPreClientes(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBPreClientes(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}