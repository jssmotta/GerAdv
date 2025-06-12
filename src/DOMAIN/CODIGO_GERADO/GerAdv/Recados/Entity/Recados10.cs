using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBRecados : MenphisSI.GerAdv.DBRecados, IDBRecados
{
    public DBRecados() : base()
    {
    }

    public DBRecados(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBRecados(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBRecados(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBRecados(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}