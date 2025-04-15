using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBPrepostos : MenphisSI.GerAdv.DBPrepostos, IDBPrepostos
{
    public DBPrepostos() : base()
    {
    }

    public DBPrepostos(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBPrepostos(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBPrepostos(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBPrepostos(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}