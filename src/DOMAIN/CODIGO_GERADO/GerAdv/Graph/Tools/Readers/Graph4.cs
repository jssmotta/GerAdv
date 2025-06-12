#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGraphReader
{
    GraphResponse? Read(int id, MsiSqlConnection oCnn);
    GraphResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GraphResponse? Read(Entity.DBGraph dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GraphResponse? Read(DBGraph dbRec);
    GraphResponseAll? ReadAll(DBGraph dbRec, DataRow dr);
}

public partial class Graph : IGraphReader
{
    public GraphResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGraph(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GraphResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGraph(sqlWhere: where, parameters: parameters, oCnn: oCnn);
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
            GUID = dbRec.FGUID ?? string.Empty,
        };
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
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return graph;
    }

    public GraphResponseAll? ReadAll(DBGraph dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var graph = new GraphResponseAll
        {
            Id = dbRec.ID,
            Tabela = dbRec.FTabela ?? string.Empty,
            TabelaId = dbRec.FTabelaId,
            Imagem = dbRec.FImagem,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return graph;
    }
}