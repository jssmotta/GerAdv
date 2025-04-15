using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBSetor : MenphisSI.GerAdv.DBSetor, IDBSetor
{
    public DBSetor() : base()
    {
    }

    public DBSetor(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBSetor(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBSetor(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBSetor(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}