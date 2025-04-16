using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBEMPClassRiscos : MenphisSI.GerAdv.DBEMPClassRiscos, IDBEMPClassRiscos
{
    public DBEMPClassRiscos() : base()
    {
    }

    public DBEMPClassRiscos(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBEMPClassRiscos(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBEMPClassRiscos(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBEMPClassRiscos(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}