namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBTipoOrigemSucumbencia
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBTipoOrigemSucumbenciaDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBTipoOrigemSucumbenciaDicInfo.Nome => NFNome(),
        _ => nameof(GetValueByNameField)};
}