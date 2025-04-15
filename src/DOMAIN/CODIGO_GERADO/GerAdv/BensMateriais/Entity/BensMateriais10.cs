using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBBensMateriais : MenphisSI.GerAdv.DBBensMateriais, IDBBensMateriais
{
    public DBBensMateriais() : base()
    {
    }

    public DBBensMateriais(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBBensMateriais(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBBensMateriais(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBBensMateriais(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}