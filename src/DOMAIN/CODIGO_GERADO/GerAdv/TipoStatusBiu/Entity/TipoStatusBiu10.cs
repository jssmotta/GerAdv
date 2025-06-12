using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBTipoStatusBiu : MenphisSI.GerAdv.DBTipoStatusBiu, IDBTipoStatusBiu
{
    public DBTipoStatusBiu() : base()
    {
    }

    public DBTipoStatusBiu(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBTipoStatusBiu(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBTipoStatusBiu(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBTipoStatusBiu(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}