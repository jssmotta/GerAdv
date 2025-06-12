using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBUltimosProcessos : MenphisSI.GerAdv.DBUltimosProcessos, IDBUltimosProcessos
{
    public DBUltimosProcessos() : base()
    {
    }

    public DBUltimosProcessos(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBUltimosProcessos(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBUltimosProcessos(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBUltimosProcessos(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}