namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBTribEnderecos
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBTribEnderecosDicInfo.Tribunal:
                FTribunal = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBTribEnderecosDicInfo.Cidade:
                FCidade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBTribEnderecosDicInfo.Endereco:
                FEndereco = $"{value}"; // rgo J3: string
                return;
            case DBTribEnderecosDicInfo.CEP:
                FCEP = $"{value}"; // rgo J3: string
                return;
            case DBTribEnderecosDicInfo.Fone:
                FFone = $"{value}"; // rgo J3: string
                return;
            case DBTribEnderecosDicInfo.Fax:
                FFax = $"{value}"; // rgo J3: string
                return;
            case DBTribEnderecosDicInfo.OBS:
                FOBS = $"{value}"; // rgo J3: string
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBTribEnderecosDicInfo.Tribunal => NFTribunal(),
        DBTribEnderecosDicInfo.Cidade => NFCidade(),
        DBTribEnderecosDicInfo.Endereco => NFEndereco(),
        DBTribEnderecosDicInfo.CEP => NFCEP(),
        DBTribEnderecosDicInfo.Fone => NFFone(),
        DBTribEnderecosDicInfo.Fax => NFFax(),
        DBTribEnderecosDicInfo.OBS => NFOBS(),
        _ => nameof(GetValueByNameField)};
}