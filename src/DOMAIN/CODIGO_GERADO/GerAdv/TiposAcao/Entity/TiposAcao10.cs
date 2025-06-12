using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBTiposAcao : MenphisSI.GerAdv.DBTiposAcao, IDBTiposAcao
{
    public DBTiposAcao() : base()
    {
    }

    public DBTiposAcao(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBTiposAcao(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBTiposAcao(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBTiposAcao(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}