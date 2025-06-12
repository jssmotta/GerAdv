#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IGUTAtividadesReader
{
    GUTAtividadesResponse? Read(int id, MsiSqlConnection oCnn);
    GUTAtividadesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GUTAtividadesResponse? Read(Entity.DBGUTAtividades dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    GUTAtividadesResponse? Read(DBGUTAtividades dbRec);
    GUTAtividadesResponseAll? ReadAll(DBGUTAtividades dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class GUTAtividades : IGUTAtividadesReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) agtCodigo, agtNome FROM {"GUTAtividades".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}agtNome");
        }

        return query.ToString();
    }

    public GUTAtividadesResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTAtividades(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTAtividadesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBGUTAtividades(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public GUTAtividadesResponse? Read(Entity.DBGUTAtividades dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutatividades = new GUTAtividadesResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            GUTGrupo = dbRec.FGUTGrupo,
            GUTPeriodicidade = dbRec.FGUTPeriodicidade,
            Operador = dbRec.FOperador,
            Concluido = dbRec.FConcluido,
            DiasParaIniciar = dbRec.FDiasParaIniciar,
            MinutosParaRealizar = dbRec.FMinutosParaRealizar,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataConcluido, out _))
            gutatividades.DataConcluido = dbRec.FDataConcluido;
        return gutatividades;
    }

    public GUTAtividadesResponse? Read(DBGUTAtividades dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutatividades = new GUTAtividadesResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            GUTGrupo = dbRec.FGUTGrupo,
            GUTPeriodicidade = dbRec.FGUTPeriodicidade,
            Operador = dbRec.FOperador,
            Concluido = dbRec.FConcluido,
            DiasParaIniciar = dbRec.FDiasParaIniciar,
            MinutosParaRealizar = dbRec.FMinutosParaRealizar,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataConcluido, out _))
            gutatividades.DataConcluido = dbRec.FDataConcluido;
        return gutatividades;
    }

    public GUTAtividadesResponseAll? ReadAll(DBGUTAtividades dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var gutatividades = new GUTAtividadesResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            GUTGrupo = dbRec.FGUTGrupo,
            GUTPeriodicidade = dbRec.FGUTPeriodicidade,
            Operador = dbRec.FOperador,
            Concluido = dbRec.FConcluido,
            DiasParaIniciar = dbRec.FDiasParaIniciar,
            MinutosParaRealizar = dbRec.FMinutosParaRealizar,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataConcluido, out _))
            gutatividades.DataConcluido = dbRec.FDataConcluido;
        gutatividades.NomeGUTPeriodicidade = dr["pcgNome"]?.ToString() ?? string.Empty;
        gutatividades.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return gutatividades;
    }
}