using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBJustica : MenphisSI.GerAdv.DBJustica, IDBJustica
{
    public DBJustica() : base()
    {
    }

    public DBJustica(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBJustica(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBJustica(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBJustica(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}