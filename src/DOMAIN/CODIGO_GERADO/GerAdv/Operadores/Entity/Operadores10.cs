using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBOperadores : MenphisSI.GerAdv.DBOperadores, IDBOperadores
{
    public DBOperadores() : base()
    {
    }

    public DBOperadores(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBOperadores(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBOperadores(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBOperadores(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}