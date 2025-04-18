#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAnexamentoRegistrosReader
{
    AnexamentoRegistrosResponse? Read(int id, SqlConnection oCnn);
    AnexamentoRegistrosResponse? Read(string where, SqlConnection oCnn);
    AnexamentoRegistrosResponse? Read(Entity.DBAnexamentoRegistros dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    AnexamentoRegistrosResponse? Read(DBAnexamentoRegistros dbRec);
}

public partial class AnexamentoRegistros : IAnexamentoRegistrosReader
{
    public AnexamentoRegistrosResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAnexamentoRegistros(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AnexamentoRegistrosResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAnexamentoRegistros(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AnexamentoRegistrosResponse? Read(Entity.DBAnexamentoRegistros dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var anexamentoregistros = new AnexamentoRegistrosResponse
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            CodigoReg = dbRec.FCodigoReg,
            IDReg = dbRec.FIDReg,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            anexamentoregistros.Data = dbRec.FData;
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
        anexamentoregistros.Auditor = auditor;
        return anexamentoregistros;
    }

    public AnexamentoRegistrosResponse? Read(DBAnexamentoRegistros dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var anexamentoregistros = new AnexamentoRegistrosResponse
        {
            Id = dbRec.ID,
            Cliente = dbRec.FCliente,
            CodigoReg = dbRec.FCodigoReg,
            IDReg = dbRec.FIDReg,
            Guid = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            anexamentoregistros.Data = dbRec.FData;
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
        anexamentoregistros.Auditor = auditor;
        return anexamentoregistros;
    }
}