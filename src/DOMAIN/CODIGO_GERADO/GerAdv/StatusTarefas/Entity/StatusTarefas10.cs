using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBStatusTarefas : MenphisSI.GerAdv.DBStatusTarefas, IDBStatusTarefas
{
    public DBStatusTarefas() : base()
    {
    }

    public DBStatusTarefas(int id, SqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBStatusTarefas(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBStatusTarefas(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBStatusTarefas(in string? cNome = "", SqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(cNome, oCnn, fullSql, sqlWhere, join)
    {
    }
}