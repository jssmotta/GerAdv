using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBGUTPeriodicidade : MenphisSI.GerAdv.DBGUTPeriodicidade, IDBGUTPeriodicidade
{
    public DBGUTPeriodicidade() : base()
    {
    }

    public DBGUTPeriodicidade(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBGUTPeriodicidade(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBGUTPeriodicidade(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBGUTPeriodicidade(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}