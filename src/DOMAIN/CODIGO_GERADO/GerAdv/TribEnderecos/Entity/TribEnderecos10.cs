using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBTribEnderecos : MenphisSI.GerAdv.DBTribEnderecos, IDBTribEnderecos
{
    public DBTribEnderecos() : base()
    {
    }

    public DBTribEnderecos(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBTribEnderecos(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBTribEnderecos(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBTribEnderecos(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}