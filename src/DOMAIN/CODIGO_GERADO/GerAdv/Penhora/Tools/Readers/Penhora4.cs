#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPenhoraReader
{
    PenhoraResponse? Read(int id, SqlConnection oCnn);
    PenhoraResponse? Read(string where, SqlConnection oCnn);
    PenhoraResponse? Read(Entity.DBPenhora dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    PenhoraResponse? Read(DBPenhora dbRec);
}

public partial class Penhora : IPenhoraReader
{
    public PenhoraResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPenhora(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PenhoraResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPenhora(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PenhoraResponse? Read(Entity.DBPenhora dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var penhora = new PenhoraResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Descricao = dbRec.FDescricao ?? string.Empty,
            PenhoraStatus = dbRec.FPenhoraStatus,
            Master = dbRec.FMaster,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataPenhora, out _))
            penhora.DataPenhora = dbRec.FDataPenhora;
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
        penhora.Auditor = auditor;
        return penhora;
    }

    public PenhoraResponse? Read(DBPenhora dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var penhora = new PenhoraResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Descricao = dbRec.FDescricao ?? string.Empty,
            PenhoraStatus = dbRec.FPenhoraStatus,
            Master = dbRec.FMaster,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataPenhora, out _))
            penhora.DataPenhora = dbRec.FDataPenhora;
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
        penhora.Auditor = auditor;
        return penhora;
    }
}