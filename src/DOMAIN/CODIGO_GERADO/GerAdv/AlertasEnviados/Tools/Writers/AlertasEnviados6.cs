#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAlertasEnviadosWriter
{
    Entity.DBAlertasEnviados Write(Models.AlertasEnviados alertasenviados, SqlConnection oCnn);
}

public class AlertasEnviados : IAlertasEnviadosWriter
{
    public Entity.DBAlertasEnviados Write(Models.AlertasEnviados alertasenviados, SqlConnection oCnn)
    {
        var dbRec = alertasenviados.Id.IsEmptyIDNumber() ? new Entity.DBAlertasEnviados() : new Entity.DBAlertasEnviados(alertasenviados.Id, oCnn);
        dbRec.FOperador = alertasenviados.Operador;
        dbRec.FAlerta = alertasenviados.Alerta;
        if (alertasenviados.DataAlertado != null)
            dbRec.FDataAlertado = alertasenviados.DataAlertado.ToString();
        dbRec.FVisualizado = alertasenviados.Visualizado;
        dbRec.Update(oCnn);
        return dbRec;
    }
}