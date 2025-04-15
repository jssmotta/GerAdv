using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBTipoModeloDocumento : MenphisSI.GerAdv.DBTipoModeloDocumento, IDBTipoModeloDocumento
{
    public DBTipoModeloDocumento() : base()
    {
    }

    public DBTipoModeloDocumento(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBTipoModeloDocumento(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBTipoModeloDocumento(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBTipoModeloDocumento(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}