using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBTipoEnderecoSistema : MenphisSI.GerAdv.DBTipoEnderecoSistema, IDBTipoEnderecoSistema
{
    public DBTipoEnderecoSistema() : base()
    {
    }

    public DBTipoEnderecoSistema(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBTipoEnderecoSistema(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBTipoEnderecoSistema(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBTipoEnderecoSistema(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}