using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBContratos : MenphisSI.GerAdv.DBContratos, IDBContratos
{
    public DBContratos() : base()
    {
    }

    public DBContratos(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBContratos(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBContratos(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBContratos(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}