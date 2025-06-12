using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBOperadores : MenphisSI.GerAdv.DBOperadores, IDBOperadores
{
    public DBOperadores() : base()
    {
    }

    public DBOperadores(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBOperadores(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBOperadores(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBOperadores(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}