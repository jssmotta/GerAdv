using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBServicos : MenphisSI.GerAdv.DBServicos, IDBServicos
{
    public DBServicos() : base()
    {
    }

    public DBServicos(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBServicos(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBServicos(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBServicos(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}