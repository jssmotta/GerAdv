using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBEnderecos : MenphisSI.GerAdv.DBEnderecos, IDBEnderecos
{
    public DBEnderecos() : base()
    {
    }

    public DBEnderecos(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBEnderecos(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBEnderecos(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBEnderecos(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}