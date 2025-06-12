#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAnexamentoRegistrosReader
{
    AnexamentoRegistrosResponse? Read(int id, MsiSqlConnection oCnn);
    AnexamentoRegistrosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AnexamentoRegistrosResponse? Read(Entity.DBAnexamentoRegistros dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AnexamentoRegistrosResponse? Read(DBAnexamentoRegistros dbRec);
    AnexamentoRegistrosResponseAll? ReadAll(DBAnexamentoRegistros dbRec, DataRow dr);
}

public partial class AnexamentoRegistros : IAnexamentoRegistrosReader
{
    public AnexamentoRegistrosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAnexamentoRegistros(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AnexamentoRegistrosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAnexamentoRegistros(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AnexamentoRegistrosResponse? Read(Entity.DBAnexamentoRegistros dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var anexamentoregistros = new AnexamentoRegistrosResponse
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            GUIDReg = dbRec.FGUIDReg ?? string.Empty,
            CodigoReg = dbRec.FCodigoReg,
            IDReg = dbRec.FIDReg,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            anexamentoregistros.Data = dbRec.FData;
        return anexamentoregistros;
    }

    public AnexamentoRegistrosResponse? Read(DBAnexamentoRegistros dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var anexamentoregistros = new AnexamentoRegistrosResponse
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            GUIDReg = dbRec.FGUIDReg ?? string.Empty,
            CodigoReg = dbRec.FCodigoReg,
            IDReg = dbRec.FIDReg,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            anexamentoregistros.Data = dbRec.FData;
        return anexamentoregistros;
    }

    public AnexamentoRegistrosResponseAll? ReadAll(DBAnexamentoRegistros dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var anexamentoregistros = new AnexamentoRegistrosResponseAll
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            GUIDReg = dbRec.FGUIDReg ?? string.Empty,
            CodigoReg = dbRec.FCodigoReg,
            IDReg = dbRec.FIDReg,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            anexamentoregistros.Data = dbRec.FData;
        anexamentoregistros.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        return anexamentoregistros;
    }
}