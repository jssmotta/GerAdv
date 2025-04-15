using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBAlertas : MenphisSI.GerAdv.DBAlertas, IDBAlertas
{
    public DBAlertas() : base()
    {
    }

    public DBAlertas(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBAlertas(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBAlertas(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBAlertas(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}