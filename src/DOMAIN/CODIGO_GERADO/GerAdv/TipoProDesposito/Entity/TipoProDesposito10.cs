using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBTipoProDesposito : MenphisSI.GerAdv.DBTipoProDesposito, IDBTipoProDesposito
{
    public DBTipoProDesposito() : base()
    {
    }

    public DBTipoProDesposito(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBTipoProDesposito(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBTipoProDesposito(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBTipoProDesposito(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}