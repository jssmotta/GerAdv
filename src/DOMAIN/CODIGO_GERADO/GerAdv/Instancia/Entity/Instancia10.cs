using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBInstancia : MenphisSI.GerAdv.DBInstancia, IDBInstancia
{
    public DBInstancia() : base()
    {
    }

    public DBInstancia(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBInstancia(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBInstancia(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBInstancia(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}