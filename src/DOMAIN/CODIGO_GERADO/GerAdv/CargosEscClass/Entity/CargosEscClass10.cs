using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBCargosEscClass : MenphisSI.GerAdv.DBCargosEscClass, IDBCargosEscClass
{
    public DBCargosEscClass() : base()
    {
    }

    public DBCargosEscClass(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBCargosEscClass(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBCargosEscClass(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBCargosEscClass(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}