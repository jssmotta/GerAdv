#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPoderJudiciarioAssociadoReader
{
    PoderJudiciarioAssociadoResponse? Read(int id, MsiSqlConnection oCnn);
    PoderJudiciarioAssociadoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    PoderJudiciarioAssociadoResponse? Read(Entity.DBPoderJudiciarioAssociado dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    PoderJudiciarioAssociadoResponse? Read(DBPoderJudiciarioAssociado dbRec);
    PoderJudiciarioAssociadoResponseAll? ReadAll(DBPoderJudiciarioAssociado dbRec, DataRow dr);
}

public partial class PoderJudiciarioAssociado : IPoderJudiciarioAssociadoReader
{
    public PoderJudiciarioAssociadoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPoderJudiciarioAssociado(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PoderJudiciarioAssociadoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPoderJudiciarioAssociado(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PoderJudiciarioAssociadoResponse? Read(Entity.DBPoderJudiciarioAssociado dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var poderjudiciarioassociado = new PoderJudiciarioAssociadoResponse
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            JusticaNome = dbRec.FJusticaNome ?? string.Empty,
            Area = dbRec.FArea,
            AreaNome = dbRec.FAreaNome ?? string.Empty,
            Tribunal = dbRec.FTribunal,
            TribunalNome = dbRec.FTribunalNome ?? string.Empty,
            Foro = dbRec.FForo,
            ForoNome = dbRec.FForoNome ?? string.Empty,
            Cidade = dbRec.FCidade,
            SubDivisaoNome = dbRec.FSubDivisaoNome ?? string.Empty,
            CidadeNome = dbRec.FCidadeNome ?? string.Empty,
            SubDivisao = dbRec.FSubDivisao,
            Tipo = dbRec.FTipo,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return poderjudiciarioassociado;
    }

    public PoderJudiciarioAssociadoResponse? Read(DBPoderJudiciarioAssociado dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var poderjudiciarioassociado = new PoderJudiciarioAssociadoResponse
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            JusticaNome = dbRec.FJusticaNome ?? string.Empty,
            Area = dbRec.FArea,
            AreaNome = dbRec.FAreaNome ?? string.Empty,
            Tribunal = dbRec.FTribunal,
            TribunalNome = dbRec.FTribunalNome ?? string.Empty,
            Foro = dbRec.FForo,
            ForoNome = dbRec.FForoNome ?? string.Empty,
            Cidade = dbRec.FCidade,
            SubDivisaoNome = dbRec.FSubDivisaoNome ?? string.Empty,
            CidadeNome = dbRec.FCidadeNome ?? string.Empty,
            SubDivisao = dbRec.FSubDivisao,
            Tipo = dbRec.FTipo,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return poderjudiciarioassociado;
    }

    public PoderJudiciarioAssociadoResponseAll? ReadAll(DBPoderJudiciarioAssociado dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var poderjudiciarioassociado = new PoderJudiciarioAssociadoResponseAll
        {
            Id = dbRec.ID,
            Justica = dbRec.FJustica,
            JusticaNome = dbRec.FJusticaNome ?? string.Empty,
            Area = dbRec.FArea,
            AreaNome = dbRec.FAreaNome ?? string.Empty,
            Tribunal = dbRec.FTribunal,
            TribunalNome = dbRec.FTribunalNome ?? string.Empty,
            Foro = dbRec.FForo,
            ForoNome = dbRec.FForoNome ?? string.Empty,
            Cidade = dbRec.FCidade,
            SubDivisaoNome = dbRec.FSubDivisaoNome ?? string.Empty,
            CidadeNome = dbRec.FCidadeNome ?? string.Empty,
            SubDivisao = dbRec.FSubDivisao,
            Tipo = dbRec.FTipo,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        poderjudiciarioassociado.NomeJustica = dr["jusNome"]?.ToString() ?? string.Empty;
        poderjudiciarioassociado.DescricaoArea = dr["areDescricao"]?.ToString() ?? string.Empty;
        poderjudiciarioassociado.NomeTribunal = dr["triNome"]?.ToString() ?? string.Empty;
        poderjudiciarioassociado.NomeForo = dr["forNome"]?.ToString() ?? string.Empty;
        poderjudiciarioassociado.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return poderjudiciarioassociado;
    }
}