#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAlertasEnviadosReader
{
    AlertasEnviadosResponse? Read(int id, SqlConnection oCnn);
    AlertasEnviadosResponse? Read(string where, SqlConnection oCnn);
    AlertasEnviadosResponse? Read(Entity.DBAlertasEnviados dbRec);
    AlertasEnviadosResponse? Read(DBAlertasEnviados dbRec);
}

public partial class AlertasEnviados : IAlertasEnviadosReader
{
    public AlertasEnviadosResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAlertasEnviados(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AlertasEnviadosResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAlertasEnviados(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AlertasEnviadosResponse? Read(Entity.DBAlertasEnviados dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var alertasenviados = new AlertasEnviadosResponse
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Alerta = dbRec.FAlerta,
            Visualizado = dbRec.FVisualizado,
        };
        if (DateTime.TryParse(dbRec.FDataAlertado, out _))
            alertasenviados.DataAlertado = dbRec.FDataAlertado;
        return alertasenviados;
    }

    public AlertasEnviadosResponse? Read(DBAlertasEnviados dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var alertasenviados = new AlertasEnviadosResponse
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Alerta = dbRec.FAlerta,
            Visualizado = dbRec.FVisualizado,
        };
        if (DateTime.TryParse(dbRec.FDataAlertado, out _))
            alertasenviados.DataAlertado = dbRec.FDataAlertado;
        return alertasenviados;
    }
}