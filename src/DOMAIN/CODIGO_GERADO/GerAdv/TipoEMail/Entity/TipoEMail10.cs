using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBTipoEMail : MenphisSI.GerAdv.DBTipoEMail, IDBTipoEMail
{
    public DBTipoEMail() : base()
    {
    }

    public DBTipoEMail(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBTipoEMail(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBTipoEMail(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBTipoEMail(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}