using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBPosicaoOutrasPartes : MenphisSI.GerAdv.DBPosicaoOutrasPartes, IDBPosicaoOutrasPartes
{
    public DBPosicaoOutrasPartes() : base()
    {
    }

    public DBPosicaoOutrasPartes(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBPosicaoOutrasPartes(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBPosicaoOutrasPartes(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBPosicaoOutrasPartes(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}