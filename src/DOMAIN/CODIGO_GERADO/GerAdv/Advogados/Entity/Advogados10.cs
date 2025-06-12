using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBAdvogados : MenphisSI.GerAdv.DBAdvogados, IDBAdvogados
{
    public DBAdvogados() : base()
    {
    }

    public DBAdvogados(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBAdvogados(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBAdvogados(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBAdvogados(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}