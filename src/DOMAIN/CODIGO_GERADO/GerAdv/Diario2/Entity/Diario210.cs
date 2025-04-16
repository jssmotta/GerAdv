using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBDiario2 : MenphisSI.GerAdv.DBDiario2, IDBDiario2
{
    public DBDiario2() : base()
    {
    }

    public DBDiario2(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBDiario2(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBDiario2(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBDiario2(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}