using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBStatusBiu : MenphisSI.GerAdv.DBStatusBiu, IDBStatusBiu
{
    public DBStatusBiu() : base()
    {
    }

    public DBStatusBiu(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBStatusBiu(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBStatusBiu(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBStatusBiu(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}