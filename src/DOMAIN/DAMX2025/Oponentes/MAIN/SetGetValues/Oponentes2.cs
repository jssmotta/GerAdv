namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBOponentes
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBOponentesDicInfo.EMPFuncao:
                FEMPFuncao = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOponentesDicInfo.CTPSNumero:
                FCTPSNumero = $"{value}"; // rgo J3: string
                return;
            case DBOponentesDicInfo.Site:
                FSite = $"{value}"; // rgo J3: string
                return;
            case DBOponentesDicInfo.CTPSSerie:
                FCTPSSerie = $"{value}"; // rgo J3: string
                return;
            case DBOponentesDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBOponentesDicInfo.Adv:
                FAdv = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOponentesDicInfo.EMPCliente:
                FEMPCliente = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOponentesDicInfo.IDRep:
                FIDRep = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOponentesDicInfo.PIS:
                FPIS = $"{value}"; // rgo J3: string
                return;
            case DBOponentesDicInfo.Contato:
                FContato = $"{value}"; // rgo J3: string
                return;
            case DBOponentesDicInfo.CNPJ:
                FCNPJ = $"{value}"; // rgo J3: string
                return;
            case DBOponentesDicInfo.RG:
                FRG = $"{value}"; // rgo J3: string
                return;
            case DBOponentesDicInfo.Juridica:
                FJuridica = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOponentesDicInfo.Tipo:
                FTipo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOponentesDicInfo.Sexo:
                FSexo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOponentesDicInfo.CPF:
                FCPF = $"{value}"; // rgo J3: string
                return;
            case DBOponentesDicInfo.Endereco:
                FEndereco = $"{value}"; // rgo J3: string
                return;
            case DBOponentesDicInfo.Fone:
                FFone = $"{value}"; // rgo J3: string
                return;
            case DBOponentesDicInfo.Fax:
                FFax = $"{value}"; // rgo J3: string
                return;
            case DBOponentesDicInfo.Cidade:
                FCidade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOponentesDicInfo.Bairro:
                FBairro = $"{value}"; // rgo J3: string
                return;
            case DBOponentesDicInfo.CEP:
                FCEP = $"{value}"; // rgo J3: string
                return;
            case DBOponentesDicInfo.InscEst:
                FInscEst = $"{value}"; // rgo J3: string
                return;
            case DBOponentesDicInfo.Observacao:
                FObservacao = $"{value}"; // rgo J3: string
                return;
            case DBOponentesDicInfo.EMail:
                FEMail = $"{value}"; // rgo J3: string
                return;
            case DBOponentesDicInfo.Class:
                FClass = $"{value}"; // rgo J3: string
                return;
            case DBOponentesDicInfo.Top:
                FTop = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOponentesDicInfo.Etiqueta:
                FEtiqueta = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOponentesDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOponentesDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBOponentesDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOponentesDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBOponentesDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOponentesDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBOponentesDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBOponentesDicInfo.EMPFuncao => NFEMPFuncao(),
        DBOponentesDicInfo.CTPSNumero => NFCTPSNumero(),
        DBOponentesDicInfo.Site => NFSite(),
        DBOponentesDicInfo.CTPSSerie => NFCTPSSerie(),
        DBOponentesDicInfo.Nome => NFNome(),
        DBOponentesDicInfo.Adv => NFAdv(),
        DBOponentesDicInfo.EMPCliente => NFEMPCliente(),
        DBOponentesDicInfo.IDRep => NFIDRep(),
        DBOponentesDicInfo.PIS => NFPIS(),
        DBOponentesDicInfo.Contato => NFContato(),
        DBOponentesDicInfo.CNPJ => NFCNPJ(),
        DBOponentesDicInfo.RG => NFRG(),
        DBOponentesDicInfo.Juridica => FJuridica.ToString(),
        DBOponentesDicInfo.Tipo => FTipo.ToString(),
        DBOponentesDicInfo.Sexo => FSexo.ToString(),
        DBOponentesDicInfo.CPF => NFCPF(),
        DBOponentesDicInfo.Endereco => NFEndereco(),
        DBOponentesDicInfo.Fone => NFFone(),
        DBOponentesDicInfo.Fax => NFFax(),
        DBOponentesDicInfo.Cidade => NFCidade(),
        DBOponentesDicInfo.Bairro => NFBairro(),
        DBOponentesDicInfo.CEP => NFCEP(),
        DBOponentesDicInfo.InscEst => NFInscEst(),
        DBOponentesDicInfo.Observacao => NFObservacao(),
        DBOponentesDicInfo.EMail => NFEMail(),
        DBOponentesDicInfo.Class => NFClass(),
        DBOponentesDicInfo.Top => FTop.ToString(),
        DBOponentesDicInfo.Etiqueta => FEtiqueta.ToString(),
        DBOponentesDicInfo.Bold => FBold.ToString(),
        DBOponentesDicInfo.GUID => NFGUID(),
        DBOponentesDicInfo.QuemCad => NFQuemCad(),
        DBOponentesDicInfo.DtCad => MDtCad,
        DBOponentesDicInfo.QuemAtu => NFQuemAtu(),
        DBOponentesDicInfo.DtAtu => MDtAtu,
        DBOponentesDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}