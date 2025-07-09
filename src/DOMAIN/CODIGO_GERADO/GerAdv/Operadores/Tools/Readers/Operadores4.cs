#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadoresReader
{
    OperadoresResponse? Read(int id, MsiSqlConnection oCnn);
    OperadoresResponse? Read(Entity.DBOperadores dbRec, MsiSqlConnection oCnn);
    OperadoresResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OperadoresResponse? Read(Entity.DBOperadores dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OperadoresResponse? Read(DBOperadores dbRec);
    OperadoresResponseAll? ReadAll(DBOperadores dbRec, DataRow dr);
    OperadoresResponseAll? ReadAll(DBOperadores dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<OperadoresResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Operadores : IOperadoresReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{operCodigo, operNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<OperadoresResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<OperadoresResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<OperadoresResponseAll>> ReadLocalAsync()
        {
            var result = new List<OperadoresResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBOperadores(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Operadores".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}operNome");
        }

        return query.ToString();
    }

    public OperadoresResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadores(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadoresResponse? Read(Entity.DBOperadores dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public OperadoresResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadores(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadoresResponse? Read(Entity.DBOperadores dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadores = new OperadoresResponse
        {
            Id = dbRec.ID,
            Enviado = dbRec.FEnviado,
            Casa = dbRec.FCasa,
            CasaID = dbRec.FCasaID,
            CasaCodigo = dbRec.FCasaCodigo,
            IsNovo = dbRec.FIsNovo,
            Cliente = dbRec.FCliente,
            Grupo = dbRec.FGrupo,
            Nome = dbRec.FNome ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Ativado = dbRec.FAtivado,
        };
        if (DateTime.TryParse(dbRec.FSuporteMaxAge, out _))
            operadores.SuporteMaxAge = dbRec.FSuporteMaxAge;
        return operadores;
    }

    public OperadoresResponse? Read(DBOperadores dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadores = new OperadoresResponse
        {
            Id = dbRec.ID,
            Enviado = dbRec.FEnviado,
            Casa = dbRec.FCasa,
            CasaID = dbRec.FCasaID,
            CasaCodigo = dbRec.FCasaCodigo,
            IsNovo = dbRec.FIsNovo,
            Cliente = dbRec.FCliente,
            Grupo = dbRec.FGrupo,
            Nome = dbRec.FNome ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Ativado = dbRec.FAtivado,
        };
        if (DateTime.TryParse(dbRec.FSuporteMaxAge, out _))
            operadores.SuporteMaxAge = dbRec.FSuporteMaxAge;
        return operadores;
    }

    public OperadoresResponseAll? ReadAll(DBOperadores dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadores = new OperadoresResponseAll
        {
            Id = dbRec.ID,
            Enviado = dbRec.FEnviado,
            Casa = dbRec.FCasa,
            CasaID = dbRec.FCasaID,
            CasaCodigo = dbRec.FCasaCodigo,
            IsNovo = dbRec.FIsNovo,
            Cliente = dbRec.FCliente,
            Grupo = dbRec.FGrupo,
            Nome = dbRec.FNome ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Ativado = dbRec.FAtivado,
        };
        if (DateTime.TryParse(dbRec.FSuporteMaxAge, out _))
            operadores.SuporteMaxAge = dbRec.FSuporteMaxAge;
        operadores.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        return operadores;
    }

    public OperadoresResponseAll? ReadAll(DBOperadores dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadores = new OperadoresResponseAll
        {
            Id = dbRec.ID,
            Enviado = dbRec.FEnviado,
            Casa = dbRec.FCasa,
            CasaID = dbRec.FCasaID,
            CasaCodigo = dbRec.FCasaCodigo,
            IsNovo = dbRec.FIsNovo,
            Cliente = dbRec.FCliente,
            Grupo = dbRec.FGrupo,
            Nome = dbRec.FNome ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Ativado = dbRec.FAtivado,
        };
        if (DateTime.TryParse(dbRec.FSuporteMaxAge, out _))
            operadores.SuporteMaxAge = dbRec.FSuporteMaxAge;
        operadores.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        return operadores;
    }
}