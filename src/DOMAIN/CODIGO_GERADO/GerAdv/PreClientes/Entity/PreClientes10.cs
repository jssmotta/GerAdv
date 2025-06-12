using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBPreClientes : MenphisSI.GerAdv.DBPreClientes, IDBPreClientes
{
    public DBPreClientes() : base()
    {
    }

    public DBPreClientes(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBPreClientes(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBPreClientes(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBPreClientes(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}