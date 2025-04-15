using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBPrecatoria : MenphisSI.GerAdv.DBPrecatoria, IDBPrecatoria
{
    public DBPrecatoria() : base()
    {
    }

    public DBPrecatoria(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBPrecatoria(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBPrecatoria(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBPrecatoria(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}