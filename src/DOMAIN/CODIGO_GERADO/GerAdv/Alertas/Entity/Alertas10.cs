using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBAlertas : MenphisSI.GerAdv.DBAlertas, IDBAlertas
{
    public DBAlertas() : base()
    {
    }

    public DBAlertas(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBAlertas(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBAlertas(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBAlertas(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}