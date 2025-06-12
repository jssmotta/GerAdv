#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProValoresReader
{
    ProValoresResponse? Read(int id, MsiSqlConnection oCnn);
    ProValoresResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProValoresResponse? Read(Entity.DBProValores dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProValoresResponse? Read(DBProValores dbRec);
    ProValoresResponseAll? ReadAll(DBProValores dbRec, DataRow dr);
}

public partial class ProValores : IProValoresReader
{
    public ProValoresResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProValores(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProValoresResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProValores(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProValoresResponse? Read(Entity.DBProValores dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var provalores = new ProValoresResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            TipoValorProcesso = dbRec.FTipoValorProcesso,
            Indice = dbRec.FIndice ?? string.Empty,
            Ignorar = dbRec.FIgnorar,
            ValorOriginal = dbRec.FValorOriginal,
            PercMulta = dbRec.FPercMulta,
            ValorMulta = dbRec.FValorMulta,
            PercJuros = dbRec.FPercJuros,
            ValorOriginalCorrigidoIndice = dbRec.FValorOriginalCorrigidoIndice,
            ValorMultaCorrigido = dbRec.FValorMultaCorrigido,
            ValorJurosCorrigido = dbRec.FValorJurosCorrigido,
            ValorFinal = dbRec.FValorFinal,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            provalores.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FDataUltimaCorrecao, out _))
            provalores.DataUltimaCorrecao = dbRec.FDataUltimaCorrecao;
        return provalores;
    }

    public ProValoresResponse? Read(DBProValores dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var provalores = new ProValoresResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            TipoValorProcesso = dbRec.FTipoValorProcesso,
            Indice = dbRec.FIndice ?? string.Empty,
            Ignorar = dbRec.FIgnorar,
            ValorOriginal = dbRec.FValorOriginal,
            PercMulta = dbRec.FPercMulta,
            ValorMulta = dbRec.FValorMulta,
            PercJuros = dbRec.FPercJuros,
            ValorOriginalCorrigidoIndice = dbRec.FValorOriginalCorrigidoIndice,
            ValorMultaCorrigido = dbRec.FValorMultaCorrigido,
            ValorJurosCorrigido = dbRec.FValorJurosCorrigido,
            ValorFinal = dbRec.FValorFinal,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            provalores.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FDataUltimaCorrecao, out _))
            provalores.DataUltimaCorrecao = dbRec.FDataUltimaCorrecao;
        return provalores;
    }

    public ProValoresResponseAll? ReadAll(DBProValores dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var provalores = new ProValoresResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            TipoValorProcesso = dbRec.FTipoValorProcesso,
            Indice = dbRec.FIndice ?? string.Empty,
            Ignorar = dbRec.FIgnorar,
            ValorOriginal = dbRec.FValorOriginal,
            PercMulta = dbRec.FPercMulta,
            ValorMulta = dbRec.FValorMulta,
            PercJuros = dbRec.FPercJuros,
            ValorOriginalCorrigidoIndice = dbRec.FValorOriginalCorrigidoIndice,
            ValorMultaCorrigido = dbRec.FValorMultaCorrigido,
            ValorJurosCorrigido = dbRec.FValorJurosCorrigido,
            ValorFinal = dbRec.FValorFinal,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            provalores.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FDataUltimaCorrecao, out _))
            provalores.DataUltimaCorrecao = dbRec.FDataUltimaCorrecao;
        provalores.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        provalores.DescricaoTipoValorProcesso = dr["ptvDescricao"]?.ToString() ?? string.Empty;
        return provalores;
    }
}