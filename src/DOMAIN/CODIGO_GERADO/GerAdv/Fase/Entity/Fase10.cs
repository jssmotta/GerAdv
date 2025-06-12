using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBFase : MenphisSI.GerAdv.DBFase, IDBFase
{
    public DBFase() : base()
    {
    }

    public DBFase(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBFase(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBFase(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBFase(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}