#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProValoresReader
{
    ProValoresResponse? Read(int id, SqlConnection oCnn);
    ProValoresResponse? Read(string where, SqlConnection oCnn);
    ProValoresResponse? Read(Entity.DBProValores dbRec);
    ProValoresResponse? Read(DBProValores dbRec);
}

public partial class ProValores : IProValoresReader
{
    public ProValoresResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProValores(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProValoresResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProValores(sqlWhere: where, oCnn: oCnn);
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
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            provalores.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FDataUltimaCorrecao, out _))
            provalores.DataUltimaCorrecao = dbRec.FDataUltimaCorrecao;
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        provalores.Auditor = auditor;
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
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            provalores.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FDataUltimaCorrecao, out _))
            provalores.DataUltimaCorrecao = dbRec.FDataUltimaCorrecao;
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        provalores.Auditor = auditor;
        return provalores;
    }
}