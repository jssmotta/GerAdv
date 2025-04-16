using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBAreasJustica : MenphisSI.GerAdv.DBAreasJustica, IDBAreasJustica
{
    public DBAreasJustica() : base()
    {
    }

    public DBAreasJustica(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBAreasJustica(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBAreasJustica(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBAreasJustica(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}