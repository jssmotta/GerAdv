using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBOutrasPartesCliente : MenphisSI.GerAdv.DBOutrasPartesCliente, IDBOutrasPartesCliente
{
    public DBOutrasPartesCliente() : base()
    {
    }

    public DBOutrasPartesCliente(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBOutrasPartesCliente(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBOutrasPartesCliente(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBOutrasPartesCliente(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}