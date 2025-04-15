namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBOponentesRepLegal
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBOponentesRepLegalDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBOponentesRepLegalDicInfo.Fone:
                FFone = $"{value}"; // rgo J3: string
                return;
            case DBOponentesRepLegalDicInfo.Oponente:
                FOponente = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOponentesRepLegalDicInfo.Sexo:
                FSexo = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOponentesRepLegalDicInfo.CPF:
                FCPF = $"{value}"; // rgo J3: string
                return;
            case DBOponentesRepLegalDicInfo.RG:
                FRG = $"{value}"; // rgo J3: string
                return;
            case DBOponentesRepLegalDicInfo.Endereco:
                FEndereco = $"{value}"; // rgo J3: string
                return;
            case DBOponentesRepLegalDicInfo.Bairro:
                FBairro = $"{value}"; // rgo J3: string
                return;
            case DBOponentesRepLegalDicInfo.CEP:
                FCEP = $"{value}"; // rgo J3: string
                return;
            case DBOponentesRepLegalDicInfo.Cidade:
                FCidade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOponentesRepLegalDicInfo.Fax:
                FFax = $"{value}"; // rgo J3: string
                return;
            case DBOponentesRepLegalDicInfo.EMail:
                FEMail = $"{value}"; // rgo J3: string
                return;
            case DBOponentesRepLegalDicInfo.Site:
                FSite = $"{value}"; // rgo J3: string
                return;
            case DBOponentesRepLegalDicInfo.Observacao:
                FObservacao = $"{value}"; // rgo J3: string
                return;
            case DBOponentesRepLegalDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBOponentesRepLegalDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOponentesRepLegalDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBOponentesRepLegalDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBOponentesRepLegalDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBOponentesRepLegalDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBOponentesRepLegalDicInfo.Nome => NFNome(),
        DBOponentesRepLegalDicInfo.Fone => NFFone(),
        DBOponentesRepLegalDicInfo.Oponente => NFOponente(),
        DBOponentesRepLegalDicInfo.Sexo => FSexo.ToString(),
        DBOponentesRepLegalDicInfo.CPF => NFCPF(),
        DBOponentesRepLegalDicInfo.RG => NFRG(),
        DBOponentesRepLegalDicInfo.Endereco => NFEndereco(),
        DBOponentesRepLegalDicInfo.Bairro => NFBairro(),
        DBOponentesRepLegalDicInfo.CEP => NFCEP(),
        DBOponentesRepLegalDicInfo.Cidade => NFCidade(),
        DBOponentesRepLegalDicInfo.Fax => NFFax(),
        DBOponentesRepLegalDicInfo.EMail => NFEMail(),
        DBOponentesRepLegalDicInfo.Site => NFSite(),
        DBOponentesRepLegalDicInfo.Observacao => NFObservacao(),
        DBOponentesRepLegalDicInfo.Bold => FBold.ToString(),
        DBOponentesRepLegalDicInfo.QuemCad => NFQuemCad(),
        DBOponentesRepLegalDicInfo.DtCad => MDtCad,
        DBOponentesRepLegalDicInfo.QuemAtu => NFQuemAtu(),
        DBOponentesRepLegalDicInfo.DtAtu => MDtAtu,
        DBOponentesRepLegalDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}