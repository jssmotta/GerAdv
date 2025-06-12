#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IClientesWhere
{
    ClientesResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class Clientes : IClientesWhere
{
    public ClientesResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBClientes(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var clientes = new ClientesResponse
        {
            Id = dbRec.ID,
            Empresa = dbRec.FEmpresa,
            Icone = dbRec.FIcone ?? string.Empty,
            NomeMae = dbRec.FNomeMae ?? string.Empty,
            Inativo = dbRec.FInativo,
            QuemIndicou = dbRec.FQuemIndicou ?? string.Empty,
            SendEMail = dbRec.FSendEMail,
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
            Obito = dbRec.FObito,
            NomePai = dbRec.FNomePai ?? string.Empty,
            RGOExpeditor = dbRec.FRGOExpeditor ?? string.Empty,
            RegimeTributacao = dbRec.FRegimeTributacao,
            EnquadramentoEmpresa = dbRec.FEnquadramentoEmpresa,
            ReportECBOnly = dbRec.FReportECBOnly,
            ProBono = dbRec.FProBono,
            CNH = dbRec.FCNH ?? string.Empty,
            PessoaContato = dbRec.FPessoaContato ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FRGDataExp, out _))
            clientes.RGDataExp = dbRec.FRGDataExp;
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            clientes.DtNasc = dbRec.FDtNasc;
        if (DateTime.TryParse(dbRec.FData, out _))
            clientes.Data = dbRec.FData;
        return clientes;
    }
}