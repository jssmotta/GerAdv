using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBNECompromissos : MenphisSI.GerAdv.DBNECompromissos, IDBNECompromissos
{
    public DBNECompromissos() : base()
    {
    }

    public DBNECompromissos(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBNECompromissos(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBNECompromissos(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBNECompromissos(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}