#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProObservacoesReader
{
    ProObservacoesResponse? Read(int id, SqlConnection oCnn);
    ProObservacoesResponse? Read(string where, SqlConnection oCnn);
    ProObservacoesResponse? Read(Entity.DBProObservacoes dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    ProObservacoesResponse? Read(DBProObservacoes dbRec);
}

public partial class ProObservacoes : IProObservacoesReader
{
    public ProObservacoesResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProObservacoes(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProObservacoesResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProObservacoes(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProObservacoesResponse? Read(Entity.DBProObservacoes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var proobservacoes = new ProObservacoesResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            proobservacoes.Data = dbRec.FData;
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
        proobservacoes.Auditor = auditor;
        return proobservacoes;
    }

    public ProObservacoesResponse? Read(DBProObservacoes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var proobservacoes = new ProObservacoesResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Observacoes = dbRec.FObservacoes ?? string.Empty,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            proobservacoes.Data = dbRec.FData;
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
        proobservacoes.Auditor = auditor;
        return proobservacoes;
    }
}