using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBTipoEndereco : MenphisSI.GerAdv.DBTipoEndereco, IDBTipoEndereco
{
    public DBTipoEndereco() : base()
    {
    }

    public DBTipoEndereco(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBTipoEndereco(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBTipoEndereco(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBTipoEndereco(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}