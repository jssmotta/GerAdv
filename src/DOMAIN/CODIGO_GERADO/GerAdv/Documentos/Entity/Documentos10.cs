using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBDocumentos : MenphisSI.GerAdv.DBDocumentos, IDBDocumentos
{
    public DBDocumentos() : base()
    {
    }

    public DBDocumentos(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBDocumentos(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBDocumentos(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBDocumentos(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}