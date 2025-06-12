#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAlertasWhere
{
    AlertasResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
}

public partial class Alertas : IAlertasWhere
{
    public AlertasResponse Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAlertas(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        var alertas = new AlertasResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Operador = dbRec.FOperador,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            alertas.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FDataAte, out _))
            alertas.DataAte = dbRec.FDataAte;
        return alertas;
    }
}