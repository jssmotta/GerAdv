using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBOperador : MenphisSI.GerAdv.DBOperador, IDBOperador
{
    public DBOperador() : base()
    {
    }

    public DBOperador(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBOperador(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBOperador(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBOperador(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}