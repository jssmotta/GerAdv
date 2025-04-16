using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBFuncao : MenphisSI.GerAdv.DBFuncao, IDBFuncao
{
    public DBFuncao() : base()
    {
    }

    public DBFuncao(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBFuncao(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBFuncao(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBFuncao(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}