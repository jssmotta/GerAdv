using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBBensMateriais : MenphisSI.GerAdv.DBBensMateriais, IDBBensMateriais
{
    public DBBensMateriais() : base()
    {
    }

    public DBBensMateriais(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBBensMateriais(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBBensMateriais(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBBensMateriais(List<SqlParameter> parameters, in string? cNome = "", MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}