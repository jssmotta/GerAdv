namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProcessOutputSources
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBProcessOutputSourcesDicInfo.Nome:
                FNome = $"{value}"; // rgo J3: string
                return;
            case DBProcessOutputSourcesDicInfo.GUID:
                FGUID = $"{value}"; // rgo J3: string
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBProcessOutputSourcesDicInfo.Nome => NFNome(),
        DBProcessOutputSourcesDicInfo.GUID => NFGUID(),
        _ => nameof(GetValueByNameField)};
}