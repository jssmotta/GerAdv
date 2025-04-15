namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAgendaQuem
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBAgendaQuemDicInfo.IDAgenda:
                FIDAgenda = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaQuemDicInfo.Advogado:
                FAdvogado = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaQuemDicInfo.Funcionario:
                FFuncionario = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAgendaQuemDicInfo.Preposto:
                FPreposto = Convert.ToInt32(value); // rgo J3: int
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBAgendaQuemDicInfo.IDAgenda => NFIDAgenda(),
        DBAgendaQuemDicInfo.Advogado => NFAdvogado(),
        DBAgendaQuemDicInfo.Funcionario => NFFuncionario(),
        DBAgendaQuemDicInfo.Preposto => NFPreposto(),
        _ => nameof(GetValueByNameField)};
}