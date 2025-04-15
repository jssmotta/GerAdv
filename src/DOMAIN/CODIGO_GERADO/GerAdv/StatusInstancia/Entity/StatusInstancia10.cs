using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBStatusInstancia : MenphisSI.GerAdv.DBStatusInstancia, IDBStatusInstancia
{
    public DBStatusInstancia() : base()
    {
    }

    public DBStatusInstancia(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBStatusInstancia(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBStatusInstancia(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBStatusInstancia(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}