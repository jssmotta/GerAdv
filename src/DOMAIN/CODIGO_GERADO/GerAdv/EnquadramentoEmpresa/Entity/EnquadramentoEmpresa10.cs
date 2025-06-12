using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBEnquadramentoEmpresa : MenphisSI.GerAdv.DBEnquadramentoEmpresa, IDBEnquadramentoEmpresa
{
    public DBEnquadramentoEmpresa() : base()
    {
    }

    public DBEnquadramentoEmpresa(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBEnquadramentoEmpresa(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBEnquadramentoEmpresa(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBEnquadramentoEmpresa(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}