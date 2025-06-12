using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBGUTPeriodicidade : MenphisSI.GerAdv.DBGUTPeriodicidade, IDBGUTPeriodicidade
{
    public DBGUTPeriodicidade() : base()
    {
    }

    public DBGUTPeriodicidade(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBGUTPeriodicidade(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBGUTPeriodicidade(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBGUTPeriodicidade(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}