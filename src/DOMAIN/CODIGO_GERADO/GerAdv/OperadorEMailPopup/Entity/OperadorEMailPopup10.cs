using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBOperadorEMailPopup : MenphisSI.GerAdv.DBOperadorEMailPopup, IDBOperadorEMailPopup
{
    public DBOperadorEMailPopup() : base()
    {
    }

    public DBOperadorEMailPopup(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBOperadorEMailPopup(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBOperadorEMailPopup(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBOperadorEMailPopup(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}