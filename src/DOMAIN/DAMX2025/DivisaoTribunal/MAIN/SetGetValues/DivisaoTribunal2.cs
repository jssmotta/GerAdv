namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBDivisaoTribunal
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBDivisaoTribunalDicInfo.NumCodigo:
                FNumCodigo = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBDivisaoTribunalDicInfo.Justica:
                FJustica = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBDivisaoTribunalDicInfo.NomeEspecial:
                FNomeEspecial = $"{value}"; // rgo J3: string
                return;
            case DBDivisaoTribunalDicInfo.Area:
                FArea = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBDivisaoTribunalDicInfo.Cidade:
                FCidade = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBDivisaoTribunalDicInfo.Foro:
                FForo = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBDivisaoTribunalDicInfo.Tribunal:
                FTribunal = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBDivisaoTribunalDicInfo.CodigoDiv:
                FCodigoDiv = $"{value}"; // rgo J3: string
                return;
            case DBDivisaoTribunalDicInfo.Endereco:
                FEndereco = $"{value}"; // rgo J3: string
                return;
            case DBDivisaoTribunalDicInfo.Fone:
                FFone = $"{value}"; // rgo J3: string
                return;
            case DBDivisaoTribunalDicInfo.Fax:
                FFax = $"{value}"; // rgo J3: string
                return;
            case DBDivisaoTribunalDicInfo.CEP:
                FCEP = $"{value}"; // rgo J3: string
                return;
            case DBDivisaoTribunalDicInfo.Obs:
                FObs = $"{value}"; // rgo J3: string
                return;
            case DBDivisaoTribunalDicInfo.EMail:
                FEMail = $"{value}"; // rgo J3: string
                return;
            case DBDivisaoTribunalDicInfo.Andar:
                FAndar = $"{value}"; // rgo J3: string
                return;
            case DBDivisaoTribunalDicInfo.Etiqueta:
                FEtiqueta = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBDivisaoTribunalDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBDivisaoTribunalDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBDivisaoTribunalDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBDivisaoTribunalDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBDivisaoTribunalDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBDivisaoTribunalDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBDivisaoTribunalDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBDivisaoTribunalDicInfo.NumCodigo => NFNumCodigo(),
        DBDivisaoTribunalDicInfo.Justica => NFJustica(),
        DBDivisaoTribunalDicInfo.NomeEspecial => NFNomeEspecial(),
        DBDivisaoTribunalDicInfo.Area => NFArea(),
        DBDivisaoTribunalDicInfo.Cidade => NFCidade(),
        DBDivisaoTribunalDicInfo.Foro => NFForo(),
        DBDivisaoTribunalDicInfo.Tribunal => NFTribunal(),
        DBDivisaoTribunalDicInfo.CodigoDiv => NFCodigoDiv(),
        DBDivisaoTribunalDicInfo.Endereco => NFEndereco(),
        DBDivisaoTribunalDicInfo.Fone => NFFone(),
        DBDivisaoTribunalDicInfo.Fax => NFFax(),
        DBDivisaoTribunalDicInfo.CEP => NFCEP(),
        DBDivisaoTribunalDicInfo.Obs => NFObs(),
        DBDivisaoTribunalDicInfo.EMail => NFEMail(),
        DBDivisaoTribunalDicInfo.Andar => NFAndar(),
        DBDivisaoTribunalDicInfo.Etiqueta => FEtiqueta.ToString(),
        DBDivisaoTribunalDicInfo.Bold => FBold.ToString(),
        DBDivisaoTribunalDicInfo.GUID => NFGUID(),
        DBDivisaoTribunalDicInfo.QuemCad => NFQuemCad(),
        DBDivisaoTribunalDicInfo.DtCad => MDtCad,
        DBDivisaoTribunalDicInfo.QuemAtu => NFQuemAtu(),
        DBDivisaoTribunalDicInfo.DtAtu => MDtAtu,
        DBDivisaoTribunalDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}