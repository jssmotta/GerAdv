using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBCidade : MenphisSI.GerAdv.DBCidade, IDBCidade
{
    public DBCidade() : base()
    {
    }

    public DBCidade(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBCidade(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBCidade(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBCidade(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}