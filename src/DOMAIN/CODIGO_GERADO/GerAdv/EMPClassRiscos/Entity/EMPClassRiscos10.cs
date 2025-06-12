using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBEMPClassRiscos : MenphisSI.GerAdv.DBEMPClassRiscos, IDBEMPClassRiscos
{
    public DBEMPClassRiscos() : base()
    {
    }

    public DBEMPClassRiscos(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBEMPClassRiscos(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBEMPClassRiscos(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBEMPClassRiscos(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}