#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IContatoCRMReader
{
    ContatoCRMResponse? Read(int id, MsiSqlConnection oCnn);
    ContatoCRMResponse? Read(Entity.DBContatoCRM dbRec, MsiSqlConnection oCnn);
    ContatoCRMResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ContatoCRMResponse? Read(Entity.DBContatoCRM dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ContatoCRMResponse? Read(DBContatoCRM dbRec);
    ContatoCRMResponseAll? ReadAll(DBContatoCRM dbRec, DataRow dr);
    ContatoCRMResponseAll? ReadAll(DBContatoCRM dbRec, SqlDataReader dr);
    IEnumerable<ContatoCRMResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ContatoCRM : IContatoCRMReader
{
    public IEnumerable<ContatoCRMResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<ContatoCRMResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<ContatoCRMResponseAll>> ReadLocalAsync()
        {
            var result = new List<ContatoCRMResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBContatoCRM(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"ContatoCRM".dbo(oCnn)} (NOLOCK) ");
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

    public ContatoCRMResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBContatoCRM(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ContatoCRMResponse? Read(Entity.DBContatoCRM dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public ContatoCRMResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBContatoCRM(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ContatoCRMResponse? Read(Entity.DBContatoCRM dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contatocrm = new ContatoCRMResponse
        {
            Id = dbRec.ID,
            AgeClienteAvisado = dbRec.FAgeClienteAvisado,
            DocsViaRecebimento = dbRec.FDocsViaRecebimento,
            NaoPublicavel = dbRec.FNaoPublicavel,
            Notificar = dbRec.FNotificar,
            Ocultar = dbRec.FOcultar,
            Assunto = dbRec.FAssunto ?? string.Empty,
            IsDocsRecebidos = dbRec.FIsDocsRecebidos,
            QuemNotificou = dbRec.FQuemNotificou,
            Operador = dbRec.FOperador,
            Cliente = dbRec.FCliente,
            ObjetoNotificou = dbRec.FObjetoNotificou,
            PessoaContato = dbRec.FPessoaContato ?? string.Empty,
            Tempo = dbRec.FTempo,
            Processo = dbRec.FProcesso,
            Importante = dbRec.FImportante,
            Urgente = dbRec.FUrgente,
            GerarHoraTrabalhada = dbRec.FGerarHoraTrabalhada,
            ExibirNoTopo = dbRec.FExibirNoTopo,
            TipoContatoCRM = dbRec.FTipoContatoCRM,
            Contato = dbRec.FContato ?? string.Empty,
            Emocao = dbRec.FEmocao,
            Continuar = dbRec.FContinuar,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataNotificou, out _))
            contatocrm.DataNotificou = dbRec.FDataNotificou;
        if (DateTime.TryParse(dbRec.FHoraNotificou, out _))
            contatocrm.HoraNotificou = dbRec.FHoraNotificou;
        if (DateTime.TryParse(dbRec.FData, out _))
            contatocrm.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHoraInicial, out _))
            contatocrm.HoraInicial = dbRec.FHoraInicial;
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            contatocrm.HoraFinal = dbRec.FHoraFinal;
        return contatocrm;
    }

    public ContatoCRMResponse? Read(DBContatoCRM dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contatocrm = new ContatoCRMResponse
        {
            Id = dbRec.ID,
            AgeClienteAvisado = dbRec.FAgeClienteAvisado,
            DocsViaRecebimento = dbRec.FDocsViaRecebimento,
            NaoPublicavel = dbRec.FNaoPublicavel,
            Notificar = dbRec.FNotificar,
            Ocultar = dbRec.FOcultar,
            Assunto = dbRec.FAssunto ?? string.Empty,
            IsDocsRecebidos = dbRec.FIsDocsRecebidos,
            QuemNotificou = dbRec.FQuemNotificou,
            Operador = dbRec.FOperador,
            Cliente = dbRec.FCliente,
            ObjetoNotificou = dbRec.FObjetoNotificou,
            PessoaContato = dbRec.FPessoaContato ?? string.Empty,
            Tempo = dbRec.FTempo,
            Processo = dbRec.FProcesso,
            Importante = dbRec.FImportante,
            Urgente = dbRec.FUrgente,
            GerarHoraTrabalhada = dbRec.FGerarHoraTrabalhada,
            ExibirNoTopo = dbRec.FExibirNoTopo,
            TipoContatoCRM = dbRec.FTipoContatoCRM,
            Contato = dbRec.FContato ?? string.Empty,
            Emocao = dbRec.FEmocao,
            Continuar = dbRec.FContinuar,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataNotificou, out _))
            contatocrm.DataNotificou = dbRec.FDataNotificou;
        if (DateTime.TryParse(dbRec.FHoraNotificou, out _))
            contatocrm.HoraNotificou = dbRec.FHoraNotificou;
        if (DateTime.TryParse(dbRec.FData, out _))
            contatocrm.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHoraInicial, out _))
            contatocrm.HoraInicial = dbRec.FHoraInicial;
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            contatocrm.HoraFinal = dbRec.FHoraFinal;
        return contatocrm;
    }

    public ContatoCRMResponseAll? ReadAll(DBContatoCRM dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contatocrm = new ContatoCRMResponseAll
        {
            Id = dbRec.ID,
            AgeClienteAvisado = dbRec.FAgeClienteAvisado,
            DocsViaRecebimento = dbRec.FDocsViaRecebimento,
            NaoPublicavel = dbRec.FNaoPublicavel,
            Notificar = dbRec.FNotificar,
            Ocultar = dbRec.FOcultar,
            Assunto = dbRec.FAssunto ?? string.Empty,
            IsDocsRecebidos = dbRec.FIsDocsRecebidos,
            QuemNotificou = dbRec.FQuemNotificou,
            Operador = dbRec.FOperador,
            Cliente = dbRec.FCliente,
            ObjetoNotificou = dbRec.FObjetoNotificou,
            PessoaContato = dbRec.FPessoaContato ?? string.Empty,
            Tempo = dbRec.FTempo,
            Processo = dbRec.FProcesso,
            Importante = dbRec.FImportante,
            Urgente = dbRec.FUrgente,
            GerarHoraTrabalhada = dbRec.FGerarHoraTrabalhada,
            ExibirNoTopo = dbRec.FExibirNoTopo,
            TipoContatoCRM = dbRec.FTipoContatoCRM,
            Contato = dbRec.FContato ?? string.Empty,
            Emocao = dbRec.FEmocao,
            Continuar = dbRec.FContinuar,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataNotificou, out _))
            contatocrm.DataNotificou = dbRec.FDataNotificou;
        if (DateTime.TryParse(dbRec.FHoraNotificou, out _))
            contatocrm.HoraNotificou = dbRec.FHoraNotificou;
        if (DateTime.TryParse(dbRec.FData, out _))
            contatocrm.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHoraInicial, out _))
            contatocrm.HoraInicial = dbRec.FHoraInicial;
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            contatocrm.HoraFinal = dbRec.FHoraFinal;
        contatocrm.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        contatocrm.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        contatocrm.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        contatocrm.NomeTipoContatoCRM = dr["tccNome"]?.ToString() ?? string.Empty;
        return contatocrm;
    }

    public ContatoCRMResponseAll? ReadAll(DBContatoCRM dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var contatocrm = new ContatoCRMResponseAll
        {
            Id = dbRec.ID,
            AgeClienteAvisado = dbRec.FAgeClienteAvisado,
            DocsViaRecebimento = dbRec.FDocsViaRecebimento,
            NaoPublicavel = dbRec.FNaoPublicavel,
            Notificar = dbRec.FNotificar,
            Ocultar = dbRec.FOcultar,
            Assunto = dbRec.FAssunto ?? string.Empty,
            IsDocsRecebidos = dbRec.FIsDocsRecebidos,
            QuemNotificou = dbRec.FQuemNotificou,
            Operador = dbRec.FOperador,
            Cliente = dbRec.FCliente,
            ObjetoNotificou = dbRec.FObjetoNotificou,
            PessoaContato = dbRec.FPessoaContato ?? string.Empty,
            Tempo = dbRec.FTempo,
            Processo = dbRec.FProcesso,
            Importante = dbRec.FImportante,
            Urgente = dbRec.FUrgente,
            GerarHoraTrabalhada = dbRec.FGerarHoraTrabalhada,
            ExibirNoTopo = dbRec.FExibirNoTopo,
            TipoContatoCRM = dbRec.FTipoContatoCRM,
            Contato = dbRec.FContato ?? string.Empty,
            Emocao = dbRec.FEmocao,
            Continuar = dbRec.FContinuar,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataNotificou, out _))
            contatocrm.DataNotificou = dbRec.FDataNotificou;
        if (DateTime.TryParse(dbRec.FHoraNotificou, out _))
            contatocrm.HoraNotificou = dbRec.FHoraNotificou;
        if (DateTime.TryParse(dbRec.FData, out _))
            contatocrm.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHoraInicial, out _))
            contatocrm.HoraInicial = dbRec.FHoraInicial;
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            contatocrm.HoraFinal = dbRec.FHoraFinal;
        contatocrm.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        contatocrm.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        contatocrm.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        contatocrm.NomeTipoContatoCRM = dr["tccNome"]?.ToString() ?? string.Empty;
        return contatocrm;
    }
}