using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBTipoStatusBiu : MenphisSI.GerAdv.DBTipoStatusBiu, IDBTipoStatusBiu
{
    public DBTipoStatusBiu() : base()
    {
    }

    public DBTipoStatusBiu(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBTipoStatusBiu(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBTipoStatusBiu(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBTipoStatusBiu(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}