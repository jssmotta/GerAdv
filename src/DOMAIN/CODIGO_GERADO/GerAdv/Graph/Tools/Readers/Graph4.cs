#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGraphReader
{
    GraphResponse? Read(int id, SqlConnection oCnn);
    GraphResponse? Read(string where, SqlConnection oCnn);
    GraphResponse? Read(Entity.DBGraph dbRec);
    GraphResponse? Read(DBGraph dbRec);
}

public partial class Graph : IGraphReader
{
    public GraphResponse? Read(int id, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGraph(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GraphResponse? Read(string where, SqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGraph(sqlWhere: where, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GraphResponse? Read(Entity.DBGraph dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var graph = new GraphResponse
        {
            Id = dbRec.ID,
            Tabela = dbRec.FTabela ?? string.Empty,
            TabelaId = dbRec.FTabelaId,
            Imagem = dbRec.FImagem,
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
        graph.Auditor = auditor;
        return graph;
    }

    public GraphResponse? Read(DBGraph dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var graph = new GraphResponse
        {
            Id = dbRec.ID,
            Tabela = dbRec.FTabela ?? string.Empty,
            TabelaId = dbRec.FTabelaId,
            Imagem = dbRec.FImagem,
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
        graph.Auditor = auditor;
        return graph;
    }
}