namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProPartes
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBProPartesDicInfo.Parte:
                FParte = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProPartesDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBProPartesDicInfo.Parte => NFParte(),
        DBProPartesDicInfo.Processo => NFProcesso(),
        _ => nameof(GetValueByNameField)};
}