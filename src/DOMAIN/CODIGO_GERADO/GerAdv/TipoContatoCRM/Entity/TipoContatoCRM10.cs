using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBTipoContatoCRM : MenphisSI.GerAdv.DBTipoContatoCRM, IDBTipoContatoCRM
{
    public DBTipoContatoCRM() : base()
    {
    }

    public DBTipoContatoCRM(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBTipoContatoCRM(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBTipoContatoCRM(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBTipoContatoCRM(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}