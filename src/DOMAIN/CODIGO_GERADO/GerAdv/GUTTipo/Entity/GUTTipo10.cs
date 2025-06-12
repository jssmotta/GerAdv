using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBGUTTipo : MenphisSI.GerAdv.DBGUTTipo, IDBGUTTipo
{
    public DBGUTTipo() : base()
    {
    }

    public DBGUTTipo(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBGUTTipo(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBGUTTipo(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBGUTTipo(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}