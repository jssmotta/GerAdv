using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBRamal : MenphisSI.GerAdv.DBRamal, IDBRamal
{
    public DBRamal() : base()
    {
    }

    public DBRamal(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBRamal(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBRamal(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBRamal(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}