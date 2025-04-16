namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBContatoCRMView
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBContatoCRMViewDicInfo.CGUID:
                FCGUID = $"{value}"; // rgo J3: string
                return;
            case DBContatoCRMViewDicInfo.Data:
                FData = $"{value}"; // rgo J3: DateTime
                return;
            case DBContatoCRMViewDicInfo.IP:
                FIP = $"{value}"; // rgo J3: string
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBContatoCRMViewDicInfo.CGUID => NFCGUID(),
        DBContatoCRMViewDicInfo.Data => NFData(),
        DBContatoCRMViewDicInfo.IP => NFIP(),
        _ => nameof(GetValueByNameField)};
}