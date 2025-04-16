using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBStatusAndamento : MenphisSI.GerAdv.DBStatusAndamento, IDBStatusAndamento
{
    public DBStatusAndamento() : base()
    {
    }

    public DBStatusAndamento(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBStatusAndamento(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBStatusAndamento(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBStatusAndamento(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}