using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBPenhora : MenphisSI.GerAdv.DBPenhora, IDBPenhora
{
    public DBPenhora() : base()
    {
    }

    public DBPenhora(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBPenhora(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBPenhora(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBPenhora(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}