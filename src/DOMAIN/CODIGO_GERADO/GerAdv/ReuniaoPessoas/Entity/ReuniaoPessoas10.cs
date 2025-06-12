using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBReuniaoPessoas : MenphisSI.GerAdv.DBReuniaoPessoas, IDBReuniaoPessoas
{
    public DBReuniaoPessoas() : base()
    {
    }

    public DBReuniaoPessoas(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBReuniaoPessoas(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBReuniaoPessoas(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBReuniaoPessoas(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}