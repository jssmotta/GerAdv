using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBPontoVirtual : MenphisSI.GerAdv.DBPontoVirtual, IDBPontoVirtual
{
    public DBPontoVirtual() : base()
    {
    }

    public DBPontoVirtual(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBPontoVirtual(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBPontoVirtual(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBPontoVirtual(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}