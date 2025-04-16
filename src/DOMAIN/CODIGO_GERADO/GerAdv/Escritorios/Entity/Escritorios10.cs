using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBEscritorios : MenphisSI.GerAdv.DBEscritorios, IDBEscritorios
{
    public DBEscritorios() : base()
    {
    }

    public DBEscritorios(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBEscritorios(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBEscritorios(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBEscritorios(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}