using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBObjetos : MenphisSI.GerAdv.DBObjetos, IDBObjetos
{
    public DBObjetos() : base()
    {
    }

    public DBObjetos(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBObjetos(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBObjetos(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBObjetos(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}