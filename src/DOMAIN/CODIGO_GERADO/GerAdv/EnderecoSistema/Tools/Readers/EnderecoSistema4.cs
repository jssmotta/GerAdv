#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEnderecoSistemaReader
{
    EnderecoSistemaResponse? Read(int id, MsiSqlConnection oCnn);
    EnderecoSistemaResponse? Read(Entity.DBEnderecoSistema dbRec, MsiSqlConnection oCnn);
    EnderecoSistemaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    EnderecoSistemaResponse? Read(Entity.DBEnderecoSistema dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    EnderecoSistemaResponse? Read(DBEnderecoSistema dbRec);
    EnderecoSistemaResponseAll? ReadAll(DBEnderecoSistema dbRec, DataRow dr);
    EnderecoSistemaResponseAll? ReadAll(DBEnderecoSistema dbRec, SqlDataReader dr);
    IEnumerable<EnderecoSistemaResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class EnderecoSistema : IEnderecoSistemaReader
{
    public IEnumerable<EnderecoSistemaResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<EnderecoSistemaResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<EnderecoSistemaResponseAll>> ReadLocalAsync()
        {
            var result = new List<EnderecoSistemaResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBEnderecoSistema(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"EnderecoSistema".dbo(oCnn)} (NOLOCK) ");
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

    public EnderecoSistemaResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEnderecoSistema(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EnderecoSistemaResponse? Read(Entity.DBEnderecoSistema dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public EnderecoSistemaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEnderecoSistema(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EnderecoSistemaResponse? Read(Entity.DBEnderecoSistema dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var enderecosistema = new EnderecoSistemaResponse
        {
            Id = dbRec.ID,
            Cadastro = dbRec.FCadastro,
            CadastroExCod = dbRec.FCadastroExCod,
            TipoEnderecoSistema = dbRec.FTipoEnderecoSistema,
            Processo = dbRec.FProcesso,
            Motivo = dbRec.FMotivo ?? string.Empty,
            ContatoNoLocal = dbRec.FContatoNoLocal ?? string.Empty,
            Cidade = dbRec.FCidade,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return enderecosistema;
    }

    public EnderecoSistemaResponse? Read(DBEnderecoSistema dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var enderecosistema = new EnderecoSistemaResponse
        {
            Id = dbRec.ID,
            Cadastro = dbRec.FCadastro,
            CadastroExCod = dbRec.FCadastroExCod,
            TipoEnderecoSistema = dbRec.FTipoEnderecoSistema,
            Processo = dbRec.FProcesso,
            Motivo = dbRec.FMotivo ?? string.Empty,
            ContatoNoLocal = dbRec.FContatoNoLocal ?? string.Empty,
            Cidade = dbRec.FCidade,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return enderecosistema;
    }

    public EnderecoSistemaResponseAll? ReadAll(DBEnderecoSistema dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var enderecosistema = new EnderecoSistemaResponseAll
        {
            Id = dbRec.ID,
            Cadastro = dbRec.FCadastro,
            CadastroExCod = dbRec.FCadastroExCod,
            TipoEnderecoSistema = dbRec.FTipoEnderecoSistema,
            Processo = dbRec.FProcesso,
            Motivo = dbRec.FMotivo ?? string.Empty,
            ContatoNoLocal = dbRec.FContatoNoLocal ?? string.Empty,
            Cidade = dbRec.FCidade,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        enderecosistema.NomeTipoEnderecoSistema = dr["tesNome"]?.ToString() ?? string.Empty;
        enderecosistema.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        enderecosistema.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return enderecosistema;
    }

    public EnderecoSistemaResponseAll? ReadAll(DBEnderecoSistema dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var enderecosistema = new EnderecoSistemaResponseAll
        {
            Id = dbRec.ID,
            Cadastro = dbRec.FCadastro,
            CadastroExCod = dbRec.FCadastroExCod,
            TipoEnderecoSistema = dbRec.FTipoEnderecoSistema,
            Processo = dbRec.FProcesso,
            Motivo = dbRec.FMotivo ?? string.Empty,
            ContatoNoLocal = dbRec.FContatoNoLocal ?? string.Empty,
            Cidade = dbRec.FCidade,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        enderecosistema.NomeTipoEnderecoSistema = dr["tesNome"]?.ToString() ?? string.Empty;
        enderecosistema.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        enderecosistema.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return enderecosistema;
    }
}