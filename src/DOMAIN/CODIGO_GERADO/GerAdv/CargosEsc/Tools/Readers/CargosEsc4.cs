#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ICargosEscReader
{
    CargosEscResponse? Read(int id, SqlConnection oCnn);
    CargosEscResponse? Read(string where, SqlConnection oCnn);
    CargosEscResponse? Read(Entity.DBCargosEsc dbRec);
    CargosEscResponse? Read(DBCargosEsc dbRec);
}

public partial class CargosEsc : ICargosEscReader
{
    public CargosEscResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBCargosEsc(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public CargosEscResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBCargosEsc(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public CargosEscResponse? Read(Entity.DBCargosEsc dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var cargosesc = new CargosEscResponse
        {
            Id = dbRec.ID,
            Percentual = dbRec.FPercentual,
            Nome = dbRec.FNome ?? string.Empty,
            Classificacao = dbRec.FClassificacao,
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
        cargosesc.Auditor = auditor;
        return cargosesc;
    }

    public CargosEscResponse? Read(DBCargosEsc dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var cargosesc = new CargosEscResponse
        {
            Id = dbRec.ID,
            Percentual = dbRec.FPercentual,
            Nome = dbRec.FNome ?? string.Empty,
            Classificacao = dbRec.FClassificacao,
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
        cargosesc.Auditor = auditor;
        return cargosesc;
    }
}