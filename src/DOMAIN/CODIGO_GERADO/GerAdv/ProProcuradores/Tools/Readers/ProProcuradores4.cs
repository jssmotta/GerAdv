#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProProcuradoresReader
{
    ProProcuradoresResponse? Read(int id, SqlConnection oCnn);
    ProProcuradoresResponse? Read(string where, SqlConnection oCnn);
    ProProcuradoresResponse? Read(Entity.DBProProcuradores dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    ProProcuradoresResponse? Read(DBProProcuradores dbRec);
}

public partial class ProProcuradores : IProProcuradoresReader
{
    public ProProcuradoresResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProProcuradores(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProProcuradoresResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProProcuradores(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProProcuradoresResponse? Read(Entity.DBProProcuradores dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var proprocuradores = new ProProcuradoresResponse
        {
            Id = dbRec.ID,
            Advogado = dbRec.FAdvogado,
            Nome = dbRec.FNome ?? string.Empty,
            Processo = dbRec.FProcesso,
            Substabelecimento = dbRec.FSubstabelecimento,
            Procuracao = dbRec.FProcuracao,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            proprocuradores.Data = dbRec.FData;
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
        proprocuradores.Auditor = auditor;
        return proprocuradores;
    }

    public ProProcuradoresResponse? Read(DBProProcuradores dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var proprocuradores = new ProProcuradoresResponse
        {
            Id = dbRec.ID,
            Advogado = dbRec.FAdvogado,
            Nome = dbRec.FNome ?? string.Empty,
            Processo = dbRec.FProcesso,
            Substabelecimento = dbRec.FSubstabelecimento,
            Procuracao = dbRec.FProcuracao,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            proprocuradores.Data = dbRec.FData;
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
        proprocuradores.Auditor = auditor;
        return proprocuradores;
    }
}