#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface INENotasReader
{
    NENotasResponse? Read(int id, SqlConnection oCnn);
    NENotasResponse? Read(string where, SqlConnection oCnn);
    NENotasResponse? Read(Entity.DBNENotas dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    NENotasResponse? Read(DBNENotas dbRec);
}

public partial class NENotas : INENotasReader
{
    public NENotasResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBNENotas(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public NENotasResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBNENotas(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public NENotasResponse? Read(Entity.DBNENotas dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var nenotas = new NENotasResponse
        {
            Id = dbRec.ID,
            Apenso = dbRec.FApenso,
            Precatoria = dbRec.FPrecatoria,
            Instancia = dbRec.FInstancia,
            MovPro = dbRec.FMovPro,
            Nome = dbRec.FNome ?? string.Empty,
            NotaExpedida = dbRec.FNotaExpedida,
            Revisada = dbRec.FRevisada,
            Processo = dbRec.FProcesso,
            PalavraChave = dbRec.FPalavraChave,
            NotaPublicada = dbRec.FNotaPublicada ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            nenotas.Data = dbRec.FData;
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
        nenotas.Auditor = auditor;
        return nenotas;
    }

    public NENotasResponse? Read(DBNENotas dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var nenotas = new NENotasResponse
        {
            Id = dbRec.ID,
            Apenso = dbRec.FApenso,
            Precatoria = dbRec.FPrecatoria,
            Instancia = dbRec.FInstancia,
            MovPro = dbRec.FMovPro,
            Nome = dbRec.FNome ?? string.Empty,
            NotaExpedida = dbRec.FNotaExpedida,
            Revisada = dbRec.FRevisada,
            Processo = dbRec.FProcesso,
            PalavraChave = dbRec.FPalavraChave,
            NotaPublicada = dbRec.FNotaPublicada ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            nenotas.Data = dbRec.FData;
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
        nenotas.Auditor = auditor;
        return nenotas;
    }
}