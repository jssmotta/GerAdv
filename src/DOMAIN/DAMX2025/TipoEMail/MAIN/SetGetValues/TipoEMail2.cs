namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBTipoEMail
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBTipoEMailDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBTipoEMailDicInfo.Nome => NFNome(),
        _ => nameof(GetValueByNameField)};
}