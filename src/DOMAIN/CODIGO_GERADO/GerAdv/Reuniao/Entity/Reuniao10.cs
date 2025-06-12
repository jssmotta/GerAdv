using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBReuniao : MenphisSI.GerAdv.DBReuniao, IDBReuniao
{
    public DBReuniao() : base()
    {
    }

    public DBReuniao(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBReuniao(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBReuniao(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBReuniao(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}