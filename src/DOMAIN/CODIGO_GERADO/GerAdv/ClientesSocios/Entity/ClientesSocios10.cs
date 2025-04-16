using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBClientesSocios : MenphisSI.GerAdv.DBClientesSocios, IDBClientesSocios
{
    public DBClientesSocios() : base()
    {
    }

    public DBClientesSocios(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBClientesSocios(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBClientesSocios(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBClientesSocios(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}