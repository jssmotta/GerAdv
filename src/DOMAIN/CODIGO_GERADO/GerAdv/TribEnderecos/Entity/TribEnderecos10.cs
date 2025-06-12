using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBTribEnderecos : MenphisSI.GerAdv.DBTribEnderecos, IDBTribEnderecos
{
    public DBTribEnderecos() : base()
    {
    }

    public DBTribEnderecos(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBTribEnderecos(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBTribEnderecos(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBTribEnderecos(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}