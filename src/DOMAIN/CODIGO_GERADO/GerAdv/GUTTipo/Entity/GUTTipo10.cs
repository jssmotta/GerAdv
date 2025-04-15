using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBGUTTipo : MenphisSI.GerAdv.DBGUTTipo, IDBGUTTipo
{
    public DBGUTTipo() : base()
    {
    }

    public DBGUTTipo(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBGUTTipo(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBGUTTipo(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBGUTTipo(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}