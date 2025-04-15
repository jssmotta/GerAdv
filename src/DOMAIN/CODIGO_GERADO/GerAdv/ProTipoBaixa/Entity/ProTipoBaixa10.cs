using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBProTipoBaixa : MenphisSI.GerAdv.DBProTipoBaixa, IDBProTipoBaixa
{
    public DBProTipoBaixa() : base()
    {
    }

    public DBProTipoBaixa(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBProTipoBaixa(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBProTipoBaixa(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBProTipoBaixa(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}