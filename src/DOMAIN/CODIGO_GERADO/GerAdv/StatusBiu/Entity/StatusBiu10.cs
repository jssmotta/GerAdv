using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBStatusBiu : MenphisSI.GerAdv.DBStatusBiu, IDBStatusBiu
{
    public DBStatusBiu() : base()
    {
    }

    public DBStatusBiu(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBStatusBiu(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBStatusBiu(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBStatusBiu(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}