using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBProResumos : MenphisSI.GerAdv.DBProResumos, IDBProResumos
{
    public DBProResumos() : base()
    {
    }

    public DBProResumos(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBProResumos(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBProResumos(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBProResumos(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}