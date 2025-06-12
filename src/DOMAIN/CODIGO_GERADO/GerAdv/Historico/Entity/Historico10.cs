using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBHistorico : MenphisSI.GerAdv.DBHistorico, IDBHistorico
{
    public DBHistorico() : base()
    {
    }

    public DBHistorico(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBHistorico(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBHistorico(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBHistorico(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}