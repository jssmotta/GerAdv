using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBTipoOrigemSucumbencia : MenphisSI.GerAdv.DBTipoOrigemSucumbencia, IDBTipoOrigemSucumbencia
{
    public DBTipoOrigemSucumbencia() : base()
    {
    }

    public DBTipoOrigemSucumbencia(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBTipoOrigemSucumbencia(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBTipoOrigemSucumbencia(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBTipoOrigemSucumbencia(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}