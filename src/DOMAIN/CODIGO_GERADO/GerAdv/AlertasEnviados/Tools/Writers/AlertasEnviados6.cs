#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAlertasEnviadosWriter
{
    Entity.DBAlertasEnviados Write(Models.AlertasEnviados alertasenviados, MsiSqlConnection oCnn);
    void Delete(AlertasEnviadosResponse alertasenviados, int operadorId, MsiSqlConnection oCnn);
}

public class AlertasEnviados : IAlertasEnviadosWriter
{
    public void Delete(AlertasEnviadosResponse alertasenviados, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[AlertasEnviados] WHERE aloCodigo={alertasenviados.Id};", oCnn);
    }

    public Entity.DBAlertasEnviados Write(Models.AlertasEnviados alertasenviados, MsiSqlConnection oCnn)
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