using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBAnexamentoRegistros : MenphisSI.GerAdv.DBAnexamentoRegistros, IDBAnexamentoRegistros
{
    public DBAnexamentoRegistros() : base()
    {
    }

    public DBAnexamentoRegistros(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBAnexamentoRegistros(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBAnexamentoRegistros(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBAnexamentoRegistros(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}