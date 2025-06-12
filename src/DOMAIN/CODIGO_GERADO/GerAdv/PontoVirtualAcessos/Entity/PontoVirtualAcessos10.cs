using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBPontoVirtualAcessos : MenphisSI.GerAdv.DBPontoVirtualAcessos, IDBPontoVirtualAcessos
{
    public DBPontoVirtualAcessos() : base()
    {
    }

    public DBPontoVirtualAcessos(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBPontoVirtualAcessos(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBPontoVirtualAcessos(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBPontoVirtualAcessos(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}