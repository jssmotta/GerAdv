using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBTipoValorProcesso : MenphisSI.GerAdv.DBTipoValorProcesso, IDBTipoValorProcesso
{
    public DBTipoValorProcesso() : base()
    {
    }

    public DBTipoValorProcesso(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBTipoValorProcesso(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBTipoValorProcesso(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBTipoValorProcesso(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}