using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBRamal : MenphisSI.GerAdv.DBRamal, IDBRamal
{
    public DBRamal() : base()
    {
    }

    public DBRamal(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBRamal(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBRamal(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBRamal(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}