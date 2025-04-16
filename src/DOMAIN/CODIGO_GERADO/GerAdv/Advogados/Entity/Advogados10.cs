using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBAdvogados : MenphisSI.GerAdv.DBAdvogados, IDBAdvogados
{
    public DBAdvogados() : base()
    {
    }

    public DBAdvogados(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBAdvogados(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBAdvogados(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBAdvogados(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}