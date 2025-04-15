#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEscritoriosWhere
{
    EscritoriosResponse Read(string where, SqlConnection oCnn);
}

public partial class Escritorios : IEscritoriosWhere
{
    public EscritoriosResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEscritorios(sqlWhere: where, oCnn: oCnn);
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