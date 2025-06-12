using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBAndamentosMD : MenphisSI.GerAdv.DBAndamentosMD, IDBAndamentosMD
{
    public DBAndamentosMD() : base()
    {
    }

    public DBAndamentosMD(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBAndamentosMD(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBAndamentosMD(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBAndamentosMD(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}