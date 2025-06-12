using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBNECompromissos : MenphisSI.GerAdv.DBNECompromissos, IDBNECompromissos
{
    public DBNECompromissos() : base()
    {
    }

    public DBNECompromissos(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBNECompromissos(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBNECompromissos(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBNECompromissos(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}