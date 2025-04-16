using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBOperadorEMailPopup : MenphisSI.GerAdv.DBOperadorEMailPopup, IDBOperadorEMailPopup
{
    public DBOperadorEMailPopup() : base()
    {
    }

    public DBOperadorEMailPopup(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBOperadorEMailPopup(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBOperadorEMailPopup(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBOperadorEMailPopup(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}