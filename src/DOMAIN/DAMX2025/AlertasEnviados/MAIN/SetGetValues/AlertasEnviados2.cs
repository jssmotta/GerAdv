namespace MenphisSI.GerAdv;
// ReSharper disable once InconsistentNaming
public partial class DBAlertasEnviados
{
    public void SetValueByNameField(string nomeCampo, object value)
    {
        switch (nomeCampo)
        {
            case DBAlertasEnviadosDicInfo.Operador:
                FOperador = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAlertasEnviadosDicInfo.Alerta:
                FAlerta = Convert.ToInt32(value); // rgo J3: int
                return;
            case DBAlertasEnviadosDicInfo.DataAlertado:
                FDataAlertado = $"{value}"; // rgo J3: DateTime
                return;
            case DBAlertasEnviadosDicInfo.Visualizado:
                FVisualizado = $"{value}".Equals("True"); // rgo J3: bool
                return;
        }
    }

    public object GetValueByNameField(string nomeCampo) => nomeCampo switch
    {
        DBAlertasEnviadosDicInfo.Operador => NFOperador(),
        DBAlertasEnviadosDicInfo.Alerta => NFAlerta(),
        DBAlertasEnviadosDicInfo.DataAlertado => NFDataAlertado(),
        DBAlertasEnviadosDicInfo.Visualizado => FVisualizado.ToString(),
        _ => nameof(GetValueByNameField)};
}