namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBTipoStatusBiu
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBTipoStatusBiuDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBTipoStatusBiuDicInfo.Nome => NFNome(),
        _ => nameof(GetValueByNameField)};
}