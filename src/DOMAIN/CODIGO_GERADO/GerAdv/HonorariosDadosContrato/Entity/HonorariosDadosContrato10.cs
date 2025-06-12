using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBHonorariosDadosContrato : MenphisSI.GerAdv.DBHonorariosDadosContrato, IDBHonorariosDadosContrato
{
    public DBHonorariosDadosContrato() : base()
    {
    }

    public DBHonorariosDadosContrato(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBHonorariosDadosContrato(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBHonorariosDadosContrato(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBHonorariosDadosContrato(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}