using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBContatoCRMOperador : MenphisSI.GerAdv.DBContatoCRMOperador, IDBContatoCRMOperador
{
    public DBContatoCRMOperador() : base()
    {
    }

    public DBContatoCRMOperador(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBContatoCRMOperador(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBContatoCRMOperador(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBContatoCRMOperador(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}