using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBProSucumbencia : MenphisSI.GerAdv.DBProSucumbencia, IDBProSucumbencia
{
    public DBProSucumbencia() : base()
    {
    }

    public DBProSucumbencia(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBProSucumbencia(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBProSucumbencia(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBProSucumbencia(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}