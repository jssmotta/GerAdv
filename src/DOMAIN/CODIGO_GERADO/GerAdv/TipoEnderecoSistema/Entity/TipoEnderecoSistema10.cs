using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBTipoEnderecoSistema : MenphisSI.GerAdv.DBTipoEnderecoSistema, IDBTipoEnderecoSistema
{
    public DBTipoEnderecoSistema() : base()
    {
    }

    public DBTipoEnderecoSistema(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBTipoEnderecoSistema(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBTipoEnderecoSistema(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBTipoEnderecoSistema(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}