using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBEnquadramentoEmpresa : MenphisSI.GerAdv.DBEnquadramentoEmpresa, IDBEnquadramentoEmpresa
{
    public DBEnquadramentoEmpresa() : base()
    {
    }

    public DBEnquadramentoEmpresa(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBEnquadramentoEmpresa(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBEnquadramentoEmpresa(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBEnquadramentoEmpresa(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}