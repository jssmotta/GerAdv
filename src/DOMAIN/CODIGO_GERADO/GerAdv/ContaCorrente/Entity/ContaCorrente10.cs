using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBContaCorrente : MenphisSI.GerAdv.DBContaCorrente, IDBContaCorrente
{
    public DBContaCorrente() : base()
    {
    }

    public DBContaCorrente(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBContaCorrente(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBContaCorrente(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBContaCorrente(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}