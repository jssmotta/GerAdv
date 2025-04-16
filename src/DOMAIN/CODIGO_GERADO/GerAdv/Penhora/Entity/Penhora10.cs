using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBPenhora : MenphisSI.GerAdv.DBPenhora, IDBPenhora
{
    public DBPenhora() : base()
    {
    }

    public DBPenhora(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBPenhora(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBPenhora(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBPenhora(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}