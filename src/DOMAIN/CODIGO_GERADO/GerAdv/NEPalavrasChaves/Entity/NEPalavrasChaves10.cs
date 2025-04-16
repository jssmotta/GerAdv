using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBNEPalavrasChaves : MenphisSI.GerAdv.DBNEPalavrasChaves, IDBNEPalavrasChaves
{
    public DBNEPalavrasChaves() : base()
    {
    }

    public DBNEPalavrasChaves(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBNEPalavrasChaves(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBNEPalavrasChaves(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBNEPalavrasChaves(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}