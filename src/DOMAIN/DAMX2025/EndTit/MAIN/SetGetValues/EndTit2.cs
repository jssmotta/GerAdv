namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBEndTit
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBEndTitDicInfo.Endereco:
                FEndereco = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBEndTitDicInfo.Titulo:
                FTitulo = Convert.ToInt32(value); // rgo J3: int
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBEndTitDicInfo.Endereco => NFEndereco(),
        DBEndTitDicInfo.Titulo => NFTitulo(),
        _ => nameof(GetValueByNameField)};
}