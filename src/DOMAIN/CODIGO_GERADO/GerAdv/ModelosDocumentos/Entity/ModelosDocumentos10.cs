using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBModelosDocumentos : MenphisSI.GerAdv.DBModelosDocumentos, IDBModelosDocumentos
{
    public DBModelosDocumentos() : base()
    {
    }

    public DBModelosDocumentos(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBModelosDocumentos(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBModelosDocumentos(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBModelosDocumentos(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}