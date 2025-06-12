#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Writers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGraphWriter
{
    Entity.DBGraph Write(Models.Graph graph, int auditorQuem, MsiSqlConnection oCnn);
    void Delete(GraphResponse graph, int operadorId, MsiSqlConnection oCnn);
}

public class Graph : IGraphWriter
{
    public void Delete(GraphResponse graph, int operadorId, MsiSqlConnection oCnn)
    {
        ConfiguracoesDBT.ExecuteDelete($"DELETE FROM [{oCnn.UseDbo}].[Graph] WHERE gphCodigo={graph.Id};", oCnn);
    }

    public Entity.DBGraph Write(Models.Graph graph, int auditorQuem, MsiSqlConnection oCnn)
    {
        var dbRec = graph.Id.IsEmptyIDNumber() ? new Entity.DBGraph() : new Entity.DBGraph(graph.Id, oCnn);
        dbRec.FTabela = graph.Tabela;
        dbRec.FTabelaId = graph.TabelaId;
        dbRec.FImagem = graph.Imagem;
        dbRec.FGUID = graph.GUID;
        dbRec.AuditorQuem = auditorQuem;
        dbRec.Update(oCnn);
        return dbRec;
    }
}