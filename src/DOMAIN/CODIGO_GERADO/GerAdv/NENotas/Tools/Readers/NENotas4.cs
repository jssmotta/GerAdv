#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface INENotasReader
{
    NENotasResponse? Read(int id, MsiSqlConnection oCnn);
    NENotasResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    NENotasResponse? Read(Entity.DBNENotas dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    NENotasResponse? Read(DBNENotas dbRec);
    NENotasResponseAll? ReadAll(DBNENotas dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class NENotas : INENotasReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) nepCodigo, nepNome FROM {"NENotas".dbo(oCnn)} (NOLOCK) ");
        if (!string.IsNullOrEmpty(whereClause))
        {
            query.Append(!whereClause.ToUpperInvariant().Contains(TSql.Where, StringComparison.OrdinalIgnoreCase) ? TSql.Where : string.Empty).Append(whereClause);
        }

        if (!string.IsNullOrEmpty(orderClause))
        {
            query.Append(!orderClause.ToUpperInvariant().Contains(TSql.OrderBy, StringComparison.OrdinalIgnoreCase) ? TSql.OrderBy : string.Empty).Append(orderClause);
        }
        else
        {
            query.Append($"{TSql.OrderBy}nepNome");
        }

        return query.ToString();
    }

    public NENotasResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBNENotas(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public NENotasResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBNENotas(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public NENotasResponse? Read(Entity.DBNENotas dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var nenotas = new NENotasResponse
        {
            Id = dbRec.ID,
            Apenso = dbRec.FApenso,
            Precatoria = dbRec.FPrecatoria,
            Instancia = dbRec.FInstancia,
            MovPro = dbRec.FMovPro,
            Nome = dbRec.FNome ?? string.Empty,
            NotaExpedida = dbRec.FNotaExpedida,
            Revisada = dbRec.FRevisada,
            Processo = dbRec.FProcesso,
            PalavraChave = dbRec.FPalavraChave,
            NotaPublicada = dbRec.FNotaPublicada ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            nenotas.Data = dbRec.FData;
        return nenotas;
    }

    public NENotasResponse? Read(DBNENotas dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var nenotas = new NENotasResponse
        {
            Id = dbRec.ID,
            Apenso = dbRec.FApenso,
            Precatoria = dbRec.FPrecatoria,
            Instancia = dbRec.FInstancia,
            MovPro = dbRec.FMovPro,
            Nome = dbRec.FNome ?? string.Empty,
            NotaExpedida = dbRec.FNotaExpedida,
            Revisada = dbRec.FRevisada,
            Processo = dbRec.FProcesso,
            PalavraChave = dbRec.FPalavraChave,
            NotaPublicada = dbRec.FNotaPublicada ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            nenotas.Data = dbRec.FData;
        return nenotas;
    }

    public NENotasResponseAll? ReadAll(DBNENotas dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var nenotas = new NENotasResponseAll
        {
            Id = dbRec.ID,
            Apenso = dbRec.FApenso,
            Precatoria = dbRec.FPrecatoria,
            Instancia = dbRec.FInstancia,
            MovPro = dbRec.FMovPro,
            Nome = dbRec.FNome ?? string.Empty,
            NotaExpedida = dbRec.FNotaExpedida,
            Revisada = dbRec.FRevisada,
            Processo = dbRec.FProcesso,
            PalavraChave = dbRec.FPalavraChave,
            NotaPublicada = dbRec.FNotaPublicada ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            nenotas.Data = dbRec.FData;
        nenotas.NroProcessoInstancia = dr["insNroProcesso"]?.ToString() ?? string.Empty;
        nenotas.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return nenotas;
    }
}