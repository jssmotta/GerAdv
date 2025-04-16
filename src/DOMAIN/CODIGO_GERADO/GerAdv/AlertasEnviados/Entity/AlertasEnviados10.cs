using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBAlertasEnviados : MenphisSI.GerAdv.DBAlertasEnviados, IDBAlertasEnviados
{
    public DBAlertasEnviados() : base()
    {
    }

    public DBAlertasEnviados(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBAlertasEnviados(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBAlertasEnviados(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBAlertasEnviados(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}