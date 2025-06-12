using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBTipoCompromisso : MenphisSI.GerAdv.DBTipoCompromisso, IDBTipoCompromisso
{
    public DBTipoCompromisso() : base()
    {
    }

    public DBTipoCompromisso(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBTipoCompromisso(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBTipoCompromisso(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBTipoCompromisso(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}