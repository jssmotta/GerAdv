#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOponentesReader
{
    OponentesResponse? Read(int id, SqlConnection oCnn);
    OponentesResponse? Read(string where, SqlConnection oCnn);
    OponentesResponse? Read(Entity.DBOponentes dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    OponentesResponse? Read(DBOponentes dbRec);
}

public partial class Oponentes : IOponentesReader
{
    public OponentesResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOponentes(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OponentesResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOponentes(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OponentesResponse? Read(Entity.DBOponentes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var oponentes = new OponentesResponse
        {
            Id = dbRec.ID,
            EMPFuncao = dbRec.FEMPFuncao,
            CTPSNumero = dbRec.FCTPSNumero ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            CTPSSerie = dbRec.FCTPSSerie ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Adv = dbRec.FAdv,
            EMPCliente = dbRec.FEMPCliente,
            IDRep = dbRec.FIDRep,
            PIS = dbRec.FPIS ?? string.Empty,
            Contato = dbRec.FContato ?? string.Empty,
            CNPJ = dbRec.FCNPJ ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Juridica = dbRec.FJuridica,
            Tipo = dbRec.FTipo,
            Sexo = dbRec.FSexo,
            CPF = dbRec.FCPF ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Cidade = dbRec.FCidade,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP ?? string.Empty,
            InscEst = dbRec.FInscEst ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Top = dbRec.FTop,
            Etiqueta = dbRec.FEtiqueta,
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
        oponentes.Auditor = auditor;
        return oponentes;
    }

    public OponentesResponse? Read(DBOponentes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var oponentes = new OponentesResponse
        {
            Id = dbRec.ID,
            EMPFuncao = dbRec.FEMPFuncao,
            CTPSNumero = dbRec.FCTPSNumero ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            CTPSSerie = dbRec.FCTPSSerie ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Adv = dbRec.FAdv,
            EMPCliente = dbRec.FEMPCliente,
            IDRep = dbRec.FIDRep,
            PIS = dbRec.FPIS ?? string.Empty,
            Contato = dbRec.FContato ?? string.Empty,
            CNPJ = dbRec.FCNPJ ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Juridica = dbRec.FJuridica,
            Tipo = dbRec.FTipo,
            Sexo = dbRec.FSexo,
            CPF = dbRec.FCPF ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Cidade = dbRec.FCidade,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP ?? string.Empty,
            InscEst = dbRec.FInscEst ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Top = dbRec.FTop,
            Etiqueta = dbRec.FEtiqueta,
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
        oponentes.Auditor = auditor;
        return oponentes;
    }
}