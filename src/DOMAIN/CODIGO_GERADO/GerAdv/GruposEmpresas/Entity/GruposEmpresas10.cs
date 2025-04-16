using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBGruposEmpresas : MenphisSI.GerAdv.DBGruposEmpresas, IDBGruposEmpresas
{
    public DBGruposEmpresas() : base()
    {
    }

    public DBGruposEmpresas(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBGruposEmpresas(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBGruposEmpresas(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBGruposEmpresas(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}