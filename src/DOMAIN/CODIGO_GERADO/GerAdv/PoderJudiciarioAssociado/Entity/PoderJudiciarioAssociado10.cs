using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBPoderJudiciarioAssociado : MenphisSI.GerAdv.DBPoderJudiciarioAssociado, IDBPoderJudiciarioAssociado
{
    public DBPoderJudiciarioAssociado() : base()
    {
    }

    public DBPoderJudiciarioAssociado(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBPoderJudiciarioAssociado(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBPoderJudiciarioAssociado(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBPoderJudiciarioAssociado(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}