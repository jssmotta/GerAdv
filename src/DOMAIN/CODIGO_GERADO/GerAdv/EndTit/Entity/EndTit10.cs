using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBEndTit : MenphisSI.GerAdv.DBEndTit, IDBEndTit
{
    public DBEndTit() : base()
    {
    }

    public DBEndTit(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBEndTit(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBEndTit(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBEndTit(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}