namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBParteCliente
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBParteClienteDicInfo.Cliente:
                FCliente = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBParteClienteDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBParteClienteDicInfo.Cliente => NFCliente(),
        DBParteClienteDicInfo.Processo => NFProcesso(),
        _ => nameof(GetValueByNameField)};
}