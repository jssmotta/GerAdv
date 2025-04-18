#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IStatusAndamentoReader
{
    StatusAndamentoResponse? Read(int id, SqlConnection oCnn);
    StatusAndamentoResponse? Read(string where, SqlConnection oCnn);
    StatusAndamentoResponse? Read(Entity.DBStatusAndamento dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    StatusAndamentoResponse? Read(DBStatusAndamento dbRec);
}

public partial class StatusAndamento : IStatusAndamentoReader
{
    public StatusAndamentoResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBStatusAndamento(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public StatusAndamentoResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBStatusAndamento(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public StatusAndamentoResponse? Read(Entity.DBStatusAndamento dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statusandamento = new StatusAndamentoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Icone = dbRec.FIcone,
            Bold = dbRec.FBold,
            Guid = dbRec.FGUID ?? string.Empty,
        };
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
        statusandamento.Auditor = auditor;
        return statusandamento;
    }

    public StatusAndamentoResponse? Read(DBStatusAndamento dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var statusandamento = new StatusAndamentoResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Icone = dbRec.FIcone,
            Bold = dbRec.FBold,
            Guid = dbRec.FGUID ?? string.Empty,
        };
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
        statusandamento.Auditor = auditor;
        return statusandamento;
    }
}