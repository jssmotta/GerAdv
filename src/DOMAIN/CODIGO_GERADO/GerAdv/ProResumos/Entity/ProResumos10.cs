using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBProResumos : MenphisSI.GerAdv.DBProResumos, IDBProResumos
{
    public DBProResumos() : base()
    {
    }

    public DBProResumos(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBProResumos(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBProResumos(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBProResumos(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}