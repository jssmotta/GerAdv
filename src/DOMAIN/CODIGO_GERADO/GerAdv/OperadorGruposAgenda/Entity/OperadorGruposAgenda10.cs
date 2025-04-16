using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBOperadorGruposAgenda : MenphisSI.GerAdv.DBOperadorGruposAgenda, IDBOperadorGruposAgenda
{
    public DBOperadorGruposAgenda() : base()
    {
    }

    public DBOperadorGruposAgenda(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBOperadorGruposAgenda(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBOperadorGruposAgenda(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBOperadorGruposAgenda(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}