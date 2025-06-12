using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBFuncionarios : MenphisSI.GerAdv.DBFuncionarios, IDBFuncionarios
{
    public DBFuncionarios() : base()
    {
    }

    public DBFuncionarios(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBFuncionarios(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBFuncionarios(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBFuncionarios(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}