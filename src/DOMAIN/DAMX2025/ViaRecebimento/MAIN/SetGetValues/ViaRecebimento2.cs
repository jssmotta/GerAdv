namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBViaRecebimento
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBViaRecebimentoDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBViaRecebimentoDicInfo.Nome => NFNome(),
        _ => nameof(GetValueByNameField)};
}