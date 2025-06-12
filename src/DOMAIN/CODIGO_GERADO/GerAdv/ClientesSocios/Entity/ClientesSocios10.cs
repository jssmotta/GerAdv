using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBClientesSocios : MenphisSI.GerAdv.DBClientesSocios, IDBClientesSocios
{
    public DBClientesSocios() : base()
    {
    }

    public DBClientesSocios(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBClientesSocios(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBClientesSocios(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBClientesSocios(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}