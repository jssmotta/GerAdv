namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBProcessosParados
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBProcessosParadosDicInfo.Processo:
                FProcesso = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessosParadosDicInfo.Semana:
                FSemana = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessosParadosDicInfo.Ano:
                FAno = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessosParadosDicInfo.DataHora:
                FDataHora = $"{value}"; // rgo J3: DateTime
                return;
            case DBProcessosParadosDicInfo.Operador:
                FOperador = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBProcessosParadosDicInfo.DataHistorico:
                FDataHistorico = $"{value}"; // rgo J3: DateTime
                return;
            case DBProcessosParadosDicInfo.DataNENotas:
                FDataNENotas = $"{value}"; // rgo J3: DateTime
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBProcessosParadosDicInfo.Processo => NFProcesso(),
        DBProcessosParadosDicInfo.Semana => NFSemana(),
        DBProcessosParadosDicInfo.Ano => NFAno(),
        DBProcessosParadosDicInfo.DataHora => NFDataHora(),
        DBProcessosParadosDicInfo.Operador => NFOperador(),
        DBProcessosParadosDicInfo.DataHistorico => NFDataHistorico(),
        DBProcessosParadosDicInfo.DataNENotas => NFDataNENotas(),
        _ => nameof(GetValueByNameField)};
}