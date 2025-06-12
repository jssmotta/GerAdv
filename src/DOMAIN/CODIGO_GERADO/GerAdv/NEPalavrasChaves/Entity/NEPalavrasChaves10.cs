using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBNEPalavrasChaves : MenphisSI.GerAdv.DBNEPalavrasChaves, IDBNEPalavrasChaves
{
    public DBNEPalavrasChaves() : base()
    {
    }

    public DBNEPalavrasChaves(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBNEPalavrasChaves(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBNEPalavrasChaves(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBNEPalavrasChaves(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}