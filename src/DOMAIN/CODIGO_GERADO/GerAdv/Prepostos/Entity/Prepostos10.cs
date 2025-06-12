using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBPrepostos : MenphisSI.GerAdv.DBPrepostos, IDBPrepostos
{
    public DBPrepostos() : base()
    {
    }

    public DBPrepostos(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBPrepostos(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBPrepostos(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBPrepostos(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}