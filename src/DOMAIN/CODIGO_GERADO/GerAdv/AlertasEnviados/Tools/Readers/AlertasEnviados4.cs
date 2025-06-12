#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAlertasEnviadosReader
{
    AlertasEnviadosResponse? Read(int id, MsiSqlConnection oCnn);
    AlertasEnviadosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AlertasEnviadosResponse? Read(Entity.DBAlertasEnviados dbRec);
    AlertasEnviadosResponse? Read(DBAlertasEnviados dbRec);
    AlertasEnviadosResponseAll? ReadAll(DBAlertasEnviados dbRec, DataRow dr);
}

public partial class AlertasEnviados : IAlertasEnviadosReader
{
    public AlertasEnviadosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAlertasEnviados(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AlertasEnviadosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAlertasEnviados(sqlWhere: where, parameters: parameters, oCnn: oCnn);
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

    public AlertasEnviadosResponseAll? ReadAll(DBAlertasEnviados dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var alertasenviados = new AlertasEnviadosResponseAll
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Alerta = dbRec.FAlerta,
            Visualizado = dbRec.FVisualizado,
        };
        if (DateTime.TryParse(dbRec.FDataAlertado, out _))
            alertasenviados.DataAlertado = dbRec.FDataAlertado;
        alertasenviados.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        alertasenviados.NomeAlertas = dr["altNome"]?.ToString() ?? string.Empty;
        return alertasenviados;
    }
}