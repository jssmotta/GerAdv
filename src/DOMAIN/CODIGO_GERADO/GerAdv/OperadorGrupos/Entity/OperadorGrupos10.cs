using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBOperadorGrupos : MenphisSI.GerAdv.DBOperadorGrupos, IDBOperadorGrupos
{
    public DBOperadorGrupos() : base()
    {
    }

    public DBOperadorGrupos(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBOperadorGrupos(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBOperadorGrupos(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBOperadorGrupos(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}