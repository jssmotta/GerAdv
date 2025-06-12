using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBDivisaoTribunal : MenphisSI.GerAdv.DBDivisaoTribunal, IDBDivisaoTribunal
{
    public DBDivisaoTribunal() : base()
    {
    }

    public DBDivisaoTribunal(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBDivisaoTribunal(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBDivisaoTribunal(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBDivisaoTribunal(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}