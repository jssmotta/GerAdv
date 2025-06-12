using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBAreasJustica : MenphisSI.GerAdv.DBAreasJustica, IDBAreasJustica
{
    public DBAreasJustica() : base()
    {
    }

    public DBAreasJustica(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBAreasJustica(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBAreasJustica(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBAreasJustica(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}