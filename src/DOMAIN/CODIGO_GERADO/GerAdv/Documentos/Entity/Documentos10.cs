using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBDocumentos : MenphisSI.GerAdv.DBDocumentos, IDBDocumentos
{
    public DBDocumentos() : base()
    {
    }

    public DBDocumentos(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBDocumentos(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBDocumentos(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBDocumentos(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}