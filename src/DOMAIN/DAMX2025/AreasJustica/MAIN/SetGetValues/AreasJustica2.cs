namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAreasJustica
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBAreasJusticaDicInfo.Area:
                FArea = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAreasJusticaDicInfo.Justica:
                FJustica = Convert.ToInt32(value); // rgo J3: int
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBAreasJusticaDicInfo.Area => NFArea(),
        DBAreasJusticaDicInfo.Justica => NFJustica(),
        _ => nameof(GetValueByNameField)};
}