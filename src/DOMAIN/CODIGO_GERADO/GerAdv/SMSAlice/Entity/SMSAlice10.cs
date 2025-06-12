using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBSMSAlice : MenphisSI.GerAdv.DBSMSAlice, IDBSMSAlice
{
    public DBSMSAlice() : base()
    {
    }

    public DBSMSAlice(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBSMSAlice(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBSMSAlice(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBSMSAlice(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}