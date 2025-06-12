using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBTipoEMail : MenphisSI.GerAdv.DBTipoEMail, IDBTipoEMail
{
    public DBTipoEMail() : base()
    {
    }

    public DBTipoEMail(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBTipoEMail(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBTipoEMail(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBTipoEMail(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}