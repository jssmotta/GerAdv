#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IServicosReader
{
    ServicosResponse? Read(int id, SqlConnection oCnn);
    ServicosResponse? Read(string where, SqlConnection oCnn);
    ServicosResponse? Read(Entity.DBServicos dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    ServicosResponse? Read(DBServicos dbRec);
}

public partial class Servicos : IServicosReader
{
    public ServicosResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBServicos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ServicosResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBServicos(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ServicosResponse? Read(Entity.DBServicos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var servicos = new ServicosResponse
        {
            Id = dbRec.ID,
            Cobrar = dbRec.FCobrar,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Basico = dbRec.FBasico,
            Guid = dbRec.FGUID ?? string.Empty,
        };
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
        servicos.Auditor = auditor;
        return servicos;
    }

    public ServicosResponse? Read(DBServicos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var servicos = new ServicosResponse
        {
            Id = dbRec.ID,
            Cobrar = dbRec.FCobrar,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Basico = dbRec.FBasico,
            Guid = dbRec.FGUID ?? string.Empty,
        };
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
        servicos.Auditor = auditor;
        return servicos;
    }
}