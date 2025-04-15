using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBCargos : MenphisSI.GerAdv.DBCargos, IDBCargos
{
    public DBCargos() : base()
    {
    }

    public DBCargos(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBCargos(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBCargos(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBCargos(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}