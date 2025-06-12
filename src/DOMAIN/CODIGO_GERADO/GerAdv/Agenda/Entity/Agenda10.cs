using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBAgenda : MenphisSI.GerAdv.DBAgenda, IDBAgenda
{
    public DBAgenda() : base()
    {
    }

    public DBAgenda(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBAgenda(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBAgenda(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBAgenda(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}