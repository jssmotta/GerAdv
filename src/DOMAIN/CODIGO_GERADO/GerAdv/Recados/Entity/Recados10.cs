using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBRecados : MenphisSI.GerAdv.DBRecados, IDBRecados
{
    public DBRecados() : base()
    {
    }

    public DBRecados(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBRecados(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBRecados(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBRecados(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}