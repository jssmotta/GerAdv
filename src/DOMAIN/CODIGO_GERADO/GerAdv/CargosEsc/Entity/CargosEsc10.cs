using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBCargosEsc : MenphisSI.GerAdv.DBCargosEsc, IDBCargosEsc
{
    public DBCargosEsc() : base()
    {
    }

    public DBCargosEsc(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBCargosEsc(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBCargosEsc(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBCargosEsc(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}