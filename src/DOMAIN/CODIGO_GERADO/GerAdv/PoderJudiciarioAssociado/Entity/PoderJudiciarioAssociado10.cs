using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBPoderJudiciarioAssociado : MenphisSI.GerAdv.DBPoderJudiciarioAssociado, IDBPoderJudiciarioAssociado
{
    public DBPoderJudiciarioAssociado() : base()
    {
    }

    public DBPoderJudiciarioAssociado(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBPoderJudiciarioAssociado(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBPoderJudiciarioAssociado(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBPoderJudiciarioAssociado(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}