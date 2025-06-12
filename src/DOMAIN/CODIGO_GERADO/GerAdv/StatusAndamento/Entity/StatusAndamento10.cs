using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBStatusAndamento : MenphisSI.GerAdv.DBStatusAndamento, IDBStatusAndamento
{
    public DBStatusAndamento() : base()
    {
    }

    public DBStatusAndamento(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBStatusAndamento(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBStatusAndamento(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBStatusAndamento(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}