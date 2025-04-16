using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBPosicaoOutrasPartes : MenphisSI.GerAdv.DBPosicaoOutrasPartes, IDBPosicaoOutrasPartes
{
    public DBPosicaoOutrasPartes() : base()
    {
    }

    public DBPosicaoOutrasPartes(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBPosicaoOutrasPartes(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBPosicaoOutrasPartes(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBPosicaoOutrasPartes(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}