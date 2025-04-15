using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBProcessos : MenphisSI.GerAdv.DBProcessos, IDBProcessos
{
    public DBProcessos() : base()
    {
    }

    public DBProcessos(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBProcessos(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBProcessos(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBProcessos(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}