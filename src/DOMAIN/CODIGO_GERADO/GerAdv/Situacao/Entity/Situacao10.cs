using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBSituacao : MenphisSI.GerAdv.DBSituacao, IDBSituacao
{
    public DBSituacao() : base()
    {
    }

    public DBSituacao(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBSituacao(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBSituacao(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBSituacao(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}