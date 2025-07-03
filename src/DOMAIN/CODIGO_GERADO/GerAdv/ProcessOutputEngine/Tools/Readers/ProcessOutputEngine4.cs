#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProcessOutputEngineReader
{
    ProcessOutputEngineResponse? Read(int id, MsiSqlConnection oCnn);
    ProcessOutputEngineResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProcessOutputEngineResponse? Read(Entity.DBProcessOutputEngine dbRec);
    ProcessOutputEngineResponse? Read(DBProcessOutputEngine dbRec);
    ProcessOutputEngineResponseAll? ReadAll(DBProcessOutputEngine dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ProcessOutputEngine : IProcessOutputEngineReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) poeCodigo, poeNome FROM {"ProcessOutputEngine".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}poeNome");
        }

        return query.ToString();
    }

    public ProcessOutputEngineResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessOutputEngine(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProcessOutputEngineResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProcessOutputEngine(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProcessOutputEngineResponse? Read(Entity.DBProcessOutputEngine dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processoutputengine = new ProcessOutputEngineResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Database = dbRec.FDatabase ?? string.Empty,
            Tabela = dbRec.FTabela ?? string.Empty,
            Campo = dbRec.FCampo ?? string.Empty,
            Valor = dbRec.FValor ?? string.Empty,
            Output = dbRec.FOutput ?? string.Empty,
            Administrador = dbRec.FAdministrador,
            OutputSource = dbRec.FOutputSource,
            DisabledItem = dbRec.FDisabledItem,
            IDModulo = dbRec.FIDModulo,
            IsOnlyProcesso = dbRec.FIsOnlyProcesso,
            MyID = dbRec.FMyID,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return processoutputengine;
    }

    public ProcessOutputEngineResponse? Read(DBProcessOutputEngine dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processoutputengine = new ProcessOutputEngineResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Database = dbRec.FDatabase ?? string.Empty,
            Tabela = dbRec.FTabela ?? string.Empty,
            Campo = dbRec.FCampo ?? string.Empty,
            Valor = dbRec.FValor ?? string.Empty,
            Output = dbRec.FOutput ?? string.Empty,
            Administrador = dbRec.FAdministrador,
            OutputSource = dbRec.FOutputSource,
            DisabledItem = dbRec.FDisabledItem,
            IDModulo = dbRec.FIDModulo,
            IsOnlyProcesso = dbRec.FIsOnlyProcesso,
            MyID = dbRec.FMyID,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return processoutputengine;
    }

    public ProcessOutputEngineResponseAll? ReadAll(DBProcessOutputEngine dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var processoutputengine = new ProcessOutputEngineResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Database = dbRec.FDatabase ?? string.Empty,
            Tabela = dbRec.FTabela ?? string.Empty,
            Campo = dbRec.FCampo ?? string.Empty,
            Valor = dbRec.FValor ?? string.Empty,
            Output = dbRec.FOutput ?? string.Empty,
            Administrador = dbRec.FAdministrador,
            OutputSource = dbRec.FOutputSource,
            DisabledItem = dbRec.FDisabledItem,
            IDModulo = dbRec.FIDModulo,
            IsOnlyProcesso = dbRec.FIsOnlyProcesso,
            MyID = dbRec.FMyID,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return processoutputengine;
    }
}