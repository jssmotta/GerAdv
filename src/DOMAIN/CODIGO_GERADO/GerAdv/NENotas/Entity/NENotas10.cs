using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBNENotas : MenphisSI.GerAdv.DBNENotas, IDBNENotas
{
    public DBNENotas() : base()
    {
    }

    public DBNENotas(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBNENotas(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBNENotas(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBNENotas(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}