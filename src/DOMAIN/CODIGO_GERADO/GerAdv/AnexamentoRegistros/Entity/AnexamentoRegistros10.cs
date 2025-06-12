using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBAnexamentoRegistros : MenphisSI.GerAdv.DBAnexamentoRegistros, IDBAnexamentoRegistros
{
    public DBAnexamentoRegistros() : base()
    {
    }

    public DBAnexamentoRegistros(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBAnexamentoRegistros(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBAnexamentoRegistros(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBAnexamentoRegistros(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}