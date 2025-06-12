using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBForo : MenphisSI.GerAdv.DBForo, IDBForo
{
    public DBForo() : base()
    {
    }

    public DBForo(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBForo(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBForo(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBForo(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}