using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBTribunal : MenphisSI.GerAdv.DBTribunal, IDBTribunal
{
    public DBTribunal() : base()
    {
    }

    public DBTribunal(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBTribunal(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBTribunal(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBTribunal(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}