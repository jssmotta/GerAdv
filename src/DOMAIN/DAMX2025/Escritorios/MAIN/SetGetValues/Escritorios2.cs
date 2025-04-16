namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBEscritorios
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBEscritoriosDicInfo.CNPJ:
                FCNPJ = $"{value}"; // rgo J3: string
                return;
            case DBEscritoriosDicInfo.Casa:
                FCasa = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBEscritoriosDicInfo.Parceria:
                FParceria = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBEscritoriosDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBEscritoriosDicInfo.OAB:
                FOAB = $"{value}"; // rgo J3: string
                return;
            case DBEscritoriosDicInfo.Endereco:
                FEndereco = $"{value}"; // rgo J3: string
                return;
            case DBEscritoriosDicInfo.Cidade:
                FCidade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBEscritoriosDicInfo.Bairro:
                FBairro = $"{value}"; // rgo J3: string
                return;
            case DBEscritoriosDicInfo.CEP:
                FCEP = $"{value}"; // rgo J3: string
                return;
            case DBEscritoriosDicInfo.Fone:
                FFone = $"{value}"; // rgo J3: string
                return;
            case DBEscritoriosDicInfo.Fax:
                FFax = $"{value}"; // rgo J3: string
                return;
            case DBEscritoriosDicInfo.Site:
                FSite = $"{value}"; // rgo J3: string
                return;
            case DBEscritoriosDicInfo.EMail:
                FEMail = $"{value}"; // rgo J3: string
                return;
            case DBEscritoriosDicInfo.OBS:
                FOBS = $"{value}"; // rgo J3: string
                return;
            case DBEscritoriosDicInfo.AdvResponsavel:
                FAdvResponsavel = $"{value}"; // rgo J3: string
                return;
            case DBEscritoriosDicInfo.Secretaria:
                FSecretaria = $"{value}"; // rgo J3: string
                return;
            case DBEscritoriosDicInfo.InscEst:
                FInscEst = $"{value}"; // rgo J3: string
                return;
            case DBEscritoriosDicInfo.Correspondente:
                FCorrespondente = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBEscritoriosDicInfo.Top:
                FTop = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBEscritoriosDicInfo.Etiqueta:
                FEtiqueta = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBEscritoriosDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBEscritoriosDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBEscritoriosDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBEscritoriosDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBEscritoriosDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBEscritoriosDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBEscritoriosDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBEscritoriosDicInfo.CNPJ => NFCNPJ(),
        DBEscritoriosDicInfo.Casa => FCasa.ToString(),
        DBEscritoriosDicInfo.Parceria => FParceria.ToString(),
        DBEscritoriosDicInfo.Nome => NFNome(),
        DBEscritoriosDicInfo.OAB => NFOAB(),
        DBEscritoriosDicInfo.Endereco => NFEndereco(),
        DBEscritoriosDicInfo.Cidade => NFCidade(),
        DBEscritoriosDicInfo.Bairro => NFBairro(),
        DBEscritoriosDicInfo.CEP => NFCEP(),
        DBEscritoriosDicInfo.Fone => NFFone(),
        DBEscritoriosDicInfo.Fax => NFFax(),
        DBEscritoriosDicInfo.Site => NFSite(),
        DBEscritoriosDicInfo.EMail => NFEMail(),
        DBEscritoriosDicInfo.OBS => NFOBS(),
        DBEscritoriosDicInfo.AdvResponsavel => NFAdvResponsavel(),
        DBEscritoriosDicInfo.Secretaria => NFSecretaria(),
        DBEscritoriosDicInfo.InscEst => NFInscEst(),
        DBEscritoriosDicInfo.Correspondente => FCorrespondente.ToString(),
        DBEscritoriosDicInfo.Top => FTop.ToString(),
        DBEscritoriosDicInfo.Etiqueta => FEtiqueta.ToString(),
        DBEscritoriosDicInfo.Bold => FBold.ToString(),
        DBEscritoriosDicInfo.GUID => NFGUID(),
        DBEscritoriosDicInfo.QuemCad => NFQuemCad(),
        DBEscritoriosDicInfo.DtCad => MDtCad,
        DBEscritoriosDicInfo.QuemAtu => NFQuemAtu(),
        DBEscritoriosDicInfo.DtAtu => MDtAtu,
        DBEscritoriosDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}