namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAndComp
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBAndCompDicInfo.Andamento:
                FAndamento = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAndCompDicInfo.Compromisso:
                FCompromisso = Convert.ToInt32(value); // rgo J3: int
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBAndCompDicInfo.Andamento => NFAndamento(),
        DBAndCompDicInfo.Compromisso => NFCompromisso(),
        _ => nameof(GetValueByNameField)};
}