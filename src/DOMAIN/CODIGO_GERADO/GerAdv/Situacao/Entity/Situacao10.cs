using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBSituacao : MenphisSI.GerAdv.DBSituacao, IDBSituacao
{
    public DBSituacao() : base()
    {
    }

    public DBSituacao(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBSituacao(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBSituacao(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBSituacao(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}