using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBTipoContatoCRM : MenphisSI.GerAdv.DBTipoContatoCRM, IDBTipoContatoCRM
{
    public DBTipoContatoCRM() : base()
    {
    }

    public DBTipoContatoCRM(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBTipoContatoCRM(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBTipoContatoCRM(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBTipoContatoCRM(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}