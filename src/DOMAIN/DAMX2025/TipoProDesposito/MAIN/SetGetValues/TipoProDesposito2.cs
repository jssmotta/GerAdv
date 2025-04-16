namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBTipoProDesposito
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBTipoProDespositoDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBTipoProDespositoDicInfo.Nome => NFNome(),
        _ => nameof(GetValueByNameField)};
}