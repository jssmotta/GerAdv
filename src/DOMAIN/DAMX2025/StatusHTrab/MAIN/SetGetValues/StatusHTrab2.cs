namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBStatusHTrab
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBStatusHTrabDicInfo.Descricao:
                FDescricao = $"{value}"; // rgo J3: string
                return;
            case DBStatusHTrabDicInfo.ResID:
                FResID = Convert.ToInt32(value); // rgo J3: int
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBStatusHTrabDicInfo.Descricao => NFDescricao(),
        DBStatusHTrabDicInfo.ResID => NFResID(),
        _ => nameof(GetValueByNameField)};
}