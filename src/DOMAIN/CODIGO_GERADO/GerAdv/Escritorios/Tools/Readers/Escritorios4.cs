#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEscritoriosReader
{
    EscritoriosResponse? Read(int id, SqlConnection oCnn);
    EscritoriosResponse? Read(string where, SqlConnection oCnn);
    EscritoriosResponse? Read(Entity.DBEscritorios dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    EscritoriosResponse? Read(DBEscritorios dbRec);
}

public partial class Escritorios : IEscritoriosReader
{
    public EscritoriosResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEscritorios(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EscritoriosResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEscritorios(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EscritoriosResponse? Read(Entity.DBEscritorios dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var escritorios = new EscritoriosResponse
        {
            Id = dbRec.ID,
            CNPJ = dbRec.FCNPJ ?? string.Empty,
            Casa = dbRec.FCasa,
            Parceria = dbRec.FParceria,
            Nome = dbRec.FNome ?? string.Empty,
            OAB = dbRec.FOAB ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Cidade = dbRec.FCidade,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            AdvResponsavel = dbRec.FAdvResponsavel ?? string.Empty,
            Secretaria = dbRec.FSecretaria ?? string.Empty,
            InscEst = dbRec.FInscEst ?? string.Empty,
            Correspondente = dbRec.FCorrespondente,
            Top = dbRec.FTop,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
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
        escritorios.Auditor = auditor;
        return escritorios;
    }

    public EscritoriosResponse? Read(DBEscritorios dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var escritorios = new EscritoriosResponse
        {
            Id = dbRec.ID,
            CNPJ = dbRec.FCNPJ ?? string.Empty,
            Casa = dbRec.FCasa,
            Parceria = dbRec.FParceria,
            Nome = dbRec.FNome ?? string.Empty,
            OAB = dbRec.FOAB ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Cidade = dbRec.FCidade,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            AdvResponsavel = dbRec.FAdvResponsavel ?? string.Empty,
            Secretaria = dbRec.FSecretaria ?? string.Empty,
            InscEst = dbRec.FInscEst ?? string.Empty,
            Correspondente = dbRec.FCorrespondente,
            Top = dbRec.FTop,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
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
        escritorios.Auditor = auditor;
        return escritorios;
    }
}