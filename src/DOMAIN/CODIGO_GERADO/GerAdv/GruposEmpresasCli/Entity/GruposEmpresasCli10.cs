using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBGruposEmpresasCli : MenphisSI.GerAdv.DBGruposEmpresasCli, IDBGruposEmpresasCli
{
    public DBGruposEmpresasCli() : base()
    {
    }

    public DBGruposEmpresasCli(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBGruposEmpresasCli(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBGruposEmpresasCli(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBGruposEmpresasCli(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}