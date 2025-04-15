using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBParteOponente : MenphisSI.GerAdv.DBParteOponente, IDBParteOponente
{
    public DBParteOponente() : base()
    {
    }

    public DBParteOponente(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBParteOponente(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBParteOponente(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBParteOponente(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}