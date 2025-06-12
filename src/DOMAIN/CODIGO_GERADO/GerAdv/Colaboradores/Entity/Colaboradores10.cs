using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBColaboradores : MenphisSI.GerAdv.DBColaboradores, IDBColaboradores
{
    public DBColaboradores() : base()
    {
    }

    public DBColaboradores(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBColaboradores(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBColaboradores(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBColaboradores(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}