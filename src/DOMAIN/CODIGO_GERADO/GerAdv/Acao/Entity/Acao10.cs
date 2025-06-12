using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBAcao : MenphisSI.GerAdv.DBAcao, IDBAcao
{
    public DBAcao() : base()
    {
    }

    public DBAcao(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBAcao(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBAcao(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBAcao(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}