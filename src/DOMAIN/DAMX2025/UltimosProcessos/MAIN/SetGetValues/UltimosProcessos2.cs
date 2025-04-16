namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBUltimosProcessos
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBUltimosProcessosDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBUltimosProcessosDicInfo.Quando:
                FQuando = $"{value}"; // rgo J3: DateTime
                return;
            case DBUltimosProcessosDicInfo.Quem:
                FQuem = Convert.ToInt32(value); // rgo J3: int
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBUltimosProcessosDicInfo.Processo => NFProcesso(),
        DBUltimosProcessosDicInfo.Quando => NFQuando(),
        DBUltimosProcessosDicInfo.Quem => NFQuem(),
        _ => nameof(GetValueByNameField)};
}