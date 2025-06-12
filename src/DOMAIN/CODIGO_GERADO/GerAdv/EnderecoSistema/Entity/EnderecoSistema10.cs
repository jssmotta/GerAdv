using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBEnderecoSistema : MenphisSI.GerAdv.DBEnderecoSistema, IDBEnderecoSistema
{
    public DBEnderecoSistema() : base()
    {
    }

    public DBEnderecoSistema(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBEnderecoSistema(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBEnderecoSistema(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBEnderecoSistema(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}