using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBContatoCRMOperador : MenphisSI.GerAdv.DBContatoCRMOperador, IDBContatoCRMOperador
{
    public DBContatoCRMOperador() : base()
    {
    }

    public DBContatoCRMOperador(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBContatoCRMOperador(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBContatoCRMOperador(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBContatoCRMOperador(SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(oCnn, fullSql, sqlWhere, join)
    {
    }
}