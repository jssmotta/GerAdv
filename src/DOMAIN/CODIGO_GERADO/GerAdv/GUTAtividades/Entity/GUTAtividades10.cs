using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBGUTAtividades : MenphisSI.GerAdv.DBGUTAtividades, IDBGUTAtividades
{
    public DBGUTAtividades() : base()
    {
    }

    public DBGUTAtividades(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBGUTAtividades(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBGUTAtividades(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBGUTAtividades(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}