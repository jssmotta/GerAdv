using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBProProcuradores : MenphisSI.GerAdv.DBProProcuradores, IDBProProcuradores
{
    public DBProProcuradores() : base()
    {
    }

    public DBProProcuradores(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBProProcuradores(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBProProcuradores(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBProProcuradores(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}