#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITribEnderecosReader
{
    TribEnderecosResponse? Read(int id, MsiSqlConnection oCnn);
    TribEnderecosResponse? Read(Entity.DBTribEnderecos dbRec, MsiSqlConnection oCnn);
    TribEnderecosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TribEnderecosResponse? Read(Entity.DBTribEnderecos dbRec);
    TribEnderecosResponse? Read(DBTribEnderecos dbRec);
    TribEnderecosResponseAll? ReadAll(DBTribEnderecos dbRec, DataRow dr);
    TribEnderecosResponseAll? ReadAll(DBTribEnderecos dbRec, SqlDataReader dr);
    IEnumerable<TribEnderecosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class TribEnderecos : ITribEnderecosReader
{
    public IEnumerable<TribEnderecosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<TribEnderecosResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<TribEnderecosResponseAll>> ReadLocalAsync()
        {
            var result = new List<TribEnderecosResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBTribEnderecos(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"TribEnderecos".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}");
        }

        return query.ToString();
    }

    public TribEnderecosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTribEnderecos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TribEnderecosResponse? Read(Entity.DBTribEnderecos dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public TribEnderecosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTribEnderecos(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TribEnderecosResponse? Read(Entity.DBTribEnderecos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tribenderecos = new TribEnderecosResponse
        {
            Id = dbRec.ID,
            Tribunal = dbRec.FTribunal,
            Cidade = dbRec.FCidade,
            Endereco = dbRec.FEndereco ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
        };
        return tribenderecos;
    }

    public TribEnderecosResponse? Read(DBTribEnderecos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tribenderecos = new TribEnderecosResponse
        {
            Id = dbRec.ID,
            Tribunal = dbRec.FTribunal,
            Cidade = dbRec.FCidade,
            Endereco = dbRec.FEndereco ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
        };
        return tribenderecos;
    }

    public TribEnderecosResponseAll? ReadAll(DBTribEnderecos dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tribenderecos = new TribEnderecosResponseAll
        {
            Id = dbRec.ID,
            Tribunal = dbRec.FTribunal,
            Cidade = dbRec.FCidade,
            Endereco = dbRec.FEndereco ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
        };
        tribenderecos.NomeTribunal = dr["triNome"]?.ToString() ?? string.Empty;
        tribenderecos.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return tribenderecos;
    }

    public TribEnderecosResponseAll? ReadAll(DBTribEnderecos dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var tribenderecos = new TribEnderecosResponseAll
        {
            Id = dbRec.ID,
            Tribunal = dbRec.FTribunal,
            Cidade = dbRec.FCidade,
            Endereco = dbRec.FEndereco ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
        };
        tribenderecos.NomeTribunal = dr["triNome"]?.ToString() ?? string.Empty;
        tribenderecos.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return tribenderecos;
    }
}