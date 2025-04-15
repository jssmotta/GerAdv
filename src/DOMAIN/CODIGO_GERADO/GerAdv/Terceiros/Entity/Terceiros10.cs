using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBTerceiros : MenphisSI.GerAdv.DBTerceiros, IDBTerceiros
{
    public DBTerceiros() : base()
    {
    }

    public DBTerceiros(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBTerceiros(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBTerceiros(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBTerceiros(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}