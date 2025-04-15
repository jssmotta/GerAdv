using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBOperadorGrupo : MenphisSI.GerAdv.DBOperadorGrupo, IDBOperadorGrupo
{
    public DBOperadorGrupo() : base()
    {
    }

    public DBOperadorGrupo(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBOperadorGrupo(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBOperadorGrupo(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBOperadorGrupo(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}