using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBAlarmSMS : MenphisSI.GerAdv.DBAlarmSMS, IDBAlarmSMS
{
    public DBAlarmSMS() : base()
    {
    }

    public DBAlarmSMS(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBAlarmSMS(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBAlarmSMS(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBAlarmSMS(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}