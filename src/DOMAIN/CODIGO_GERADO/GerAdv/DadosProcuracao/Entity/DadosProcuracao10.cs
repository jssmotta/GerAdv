using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBDadosProcuracao : MenphisSI.GerAdv.DBDadosProcuracao, IDBDadosProcuracao
{
    public DBDadosProcuracao() : base()
    {
    }

    public DBDadosProcuracao(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBDadosProcuracao(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBDadosProcuracao(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBDadosProcuracao(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}