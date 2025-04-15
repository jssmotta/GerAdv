using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBPontoVirtualAcessos : MenphisSI.GerAdv.DBPontoVirtualAcessos, IDBPontoVirtualAcessos
{
    public DBPontoVirtualAcessos() : base()
    {
    }

    public DBPontoVirtualAcessos(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBPontoVirtualAcessos(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBPontoVirtualAcessos(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBPontoVirtualAcessos(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}