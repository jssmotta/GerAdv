using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBTipoRecurso : MenphisSI.GerAdv.DBTipoRecurso, IDBTipoRecurso
{
    public DBTipoRecurso() : base()
    {
    }

    public DBTipoRecurso(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBTipoRecurso(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBTipoRecurso(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBTipoRecurso(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}