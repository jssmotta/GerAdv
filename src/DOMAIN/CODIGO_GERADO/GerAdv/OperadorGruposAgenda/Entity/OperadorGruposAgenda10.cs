using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBOperadorGruposAgenda : MenphisSI.GerAdv.DBOperadorGruposAgenda, IDBOperadorGruposAgenda
{
    public DBOperadorGruposAgenda() : base()
    {
    }

    public DBOperadorGruposAgenda(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBOperadorGruposAgenda(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBOperadorGruposAgenda(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBOperadorGruposAgenda(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}