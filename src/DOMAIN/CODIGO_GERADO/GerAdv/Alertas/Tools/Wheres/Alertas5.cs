#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Wheres;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAlertasWhere
{
    AlertasResponse Read(string where, SqlConnection oCnn);
}

public partial class Alertas : IAlertasWhere
{
    public AlertasResponse Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAlertas(sqlWhere: where, oCnn: oCnn);
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
        var auditor = new Auditor
        {
            Visto = dbRec.FVisto,
            QuemCad = dbRec.FQuemCad
        };
        if (auditor.QuemAtu > 0)
            auditor.QuemAtu = dbRec.FQuemAtu;
        if (dbRec.FDtCad.NotIsEmpty())
            auditor.DtCad = Convert.ToDateTime(dbRec.FDtCad);
        if (!(dbRec.FDtAtu is { }))
            auditor.DtAtu = Convert.ToDateTime(dbRec.FDtAtu);
        alertas.Auditor = auditor;
        return alertas;
    }
}