using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBTipoValorProcesso : MenphisSI.GerAdv.DBTipoValorProcesso, IDBTipoValorProcesso
{
    public DBTipoValorProcesso() : base()
    {
    }

    public DBTipoValorProcesso(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBTipoValorProcesso(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBTipoValorProcesso(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBTipoValorProcesso(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}