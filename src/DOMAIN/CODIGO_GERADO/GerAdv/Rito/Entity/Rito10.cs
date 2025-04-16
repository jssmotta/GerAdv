using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBRito : MenphisSI.GerAdv.DBRito, IDBRito
{
    public DBRito() : base()
    {
    }

    public DBRito(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBRito(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBRito(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBRito(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}