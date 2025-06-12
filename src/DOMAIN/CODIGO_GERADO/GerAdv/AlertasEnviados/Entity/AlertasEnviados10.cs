using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBAlertasEnviados : MenphisSI.GerAdv.DBAlertasEnviados, IDBAlertasEnviados
{
    public DBAlertasEnviados() : base()
    {
    }

    public DBAlertasEnviados(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBAlertasEnviados(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBAlertasEnviados(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBAlertasEnviados(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}