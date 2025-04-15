namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBParteOponente
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBParteOponenteDicInfo.Oponente:
                FOponente = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBParteOponenteDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBParteOponenteDicInfo.Oponente => NFOponente(),
        DBParteOponenteDicInfo.Processo => NFProcesso(),
        _ => nameof(GetValueByNameField)};
}