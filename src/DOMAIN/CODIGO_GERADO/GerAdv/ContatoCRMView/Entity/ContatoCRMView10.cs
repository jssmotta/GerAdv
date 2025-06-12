using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBContatoCRMView : MenphisSI.GerAdv.DBContatoCRMView, IDBContatoCRMView
{
    public DBContatoCRMView() : base()
    {
    }

    public DBContatoCRMView(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBContatoCRMView(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBContatoCRMView(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBContatoCRMView(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}