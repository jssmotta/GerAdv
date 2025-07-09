#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IDiario2Reader
{
    Diario2Response? Read(int id, MsiSqlConnection oCnn);
    Diario2Response? Read(Entity.DBDiario2 dbRec, MsiSqlConnection oCnn);
    Diario2Response? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    Diario2Response? Read(Entity.DBDiario2 dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    Diario2Response? Read(DBDiario2 dbRec);
    Diario2ResponseAll? ReadAll(DBDiario2 dbRec, DataRow dr);
    Diario2ResponseAll? ReadAll(DBDiario2 dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<Diario2ResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Diario2 : IDiario2Reader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{diaCodigo, diaNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<Diario2ResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<Diario2ResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<Diario2ResponseAll>> ReadLocalAsync()
        {
            var result = new List<Diario2ResponseAll>(max);
            await using var connection = Configuracoes.GetConnectionByUri(uri);
            await using var cmd = new SqlCommand(cmdText: ConfiguracoesDBT.CmdSql(sql), connection: connection?.InnerConnection)
            {
                CommandTimeout = 0
            };
            cmd.Parameters.AddRange([..parameters]);
            await using var reader = await cmd.ExecuteReaderAsync(CommandBehavior.SingleResult).ConfigureAwait(false);
            while (await reader.ReadAsync().ConfigureAwait(false))
            {
                if (await reader.IsDBNullAsync(1).ConfigureAwait(false))
                    continue;
                result.Add(ReadAll(new Entity.DBDiario2(reader), reader)!);
            }

            return result;
        }
    }

    static string BuildSqlQuery(string campos, string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Diario2".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}diaNome");
        }

        return query.ToString();
    }

    public Diario2Response? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBDiario2(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public Diario2Response? Read(Entity.DBDiario2 dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public Diario2Response? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBDiario2(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public Diario2Response? Read(Entity.DBDiario2 dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var diario2 = new Diario2Response
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Nome = dbRec.FNome ?? string.Empty,
            Ocorrencia = dbRec.FOcorrencia ?? string.Empty,
            Cliente = dbRec.FCliente,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            diario2.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHora, out _))
            diario2.Hora = dbRec.FHora;
        return diario2;
    }

    public Diario2Response? Read(DBDiario2 dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var diario2 = new Diario2Response
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Nome = dbRec.FNome ?? string.Empty,
            Ocorrencia = dbRec.FOcorrencia ?? string.Empty,
            Cliente = dbRec.FCliente,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            diario2.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHora, out _))
            diario2.Hora = dbRec.FHora;
        return diario2;
    }

    public Diario2ResponseAll? ReadAll(DBDiario2 dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var diario2 = new Diario2ResponseAll
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Nome = dbRec.FNome ?? string.Empty,
            Ocorrencia = dbRec.FOcorrencia ?? string.Empty,
            Cliente = dbRec.FCliente,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            diario2.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHora, out _))
            diario2.Hora = dbRec.FHora;
        diario2.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        diario2.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        return diario2;
    }

    public Diario2ResponseAll? ReadAll(DBDiario2 dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var diario2 = new Diario2ResponseAll
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Nome = dbRec.FNome ?? string.Empty,
            Ocorrencia = dbRec.FOcorrencia ?? string.Empty,
            Cliente = dbRec.FCliente,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            diario2.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHora, out _))
            diario2.Hora = dbRec.FHora;
        diario2.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        diario2.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        return diario2;
    }
}