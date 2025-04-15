using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBProCDA : MenphisSI.GerAdv.DBProCDA, IDBProCDA
{
    public DBProCDA() : base()
    {
    }

    public DBProCDA(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBProCDA(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBProCDA(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBProCDA(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}