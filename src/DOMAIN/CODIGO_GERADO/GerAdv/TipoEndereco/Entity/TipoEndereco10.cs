using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBTipoEndereco : MenphisSI.GerAdv.DBTipoEndereco, IDBTipoEndereco
{
    public DBTipoEndereco() : base()
    {
    }

    public DBTipoEndereco(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBTipoEndereco(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBTipoEndereco(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBTipoEndereco(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}