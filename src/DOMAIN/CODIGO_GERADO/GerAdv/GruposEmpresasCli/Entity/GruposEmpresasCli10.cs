using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBGruposEmpresasCli : MenphisSI.GerAdv.DBGruposEmpresasCli, IDBGruposEmpresasCli
{
    public DBGruposEmpresasCli() : base()
    {
    }

    public DBGruposEmpresasCli(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBGruposEmpresasCli(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBGruposEmpresasCli(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBGruposEmpresasCli(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}