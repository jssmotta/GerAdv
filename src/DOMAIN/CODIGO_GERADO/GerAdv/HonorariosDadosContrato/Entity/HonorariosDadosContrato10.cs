using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBHonorariosDadosContrato : MenphisSI.GerAdv.DBHonorariosDadosContrato, IDBHonorariosDadosContrato
{
    public DBHonorariosDadosContrato() : base()
    {
    }

    public DBHonorariosDadosContrato(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBHonorariosDadosContrato(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBHonorariosDadosContrato(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBHonorariosDadosContrato(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}