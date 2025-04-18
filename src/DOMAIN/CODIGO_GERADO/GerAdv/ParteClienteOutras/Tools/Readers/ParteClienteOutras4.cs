#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IParteClienteOutrasReader
{
    ParteClienteOutrasResponse? Read(int id, SqlConnection oCnn);
    ParteClienteOutrasResponse? Read(string where, SqlConnection oCnn);
    ParteClienteOutrasResponse? Read(Entity.DBParteClienteOutras dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    ParteClienteOutrasResponse? Read(DBParteClienteOutras dbRec);
}

public partial class ParteClienteOutras : IParteClienteOutrasReader
{
    public ParteClienteOutrasResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBParteClienteOutras(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ParteClienteOutrasResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBParteClienteOutras(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ParteClienteOutrasResponse? Read(Entity.DBParteClienteOutras dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var parteclienteoutras = new ParteClienteOutrasResponse
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            Processo = dbRec.FProcesso,
            PrimeiraReclamada = dbRec.FPrimeiraReclamada,
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
        parteclienteoutras.Auditor = auditor;
        return parteclienteoutras;
    }

    public ParteClienteOutrasResponse? Read(DBParteClienteOutras dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var parteclienteoutras = new ParteClienteOutrasResponse
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            Processo = dbRec.FProcesso,
            PrimeiraReclamada = dbRec.FPrimeiraReclamada,
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
        parteclienteoutras.Auditor = auditor;
        return parteclienteoutras;
    }
}