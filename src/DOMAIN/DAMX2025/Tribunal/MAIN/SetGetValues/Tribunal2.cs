namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBTribunal
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBTribunalDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBTribunalDicInfo.Area:
                FArea = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBTribunalDicInfo.Justica:
                FJustica = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBTribunalDicInfo.Descricao:
                FDescricao = $"{value}"; // rgo J3: string
                return;
            case DBTribunalDicInfo.Instancia:
                FInstancia = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBTribunalDicInfo.Sigla:
                FSigla = $"{value}"; // rgo J3: string
                return;
            case DBTribunalDicInfo.Web:
                FWeb = $"{value}"; // rgo J3: string
                return;
            case DBTribunalDicInfo.Etiqueta:
                FEtiqueta = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBTribunalDicInfo.Bold:
                FBold = $"{value}".Equals("True"); // rgo J3: bool
                return;
            case DBTribunalDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
            case DBTribunalDicInfo.QuemCad:
                FQuemCad = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBTribunalDicInfo.DtCad:
                FDtCad = $"{value}"; // rgo J3: DateTime
                return;
            case DBTribunalDicInfo.QuemAtu:
                FQuemAtu = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBTribunalDicInfo.DtAtu:
                FDtAtu = $"{value}"; // rgo J3: DateTime
                return;
            case DBTribunalDicInfo.Visto:
                FVisto = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBTribunalDicInfo.Nome => NFNome(),
        DBTribunalDicInfo.Area => NFArea(),
        DBTribunalDicInfo.Justica => NFJustica(),
        DBTribunalDicInfo.Descricao => NFDescricao(),
        DBTribunalDicInfo.Instancia => NFInstancia(),
        DBTribunalDicInfo.Sigla => NFSigla(),
        DBTribunalDicInfo.Web => NFWeb(),
        DBTribunalDicInfo.Etiqueta => FEtiqueta.ToString(),
        DBTribunalDicInfo.Bold => FBold.ToString(),
        DBTribunalDicInfo.GUID => NFGUID(),
        DBTribunalDicInfo.QuemCad => NFQuemCad(),
        DBTribunalDicInfo.DtCad => MDtCad,
        DBTribunalDicInfo.QuemAtu => NFQuemAtu(),
        DBTribunalDicInfo.DtAtu => MDtAtu,
        DBTribunalDicInfo.Visto => FVisto.ToString(),
        _ => nameof(GetValueByNameField)};
}