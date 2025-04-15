using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBAtividades : MenphisSI.GerAdv.DBAtividades, IDBAtividades
{
    public DBAtividades() : base()
    {
    }

    public DBAtividades(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBAtividades(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBAtividades(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBAtividades(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}