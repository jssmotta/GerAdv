using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBProTipoBaixa : MenphisSI.GerAdv.DBProTipoBaixa, IDBProTipoBaixa
{
    public DBProTipoBaixa() : base()
    {
    }

    public DBProTipoBaixa(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBProTipoBaixa(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBProTipoBaixa(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBProTipoBaixa(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}