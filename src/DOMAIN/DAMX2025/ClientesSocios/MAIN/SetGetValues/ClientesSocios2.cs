namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBClientesSocios
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBClientesSociosDicInfo.SomenteRepresentante:
                FSomenteRepresentante = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBClientesSociosDicInfo.Idade:
                FIdade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBClientesSociosDicInfo.IsRepresentanteLegal:
                FIsRepresentanteLegal = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBClientesSociosDicInfo.Qualificacao:
                FQualificacao = $"{value}"; // rgo J3: string
                return;
            case DBClientesSociosDicInfo.Sexo:
                FSexo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBClientesSociosDicInfo.DtNasc:
                FDtNasc = $"{value}"; // rgo J3: DateTime
                return;
            case DBClientesSociosDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBClientesSociosDicInfo.Site:
                FSite = $"{value}"; // rgo J3: string
                return;
            case DBClientesSociosDicInfo.RepresentanteLegal:
                FRepresentanteLegal = $"{value}"; // rgo J3: string
                return;
            case DBClientesSociosDicInfo.Cliente:
                FCliente = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBClientesSociosDicInfo.Endereco:
                FEndereco = $"{value}"; // rgo J3: string
                return;
            case DBClientesSociosDicInfo.Bairro:
                FBairro = $"{value}"; // rgo J3: string
                return;
            case DBClientesSociosDicInfo.CEP:
                FCEP = $"{value}"; // rgo J3: string
                return;
            case DBClientesSociosDicInfo.Cidade:
                FCidade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBClientesSociosDicInfo.RG:
                FRG = $"{value}"; // rgo J3: string
                return;
            case DBClientesSociosDicInfo.CPF:
                FCPF = $"{value}"; // rgo J3: string
                return;
            case DBClientesSociosDicInfo.Fone:
                FFone = $"{value}"; // rgo J3: string
                return;
            case DBClientesSociosDicInfo.Participacao:
                FParticipacao = $"{value}"; // rgo J3: string
                return;
            case DBClientesSociosDicInfo.Cargo:
                FCargo = $"{value}"; // rgo J3: string
                return;
            case DBClientesSociosDicInfo.EMail:
                FEMail = $"{value}"; // rgo J3: string
                return;
            case DBClientesSociosDicInfo.Obs:
                FObs = $"{value}"; // rgo J3: string
                return;
            case DBClientesSociosDicInfo.CNH:
                FCNH = $"{value}"; // rgo J3: string
                return;
            case DBClientesSociosDicInfo.DataContrato:
                FDataContrato = $"{value}"; // rgo J3: DateTime
                return;
            case DBClientesSociosDicInfo.CNPJ:
                FCNPJ = $"{value}"; // rgo J3: string
                return;
            case DBClientesSociosDicInfo.InscEst:
                FInscEst = $"{value}"; // rgo J3: string
                return;
            case DBClientesSociosDicInfo.SocioEmpresaAdminNome:
                FSocioEmpresaAdminNome = $"{value}"; // rgo J3: string
                return;
            case DBClientesSociosDicInfo.EnderecoSocio:
                FEnderecoSocio = $"{value}"; // rgo J3: string
                return;
            case DBClientesSociosDicInfo.BairroSocio:
                FBairroSocio = $"{value}"; // rgo J3: string
                return;
            case DBClientesSociosDicInfo.CEPSocio:
                FCEPSocio = $"{value}"; // rgo J3: string
                return;
            case DBClientesSociosDicInfo.CidadeSocio:
                FCidadeSocio = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBClientesSociosDicInfo.RGDataExp:
                FRGDataExp = $"{value}"; // rgo J3: DateTime
                return;
            case DBClientesSociosDicInfo.SocioEmpresaAdminSomente:
                FSocioEmpresaAdminSomente = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBClientesSociosDicInfo.Tipo:
                FTipo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBClientesSociosDicInfo.Fax:
                FFax = $"{value}"; // rgo J3: string
                return;
            case DBClientesSociosDicInfo.Class:
                FClass = $"{value}"; // rgo J3: string
                return;
            case DBClientesSociosDicInfo.Etiqueta:
                FEtiqueta = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBClientesSociosDicInfo.Ani:
                FAni = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBClientesSociosDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBClientesSociosDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBClientesSociosDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBClientesSociosDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBClientesSociosDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBClientesSociosDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBClientesSociosDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBClientesSociosDicInfo.SomenteRepresentante => FSomenteRepresentante.ToString(),
        DBClientesSociosDicInfo.Idade => NFIdade(),
        DBClientesSociosDicInfo.IsRepresentanteLegal => FIsRepresentanteLegal.ToString(),
        DBClientesSociosDicInfo.Qualificacao => NFQualificacao(),
        DBClientesSociosDicInfo.Sexo => FSexo.ToString(),
        DBClientesSociosDicInfo.DtNasc => NFDtNasc(),
        DBClientesSociosDicInfo.Nome => NFNome(),
        DBClientesSociosDicInfo.Site => NFSite(),
        DBClientesSociosDicInfo.RepresentanteLegal => NFRepresentanteLegal(),
        DBClientesSociosDicInfo.Cliente => NFCliente(),
        DBClientesSociosDicInfo.Endereco => NFEndereco(),
        DBClientesSociosDicInfo.Bairro => NFBairro(),
        DBClientesSociosDicInfo.CEP => NFCEP(),
        DBClientesSociosDicInfo.Cidade => NFCidade(),
        DBClientesSociosDicInfo.RG => NFRG(),
        DBClientesSociosDicInfo.CPF => NFCPF(),
        DBClientesSociosDicInfo.Fone => NFFone(),
        DBClientesSociosDicInfo.Participacao => NFParticipacao(),
        DBClientesSociosDicInfo.Cargo => NFCargo(),
        DBClientesSociosDicInfo.EMail => NFEMail(),
        DBClientesSociosDicInfo.Obs => NFObs(),
        DBClientesSociosDicInfo.CNH => NFCNH(),
        DBClientesSociosDicInfo.DataContrato => NFDataContrato(),
        DBClientesSociosDicInfo.CNPJ => NFCNPJ(),
        DBClientesSociosDicInfo.InscEst => NFInscEst(),
        DBClientesSociosDicInfo.SocioEmpresaAdminNome => NFSocioEmpresaAdminNome(),
        DBClientesSociosDicInfo.EnderecoSocio => NFEnderecoSocio(),
        DBClientesSociosDicInfo.BairroSocio => NFBairroSocio(),
        DBClientesSociosDicInfo.CEPSocio => NFCEPSocio(),
        DBClientesSociosDicInfo.CidadeSocio => NFCidadeSocio(),
        DBClientesSociosDicInfo.RGDataExp => NFRGDataExp(),
        DBClientesSociosDicInfo.SocioEmpresaAdminSomente => FSocioEmpresaAdminSomente.ToString(),
        DBClientesSociosDicInfo.Tipo => FTipo.ToString(),
        DBClientesSociosDicInfo.Fax => NFFax(),
        DBClientesSociosDicInfo.Class => NFClass(),
        DBClientesSociosDicInfo.Etiqueta => FEtiqueta.ToString(),
        DBClientesSociosDicInfo.Ani => FAni.ToString(),
        DBClientesSociosDicInfo.Bold => FBold.ToString(),
        DBClientesSociosDicInfo.GUID => NFGUID(),
        DBClientesSociosDicInfo.QuemCad => NFQuemCad(),
        DBClientesSociosDicInfo.DtCad => MDtCad,
        DBClientesSociosDicInfo.QuemAtu => NFQuemAtu(),
        DBClientesSociosDicInfo.DtAtu => MDtAtu,
        DBClientesSociosDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}