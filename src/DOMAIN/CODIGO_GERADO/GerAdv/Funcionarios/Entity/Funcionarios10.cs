using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBFuncionarios : MenphisSI.GerAdv.DBFuncionarios, IDBFuncionarios
{
    public DBFuncionarios() : base()
    {
    }

    public DBFuncionarios(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBFuncionarios(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBFuncionarios(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBFuncionarios(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}