namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBClientes
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBClientesDicInfo.Empresa:
                FEmpresa = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBClientesDicInfo.Icone:
                FIcone = $"{value}"; // rgo J3: string
                return;
            case DBClientesDicInfo.NomeMae:
                FNomeMae = $"{value}"; // rgo J3: string
                return;
            case DBClientesDicInfo.RGDataExp:
                FRGDataExp = $"{value}"; // rgo J3: DateTime
                return;
            case DBClientesDicInfo.Inativo:
                FInativo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBClientesDicInfo.QuemIndicou:
                FQuemIndicou = $"{value}"; // rgo J3: string
                return;
            case DBClientesDicInfo.SendEMail:
                FSendEMail = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBClientesDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBClientesDicInfo.Adv:
                FAdv = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBClientesDicInfo.IDRep:
                FIDRep = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBClientesDicInfo.Juridica:
                FJuridica = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBClientesDicInfo.NomeFantasia:
                FNomeFantasia = $"{value}"; // rgo J3: string
                return;
            case DBClientesDicInfo.Class:
                FClass = $"{value}"; // rgo J3: string
                return;
            case DBClientesDicInfo.Tipo:
                FTipo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBClientesDicInfo.DtNasc:
                FDtNasc = $"{value}"; // rgo J3: DateTime
                return;
            case DBClientesDicInfo.InscEst:
                FInscEst = $"{value}"; // rgo J3: string
                return;
            case DBClientesDicInfo.Qualificacao:
                FQualificacao = $"{value}"; // rgo J3: string
                return;
            case DBClientesDicInfo.Sexo:
                FSexo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBClientesDicInfo.Idade:
                FIdade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBClientesDicInfo.CNPJ:
                FCNPJ = $"{value}"; // rgo J3: string
                return;
            case DBClientesDicInfo.CPF:
                FCPF = $"{value}"; // rgo J3: string
                return;
            case DBClientesDicInfo.RG:
                FRG = $"{value}"; // rgo J3: string
                return;
            case DBClientesDicInfo.TipoCaptacao:
                FTipoCaptacao = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBClientesDicInfo.Observacao:
                FObservacao = $"{value}"; // rgo J3: string
                return;
            case DBClientesDicInfo.Endereco:
                FEndereco = $"{value}"; // rgo J3: string
                return;
            case DBClientesDicInfo.Bairro:
                FBairro = $"{value}"; // rgo J3: string
                return;
            case DBClientesDicInfo.Cidade:
                FCidade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBClientesDicInfo.CEP:
                FCEP = $"{value}"; // rgo J3: string
                return;
            case DBClientesDicInfo.Fax:
                FFax = $"{value}"; // rgo J3: string
                return;
            case DBClientesDicInfo.Fone:
                FFone = $"{value}"; // rgo J3: string
                return;
            case DBClientesDicInfo.Data:
                FData = $"{value}"; // rgo J3: DateTime
                return;
            case DBClientesDicInfo.HomePage:
                FHomePage = $"{value}"; // rgo J3: string
                return;
            case DBClientesDicInfo.EMail:
                FEMail = $"{value}"; // rgo J3: string
                return;
            case DBClientesDicInfo.Obito:
                FObito = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBClientesDicInfo.NomePai:
                FNomePai = $"{value}"; // rgo J3: string
                return;
            case DBClientesDicInfo.RGOExpeditor:
                FRGOExpeditor = $"{value}"; // rgo J3: string
                return;
            case DBClientesDicInfo.RegimeTributacao:
                FRegimeTributacao = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBClientesDicInfo.EnquadramentoEmpresa:
                FEnquadramentoEmpresa = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBClientesDicInfo.ReportECBOnly:
                FReportECBOnly = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBClientesDicInfo.ProBono:
                FProBono = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBClientesDicInfo.CNH:
                FCNH = $"{value}"; // rgo J3: string
                return;
            case DBClientesDicInfo.PessoaContato:
                FPessoaContato = $"{value}"; // rgo J3: string
                return;
            case DBClientesDicInfo.Etiqueta:
                FEtiqueta = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBClientesDicInfo.Ani:
                FAni = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBClientesDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBClientesDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBClientesDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBClientesDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBClientesDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBClientesDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBClientesDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBClientesDicInfo.Empresa => NFEmpresa(),
        DBClientesDicInfo.Icone => NFIcone(),
        DBClientesDicInfo.NomeMae => NFNomeMae(),
        DBClientesDicInfo.RGDataExp => NFRGDataExp(),
        DBClientesDicInfo.Inativo => FInativo.ToString(),
        DBClientesDicInfo.QuemIndicou => NFQuemIndicou(),
        DBClientesDicInfo.SendEMail => FSendEMail.ToString(),
        DBClientesDicInfo.Nome => NFNome(),
        DBClientesDicInfo.Adv => NFAdv(),
        DBClientesDicInfo.IDRep => NFIDRep(),
        DBClientesDicInfo.Juridica => FJuridica.ToString(),
        DBClientesDicInfo.NomeFantasia => NFNomeFantasia(),
        DBClientesDicInfo.Class => NFClass(),
        DBClientesDicInfo.Tipo => FTipo.ToString(),
        DBClientesDicInfo.DtNasc => NFDtNasc(),
        DBClientesDicInfo.InscEst => NFInscEst(),
        DBClientesDicInfo.Qualificacao => NFQualificacao(),
        DBClientesDicInfo.Sexo => FSexo.ToString(),
        DBClientesDicInfo.Idade => NFIdade(),
        DBClientesDicInfo.CNPJ => NFCNPJ(),
        DBClientesDicInfo.CPF => NFCPF(),
        DBClientesDicInfo.RG => NFRG(),
        DBClientesDicInfo.TipoCaptacao => FTipoCaptacao.ToString(),
        DBClientesDicInfo.Observacao => NFObservacao(),
        DBClientesDicInfo.Endereco => NFEndereco(),
        DBClientesDicInfo.Bairro => NFBairro(),
        DBClientesDicInfo.Cidade => NFCidade(),
        DBClientesDicInfo.CEP => NFCEP(),
        DBClientesDicInfo.Fax => NFFax(),
        DBClientesDicInfo.Fone => NFFone(),
        DBClientesDicInfo.Data => NFData(),
        DBClientesDicInfo.HomePage => NFHomePage(),
        DBClientesDicInfo.EMail => NFEMail(),
        DBClientesDicInfo.Obito => FObito.ToString(),
        DBClientesDicInfo.NomePai => NFNomePai(),
        DBClientesDicInfo.RGOExpeditor => NFRGOExpeditor(),
        DBClientesDicInfo.RegimeTributacao => NFRegimeTributacao(),
        DBClientesDicInfo.EnquadramentoEmpresa => NFEnquadramentoEmpresa(),
        DBClientesDicInfo.ReportECBOnly => FReportECBOnly.ToString(),
        DBClientesDicInfo.ProBono => FProBono.ToString(),
        DBClientesDicInfo.CNH => NFCNH(),
        DBClientesDicInfo.PessoaContato => NFPessoaContato(),
        DBClientesDicInfo.Etiqueta => FEtiqueta.ToString(),
        DBClientesDicInfo.Ani => FAni.ToString(),
        DBClientesDicInfo.Bold => FBold.ToString(),
        DBClientesDicInfo.GUID => NFGUID(),
        DBClientesDicInfo.QuemCad => NFQuemCad(),
        DBClientesDicInfo.DtCad => MDtCad,
        DBClientesDicInfo.QuemAtu => NFQuemAtu(),
        DBClientesDicInfo.DtAtu => MDtAtu,
        DBClientesDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}