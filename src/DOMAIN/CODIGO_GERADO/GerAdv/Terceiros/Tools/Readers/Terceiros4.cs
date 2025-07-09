#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITerceirosReader
{
    TerceirosResponse? Read(int id, MsiSqlConnection oCnn);
    TerceirosResponse? Read(Entity.DBTerceiros dbRec, MsiSqlConnection oCnn);
    TerceirosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TerceirosResponse? Read(Entity.DBTerceiros dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TerceirosResponse? Read(DBTerceiros dbRec);
    TerceirosResponseAll? ReadAll(DBTerceiros dbRec, DataRow dr);
    TerceirosResponseAll? ReadAll(DBTerceiros dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<TerceirosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Terceiros : ITerceirosReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{terCodigo, terNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<TerceirosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<TerceirosResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<TerceirosResponseAll>> ReadLocalAsync()
        {
            var result = new List<TerceirosResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBTerceiros(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Terceiros".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}terNome");
        }

        return query.ToString();
    }

    public TerceirosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTerceiros(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TerceirosResponse? Read(Entity.DBTerceiros dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public TerceirosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTerceiros(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TerceirosResponse? Read(Entity.DBTerceiros dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var terceiros = new TerceirosResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Situacao = dbRec.FSituacao,
            Cidade = dbRec.FCidade,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            VaraForoComarca = dbRec.FVaraForoComarca ?? string.Empty,
            Sexo = dbRec.FSexo,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return terceiros;
    }

    public TerceirosResponse? Read(DBTerceiros dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var terceiros = new TerceirosResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Situacao = dbRec.FSituacao,
            Cidade = dbRec.FCidade,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            VaraForoComarca = dbRec.FVaraForoComarca ?? string.Empty,
            Sexo = dbRec.FSexo,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return terceiros;
    }

    public TerceirosResponseAll? ReadAll(DBTerceiros dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var terceiros = new TerceirosResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Situacao = dbRec.FSituacao,
            Cidade = dbRec.FCidade,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            VaraForoComarca = dbRec.FVaraForoComarca ?? string.Empty,
            Sexo = dbRec.FSexo,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        terceiros.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        terceiros.DescricaoPosicaoOutrasPartes = dr["posDescricao"]?.ToString() ?? string.Empty;
        terceiros.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return terceiros;
    }

    public TerceirosResponseAll? ReadAll(DBTerceiros dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var terceiros = new TerceirosResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Situacao = dbRec.FSituacao,
            Cidade = dbRec.FCidade,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            VaraForoComarca = dbRec.FVaraForoComarca ?? string.Empty,
            Sexo = dbRec.FSexo,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        terceiros.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        terceiros.DescricaoPosicaoOutrasPartes = dr["posDescricao"]?.ToString() ?? string.Empty;
        terceiros.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return terceiros;
    }
}