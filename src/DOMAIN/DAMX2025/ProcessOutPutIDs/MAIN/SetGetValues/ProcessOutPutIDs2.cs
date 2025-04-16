namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProcessOutPutIDs
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBProcessOutPutIDsDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBProcessOutPutIDsDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBProcessOutPutIDsDicInfo.Nome => NFNome(),
        DBProcessOutPutIDsDicInfo.GUID => NFGUID(),
        _ => nameof(GetValueByNameField)};
}