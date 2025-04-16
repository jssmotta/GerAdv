using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBSMSAlice : MenphisSI.GerAdv.DBSMSAlice, IDBSMSAlice
{
    public DBSMSAlice() : base()
    {
    }

    public DBSMSAlice(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBSMSAlice(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBSMSAlice(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBSMSAlice(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}