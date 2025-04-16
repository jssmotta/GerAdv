#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAlertasReader
{
    AlertasResponse? Read(int id, SqlConnection oCnn);
    AlertasResponse? Read(string where, SqlConnection oCnn);
    AlertasResponse? Read(Entity.DBAlertas dbRec);
    AlertasResponse? Read(DBAlertas dbRec);
}

public partial class Alertas : IAlertasReader
{
    public AlertasResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAlertas(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AlertasResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAlertas(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AlertasResponse? Read(Entity.DBAlertas dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

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

    public AlertasResponse? Read(DBAlertas dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

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