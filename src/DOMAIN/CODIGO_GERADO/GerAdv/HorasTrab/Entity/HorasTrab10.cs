using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBHorasTrab : MenphisSI.GerAdv.DBHorasTrab, IDBHorasTrab
{
    public DBHorasTrab() : base()
    {
    }

    public DBHorasTrab(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBHorasTrab(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBHorasTrab(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBHorasTrab(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}