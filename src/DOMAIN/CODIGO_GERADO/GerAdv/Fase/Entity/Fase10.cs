using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBFase : MenphisSI.GerAdv.DBFase, IDBFase
{
    public DBFase() : base()
    {
    }

    public DBFase(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBFase(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBFase(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBFase(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}