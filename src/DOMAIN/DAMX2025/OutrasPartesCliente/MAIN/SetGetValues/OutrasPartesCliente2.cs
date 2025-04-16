namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBOutrasPartesCliente
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBOutrasPartesClienteDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBOutrasPartesClienteDicInfo.Terceirizado:
                FTerceirizado = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOutrasPartesClienteDicInfo.ClientePrincipal:
                FClientePrincipal = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOutrasPartesClienteDicInfo.Tipo:
                FTipo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOutrasPartesClienteDicInfo.Sexo:
                FSexo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOutrasPartesClienteDicInfo.DtNasc:
                FDtNasc = $"{value}"; // rgo J3: DateTime
                return;
            case DBOutrasPartesClienteDicInfo.CPF:
                FCPF = $"{value}"; // rgo J3: string
                return;
            case DBOutrasPartesClienteDicInfo.RG:
                FRG = $"{value}"; // rgo J3: string
                return;
            case DBOutrasPartesClienteDicInfo.CNPJ:
                FCNPJ = $"{value}"; // rgo J3: string
                return;
            case DBOutrasPartesClienteDicInfo.InscEst:
                FInscEst = $"{value}"; // rgo J3: string
                return;
            case DBOutrasPartesClienteDicInfo.NomeFantasia:
                FNomeFantasia = $"{value}"; // rgo J3: string
                return;
            case DBOutrasPartesClienteDicInfo.Endereco:
                FEndereco = $"{value}"; // rgo J3: string
                return;
            case DBOutrasPartesClienteDicInfo.Cidade:
                FCidade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOutrasPartesClienteDicInfo.CEP:
                FCEP = $"{value}"; // rgo J3: string
                return;
            case DBOutrasPartesClienteDicInfo.Bairro:
                FBairro = $"{value}"; // rgo J3: string
                return;
            case DBOutrasPartesClienteDicInfo.Fone:
                FFone = $"{value}"; // rgo J3: string
                return;
            case DBOutrasPartesClienteDicInfo.Fax:
                FFax = $"{value}"; // rgo J3: string
                return;
            case DBOutrasPartesClienteDicInfo.EMail:
                FEMail = $"{value}"; // rgo J3: string
                return;
            case DBOutrasPartesClienteDicInfo.Site:
                FSite = $"{value}"; // rgo J3: string
                return;
            case DBOutrasPartesClienteDicInfo.Class:
                FClass = $"{value}"; // rgo J3: string
                return;
            case DBOutrasPartesClienteDicInfo.Etiqueta:
                FEtiqueta = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOutrasPartesClienteDicInfo.Ani:
                FAni = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOutrasPartesClienteDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOutrasPartesClienteDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBOutrasPartesClienteDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOutrasPartesClienteDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBOutrasPartesClienteDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOutrasPartesClienteDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBOutrasPartesClienteDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBOutrasPartesClienteDicInfo.Nome => NFNome(),
        DBOutrasPartesClienteDicInfo.Terceirizado => FTerceirizado.ToString(),
        DBOutrasPartesClienteDicInfo.ClientePrincipal => NFClientePrincipal(),
        DBOutrasPartesClienteDicInfo.Tipo => FTipo.ToString(),
        DBOutrasPartesClienteDicInfo.Sexo => FSexo.ToString(),
        DBOutrasPartesClienteDicInfo.DtNasc => NFDtNasc(),
        DBOutrasPartesClienteDicInfo.CPF => NFCPF(),
        DBOutrasPartesClienteDicInfo.RG => NFRG(),
        DBOutrasPartesClienteDicInfo.CNPJ => NFCNPJ(),
        DBOutrasPartesClienteDicInfo.InscEst => NFInscEst(),
        DBOutrasPartesClienteDicInfo.NomeFantasia => NFNomeFantasia(),
        DBOutrasPartesClienteDicInfo.Endereco => NFEndereco(),
        DBOutrasPartesClienteDicInfo.Cidade => NFCidade(),
        DBOutrasPartesClienteDicInfo.CEP => NFCEP(),
        DBOutrasPartesClienteDicInfo.Bairro => NFBairro(),
        DBOutrasPartesClienteDicInfo.Fone => NFFone(),
        DBOutrasPartesClienteDicInfo.Fax => NFFax(),
        DBOutrasPartesClienteDicInfo.EMail => NFEMail(),
        DBOutrasPartesClienteDicInfo.Site => NFSite(),
        DBOutrasPartesClienteDicInfo.Class => NFClass(),
        DBOutrasPartesClienteDicInfo.Etiqueta => FEtiqueta.ToString(),
        DBOutrasPartesClienteDicInfo.Ani => FAni.ToString(),
        DBOutrasPartesClienteDicInfo.Bold => FBold.ToString(),
        DBOutrasPartesClienteDicInfo.GUID => NFGUID(),
        DBOutrasPartesClienteDicInfo.QuemCad => NFQuemCad(),
        DBOutrasPartesClienteDicInfo.DtCad => MDtCad,
        DBOutrasPartesClienteDicInfo.QuemAtu => NFQuemAtu(),
        DBOutrasPartesClienteDicInfo.DtAtu => MDtAtu,
        DBOutrasPartesClienteDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}