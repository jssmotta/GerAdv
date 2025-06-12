using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBProDepositos : MenphisSI.GerAdv.DBProDepositos, IDBProDepositos
{
    public DBProDepositos() : base()
    {
    }

    public DBProDepositos(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBProDepositos(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBProDepositos(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBProDepositos(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}