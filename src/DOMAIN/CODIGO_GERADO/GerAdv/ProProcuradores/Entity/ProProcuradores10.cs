using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBProProcuradores : MenphisSI.GerAdv.DBProProcuradores, IDBProProcuradores
{
    public DBProProcuradores() : base()
    {
    }

    public DBProProcuradores(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBProProcuradores(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBProProcuradores(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBProProcuradores(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}