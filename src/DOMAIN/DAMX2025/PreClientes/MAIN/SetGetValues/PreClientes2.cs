namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBPreClientes
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBPreClientesDicInfo.Inativo:
                FInativo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBPreClientesDicInfo.QuemIndicou:
                FQuemIndicou = $"{value}"; // rgo J3: string
                return;
            case DBPreClientesDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBPreClientesDicInfo.Adv:
                FAdv = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPreClientesDicInfo.IDRep:
                FIDRep = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPreClientesDicInfo.Juridica:
                FJuridica = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBPreClientesDicInfo.NomeFantasia:
                FNomeFantasia = $"{value}"; // rgo J3: string
                return;
            case DBPreClientesDicInfo.Class:
                FClass = $"{value}"; // rgo J3: string
                return;
            case DBPreClientesDicInfo.Tipo:
                FTipo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBPreClientesDicInfo.DtNasc:
                FDtNasc = $"{value}"; // rgo J3: DateTime
                return;
            case DBPreClientesDicInfo.InscEst:
                FInscEst = $"{value}"; // rgo J3: string
                return;
            case DBPreClientesDicInfo.Qualificacao:
                FQualificacao = $"{value}"; // rgo J3: string
                return;
            case DBPreClientesDicInfo.Sexo:
                FSexo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBPreClientesDicInfo.Idade:
                FIdade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPreClientesDicInfo.CNPJ:
                FCNPJ = $"{value}"; // rgo J3: string
                return;
            case DBPreClientesDicInfo.CPF:
                FCPF = $"{value}"; // rgo J3: string
                return;
            case DBPreClientesDicInfo.RG:
                FRG = $"{value}"; // rgo J3: string
                return;
            case DBPreClientesDicInfo.TipoCaptacao:
                FTipoCaptacao = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBPreClientesDicInfo.Observacao:
                FObservacao = $"{value}"; // rgo J3: string
                return;
            case DBPreClientesDicInfo.Endereco:
                FEndereco = $"{value}"; // rgo J3: string
                return;
            case DBPreClientesDicInfo.Bairro:
                FBairro = $"{value}"; // rgo J3: string
                return;
            case DBPreClientesDicInfo.Cidade:
                FCidade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPreClientesDicInfo.CEP:
                FCEP = $"{value}"; // rgo J3: string
                return;
            case DBPreClientesDicInfo.Fax:
                FFax = $"{value}"; // rgo J3: string
                return;
            case DBPreClientesDicInfo.Fone:
                FFone = $"{value}"; // rgo J3: string
                return;
            case DBPreClientesDicInfo.Data:
                FData = $"{value}"; // rgo J3: DateTime
                return;
            case DBPreClientesDicInfo.HomePage:
                FHomePage = $"{value}"; // rgo J3: string
                return;
            case DBPreClientesDicInfo.EMail:
                FEMail = $"{value}"; // rgo J3: string
                return;
            case DBPreClientesDicInfo.Assistido:
                FAssistido = $"{value}"; // rgo J3: string
                return;
            case DBPreClientesDicInfo.AssRG:
                FAssRG = $"{value}"; // rgo J3: string
                return;
            case DBPreClientesDicInfo.AssCPF:
                FAssCPF = $"{value}"; // rgo J3: string
                return;
            case DBPreClientesDicInfo.AssEndereco:
                FAssEndereco = $"{value}"; // rgo J3: string
                return;
            case DBPreClientesDicInfo.CNH:
                FCNH = $"{value}"; // rgo J3: string
                return;
            case DBPreClientesDicInfo.Etiqueta:
                FEtiqueta = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBPreClientesDicInfo.Ani:
                FAni = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBPreClientesDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBPreClientesDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPreClientesDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBPreClientesDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBPreClientesDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBPreClientesDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBPreClientesDicInfo.Inativo => FInativo.ToString(),
        DBPreClientesDicInfo.QuemIndicou => NFQuemIndicou(),
        DBPreClientesDicInfo.Nome => NFNome(),
        DBPreClientesDicInfo.Adv => NFAdv(),
        DBPreClientesDicInfo.IDRep => NFIDRep(),
        DBPreClientesDicInfo.Juridica => FJuridica.ToString(),
        DBPreClientesDicInfo.NomeFantasia => NFNomeFantasia(),
        DBPreClientesDicInfo.Class => NFClass(),
        DBPreClientesDicInfo.Tipo => FTipo.ToString(),
        DBPreClientesDicInfo.DtNasc => NFDtNasc(),
        DBPreClientesDicInfo.InscEst => NFInscEst(),
        DBPreClientesDicInfo.Qualificacao => NFQualificacao(),
        DBPreClientesDicInfo.Sexo => FSexo.ToString(),
        DBPreClientesDicInfo.Idade => NFIdade(),
        DBPreClientesDicInfo.CNPJ => NFCNPJ(),
        DBPreClientesDicInfo.CPF => NFCPF(),
        DBPreClientesDicInfo.RG => NFRG(),
        DBPreClientesDicInfo.TipoCaptacao => FTipoCaptacao.ToString(),
        DBPreClientesDicInfo.Observacao => NFObservacao(),
        DBPreClientesDicInfo.Endereco => NFEndereco(),
        DBPreClientesDicInfo.Bairro => NFBairro(),
        DBPreClientesDicInfo.Cidade => NFCidade(),
        DBPreClientesDicInfo.CEP => NFCEP(),
        DBPreClientesDicInfo.Fax => NFFax(),
        DBPreClientesDicInfo.Fone => NFFone(),
        DBPreClientesDicInfo.Data => NFData(),
        DBPreClientesDicInfo.HomePage => NFHomePage(),
        DBPreClientesDicInfo.EMail => NFEMail(),
        DBPreClientesDicInfo.Assistido => NFAssistido(),
        DBPreClientesDicInfo.AssRG => NFAssRG(),
        DBPreClientesDicInfo.AssCPF => NFAssCPF(),
        DBPreClientesDicInfo.AssEndereco => NFAssEndereco(),
        DBPreClientesDicInfo.CNH => NFCNH(),
        DBPreClientesDicInfo.Etiqueta => FEtiqueta.ToString(),
        DBPreClientesDicInfo.Ani => FAni.ToString(),
        DBPreClientesDicInfo.Bold => FBold.ToString(),
        DBPreClientesDicInfo.QuemCad => NFQuemCad(),
        DBPreClientesDicInfo.DtCad => MDtCad,
        DBPreClientesDicInfo.QuemAtu => NFQuemAtu(),
        DBPreClientesDicInfo.DtAtu => MDtAtu,
        DBPreClientesDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}