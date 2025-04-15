using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBOperadorGrupos : MenphisSI.GerAdv.DBOperadorGrupos, IDBOperadorGrupos
{
    public DBOperadorGrupos() : base()
    {
    }

    public DBOperadorGrupos(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBOperadorGrupos(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBOperadorGrupos(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBOperadorGrupos(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}