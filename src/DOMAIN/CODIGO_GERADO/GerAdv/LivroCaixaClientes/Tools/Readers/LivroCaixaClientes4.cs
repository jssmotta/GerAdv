#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ILivroCaixaClientesReader
{
    LivroCaixaClientesResponse? Read(int id, MsiSqlConnection oCnn);
    LivroCaixaClientesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    LivroCaixaClientesResponse? Read(Entity.DBLivroCaixaClientes dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    LivroCaixaClientesResponse? Read(DBLivroCaixaClientes dbRec);
    LivroCaixaClientesResponseAll? ReadAll(DBLivroCaixaClientes dbRec, DataRow dr);
}

public partial class LivroCaixaClientes : ILivroCaixaClientesReader
{
    public LivroCaixaClientesResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBLivroCaixaClientes(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public LivroCaixaClientesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBLivroCaixaClientes(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public LivroCaixaClientesResponse? Read(Entity.DBLivroCaixaClientes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var livrocaixaclientes = new LivroCaixaClientesResponse
        {
            Id = dbRec.ID,
            LivroCaixa = dbRec.FLivroCaixa,
            Cliente = dbRec.FCliente,
            Lancado = dbRec.FLancado,
        };
        return livrocaixaclientes;
    }

    public LivroCaixaClientesResponse? Read(DBLivroCaixaClientes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var livrocaixaclientes = new LivroCaixaClientesResponse
        {
            Id = dbRec.ID,
            LivroCaixa = dbRec.FLivroCaixa,
            Cliente = dbRec.FCliente,
            Lancado = dbRec.FLancado,
        };
        return livrocaixaclientes;
    }

    public LivroCaixaClientesResponseAll? ReadAll(DBLivroCaixaClientes dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var livrocaixaclientes = new LivroCaixaClientesResponseAll
        {
            Id = dbRec.ID,
            LivroCaixa = dbRec.FLivroCaixa,
            Cliente = dbRec.FCliente,
            Lancado = dbRec.FLancado,
        };
        livrocaixaclientes.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        return livrocaixaclientes;
    }
}