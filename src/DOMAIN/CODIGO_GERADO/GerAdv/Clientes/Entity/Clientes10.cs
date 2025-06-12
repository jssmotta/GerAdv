using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBClientes : MenphisSI.GerAdv.DBClientes, IDBClientes
{
    public DBClientes() : base()
    {
    }

    public DBClientes(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBClientes(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBClientes(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBClientes(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}