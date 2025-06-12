using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBAuditor4K : MenphisSI.GerAdv.DBAuditor4K, IDBAuditor4K
{
    public DBAuditor4K() : base()
    {
    }

    public DBAuditor4K(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBAuditor4K(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBAuditor4K(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBAuditor4K(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}