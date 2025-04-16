#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAlertasWriter
{
    Entity.DBAlertas Write(Models.Alertas alertas, int auditorQuem, SqlConnection oCnn);
}

public class Alertas : IAlertasWriter
{
    public Entity.DBAlertas Write(Models.Alertas alertas, int auditorQuem, SqlConnection oCnn)
    {
        var dbRec = alertas.Id.IsEmptyIDNumber() ? new Entity.DBAlertas() : new Entity.DBAlertas(alertas.Id, oCnn);
        dbRec.FNome = alertas.Nome;
        if (alertas.Data != null)
            dbRec.FData = alertas.Data.ToString();
        dbRec.FOperador = alertas.Operador;
        if (alertas.DataAte != null)
            dbRec.FDataAte = alertas.DataAte.ToString();
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}