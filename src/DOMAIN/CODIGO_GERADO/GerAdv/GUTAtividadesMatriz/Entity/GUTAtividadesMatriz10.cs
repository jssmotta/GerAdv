using MenphisSI.GerAdv.Interface;

namespace MenphisSI.GerAdv.Entity;
public partial class DBGUTAtividadesMatriz : MenphisSI.GerAdv.DBGUTAtividadesMatriz, IDBGUTAtividadesMatriz
{
    public DBGUTAtividadesMatriz() : base()
    {
    }

    public DBGUTAtividadesMatriz(int id, MsiSqlConnection oCnn) : base(id, oCnn)
    {
    }

    public DBGUTAtividadesMatriz(SqlDataReader? dbRec) : base(dbRec)
    {
    }

    public DBGUTAtividadesMatriz(DataRow? dbRec) : base(dbRec)
    {
    }

    public DBGUTAtividadesMatriz(List<SqlParameter> parameters, MsiSqlConnection? oCnn = null, string? fullSql = "", string sqlWhere = "", in string join = "") : base(parameters, oCnn, fullSql, sqlWhere, join)
    {
    }
}