using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBColaboradores : MenphisSI.GerAdv.DBColaboradores, IDBColaboradores
{
    public DBColaboradores() : base()
    {
    }

    public DBColaboradores(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBColaboradores(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBColaboradores(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBColaboradores(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}