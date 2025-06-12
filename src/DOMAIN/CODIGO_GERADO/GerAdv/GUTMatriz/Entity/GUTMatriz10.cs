using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBGUTMatriz : MenphisSI.GerAdv.DBGUTMatriz, IDBGUTMatriz
{
    public DBGUTMatriz() : base()
    {
    }

    public DBGUTMatriz(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBGUTMatriz(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBGUTMatriz(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBGUTMatriz(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}