using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBProcessosParados : MenphisSI.GerAdv.DBProcessosParados, IDBProcessosParados
{
    public DBProcessosParados() : base()
    {
    }

    public DBProcessosParados(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBProcessosParados(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBProcessosParados(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBProcessosParados(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}