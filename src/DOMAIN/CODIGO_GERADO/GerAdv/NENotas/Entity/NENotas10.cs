using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBNENotas : MenphisSI.GerAdv.DBNENotas, IDBNENotas
{
    public DBNENotas() : base()
    {
    }

    public DBNENotas(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBNENotas(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBNENotas(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBNENotas(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}