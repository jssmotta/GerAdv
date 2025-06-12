using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBTipoOrigemSucumbencia : MenphisSI.GerAdv.DBTipoOrigemSucumbencia, IDBTipoOrigemSucumbencia
{
    public DBTipoOrigemSucumbencia() : base()
    {
    }

    public DBTipoOrigemSucumbencia(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBTipoOrigemSucumbencia(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBTipoOrigemSucumbencia(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBTipoOrigemSucumbencia(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}