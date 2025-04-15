using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBHorasTrab : MenphisSI.GerAdv.DBHorasTrab, IDBHorasTrab
{
    public DBHorasTrab() : base()
    {
    }

    public DBHorasTrab(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBHorasTrab(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBHorasTrab(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBHorasTrab(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}