using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBViaRecebimento : MenphisSI.GerAdv.DBViaRecebimento, IDBViaRecebimento
{
    public DBViaRecebimento() : base()
    {
    }

    public DBViaRecebimento(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBViaRecebimento(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBViaRecebimento(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBViaRecebimento(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}