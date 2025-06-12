using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBOperadorGrupo : MenphisSI.GerAdv.DBOperadorGrupo, IDBOperadorGrupo
{
    public DBOperadorGrupo() : base()
    {
    }

    public DBOperadorGrupo(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBOperadorGrupo(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBOperadorGrupo(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBOperadorGrupo(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}