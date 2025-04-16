#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPreClientesReader
{
    PreClientesResponse? Read(int id, SqlConnection oCnn);
    PreClientesResponse? Read(string where, SqlConnection oCnn);
    PreClientesResponse? Read(Entity.DBPreClientes dbRec);
    PreClientesResponse? Read(DBPreClientes dbRec);
}

public partial class PreClientes : IPreClientesReader
{
    public PreClientesResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPreClientes(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PreClientesResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPreClientes(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PreClientesResponse? Read(Entity.DBPreClientes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var preclientes = new PreClientesResponse
        {
            Id = dbRec.ID,
            Inativo = dbRec.FInativo,
            QuemIndicou = dbRec.FQuemIndicou ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Adv = dbRec.FAdv,
            IDRep = dbRec.FIDRep,
            Juridica = dbRec.FJuridica,
            NomeFantasia = dbRec.FNomeFantasia ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Tipo = dbRec.FTipo,
            InscEst = dbRec.FInscEst ?? string.Empty,
            Qualificacao = dbRec.FQualificacao ?? string.Empty,
            Sexo = dbRec.FSexo,
            Idade = dbRec.FIdade,
            CNPJ = dbRec.FCNPJ ?? string.Empty,
            CPF = dbRec.FCPF ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            TipoCaptacao = dbRec.FTipoCaptacao,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Cidade = dbRec.FCidade,
            CEP = dbRec.FCEP ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            HomePage = dbRec.FHomePage ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Assistido = dbRec.FAssistido ?? string.Empty,
            AssRG = dbRec.FAssRG ?? string.Empty,
            AssCPF = dbRec.FAssCPF ?? string.Empty,
            AssEndereco = dbRec.FAssEndereco ?? string.Empty,
            CNH = dbRec.FCNH ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            preclientes.DtNasc = dbRec.FDtNasc;
        if (DateTime.TryParse(dbRec.FData, out _))
            preclientes.Data = dbRec.FData;
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
        preclientes.Auditor = auditor;
        return preclientes;
    }

    public PreClientesResponse? Read(DBPreClientes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var preclientes = new PreClientesResponse
        {
            Id = dbRec.ID,
            Inativo = dbRec.FInativo,
            QuemIndicou = dbRec.FQuemIndicou ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Adv = dbRec.FAdv,
            IDRep = dbRec.FIDRep,
            Juridica = dbRec.FJuridica,
            NomeFantasia = dbRec.FNomeFantasia ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Tipo = dbRec.FTipo,
            InscEst = dbRec.FInscEst ?? string.Empty,
            Qualificacao = dbRec.FQualificacao ?? string.Empty,
            Sexo = dbRec.FSexo,
            Idade = dbRec.FIdade,
            CNPJ = dbRec.FCNPJ ?? string.Empty,
            CPF = dbRec.FCPF ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            TipoCaptacao = dbRec.FTipoCaptacao,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Cidade = dbRec.FCidade,
            CEP = dbRec.FCEP ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            HomePage = dbRec.FHomePage ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Assistido = dbRec.FAssistido ?? string.Empty,
            AssRG = dbRec.FAssRG ?? string.Empty,
            AssCPF = dbRec.FAssCPF ?? string.Empty,
            AssEndereco = dbRec.FAssEndereco ?? string.Empty,
            CNH = dbRec.FCNH ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            preclientes.DtNasc = dbRec.FDtNasc;
        if (DateTime.TryParse(dbRec.FData, out _))
            preclientes.Data = dbRec.FData;
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
        preclientes.Auditor = auditor;
        return preclientes;
    }
}