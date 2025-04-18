#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ICidadeReader
{
    CidadeResponse? Read(int id, SqlConnection oCnn);
    CidadeResponse? Read(string where, SqlConnection oCnn);
    CidadeResponse? Read(Entity.DBCidade dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    CidadeResponse? Read(DBCidade dbRec);
}

public partial class Cidade : ICidadeReader
{
    public CidadeResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBCidade(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public CidadeResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBCidade(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public CidadeResponse? Read(Entity.DBCidade dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var cidade = new CidadeResponse
        {
            Id = dbRec.ID,
            DDD = dbRec.FDDD ?? string.Empty,
            Top = dbRec.FTop,
            Comarca = dbRec.FComarca,
            Capital = dbRec.FCapital,
            Nome = dbRec.FNome ?? string.Empty,
            UF = dbRec.FUF,
            Sigla = dbRec.FSigla ?? string.Empty,
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
        cidade.Auditor = auditor;
        return cidade;
    }

    public CidadeResponse? Read(DBCidade dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var cidade = new CidadeResponse
        {
            Id = dbRec.ID,
            DDD = dbRec.FDDD ?? string.Empty,
            Top = dbRec.FTop,
            Comarca = dbRec.FComarca,
            Capital = dbRec.FCapital,
            Nome = dbRec.FNome ?? string.Empty,
            UF = dbRec.FUF,
            Sigla = dbRec.FSigla ?? string.Empty,
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
        cidade.Auditor = auditor;
        return cidade;
    }
}