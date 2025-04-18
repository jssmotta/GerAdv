#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAtividadesReader
{
    AtividadesResponse? Read(int id, SqlConnection oCnn);
    AtividadesResponse? Read(string where, SqlConnection oCnn);
    AtividadesResponse? Read(Entity.DBAtividades dbRec);
    Task<string> ReadStringAuditor(int id, string uri, SqlConnection oCnn);
    AtividadesResponse? Read(DBAtividades dbRec);
}

public partial class Atividades : IAtividadesReader
{
    public AtividadesResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAtividades(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AtividadesResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAtividades(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AtividadesResponse? Read(Entity.DBAtividades dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var atividades = new AtividadesResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
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
        atividades.Auditor = auditor;
        return atividades;
    }

    public AtividadesResponse? Read(DBAtividades dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var atividades = new AtividadesResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
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
        atividades.Auditor = auditor;
        return atividades;
    }
}