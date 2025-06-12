using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBTipoProDesposito : MenphisSI.GerAdv.DBTipoProDesposito, IDBTipoProDesposito
{
    public DBTipoProDesposito() : base()
    {
    }

    public DBTipoProDesposito(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBTipoProDesposito(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBTipoProDesposito(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBTipoProDesposito(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}