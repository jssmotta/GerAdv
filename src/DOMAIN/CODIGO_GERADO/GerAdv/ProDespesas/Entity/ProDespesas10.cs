using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBProDespesas : MenphisSI.GerAdv.DBProDespesas, IDBProDespesas
{
    public DBProDespesas() : base()
    {
    }

    public DBProDespesas(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBProDespesas(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBProDespesas(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBProDespesas(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}