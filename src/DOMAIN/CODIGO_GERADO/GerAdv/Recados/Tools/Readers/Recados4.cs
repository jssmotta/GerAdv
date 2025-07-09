#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IRecadosReader
{
    RecadosResponse? Read(int id, MsiSqlConnection oCnn);
    RecadosResponse? Read(Entity.DBRecados dbRec, MsiSqlConnection oCnn);
    RecadosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    RecadosResponse? Read(Entity.DBRecados dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    RecadosResponse? Read(DBRecados dbRec);
    RecadosResponseAll? ReadAll(DBRecados dbRec, DataRow dr);
    RecadosResponseAll? ReadAll(DBRecados dbRec, SqlDataReader dr);
    IEnumerable<RecadosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Recados : IRecadosReader
{
    public IEnumerable<RecadosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<RecadosResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<RecadosResponseAll>> ReadLocalAsync()
        {
            var result = new List<RecadosResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBRecados(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Recados".dbo(oCnn)} (NOLOCK) ");
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

    public RecadosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBRecados(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public RecadosResponse? Read(Entity.DBRecados dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public RecadosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBRecados(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public RecadosResponse? Read(Entity.DBRecados dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var recados = new RecadosResponse
        {
            Id = dbRec.ID,
            ClienteNome = dbRec.FClienteNome ?? string.Empty,
            De = dbRec.FDe ?? string.Empty,
            Para = dbRec.FPara ?? string.Empty,
            Assunto = dbRec.FAssunto ?? string.Empty,
            Concluido = dbRec.FConcluido,
            Processo = dbRec.FProcesso,
            Cliente = dbRec.FCliente,
            Recado = dbRec.FRecado ?? string.Empty,
            Urgente = dbRec.FUrgente,
            Importante = dbRec.FImportante,
            Voltara = dbRec.FVoltara,
            Pessoal = dbRec.FPessoal,
            Retornar = dbRec.FRetornar,
            Emotion = dbRec.FEmotion,
            InternetID = dbRec.FInternetID,
            Uploaded = dbRec.FUploaded,
            Natureza = dbRec.FNatureza,
            BIU = dbRec.FBIU,
            AguardarRetorno = dbRec.FAguardarRetorno,
            AguardarRetornoPara = dbRec.FAguardarRetornoPara ?? string.Empty,
            AguardarRetornoOK = dbRec.FAguardarRetornoOK,
            ParaID = dbRec.FParaID,
            NaoPublicavel = dbRec.FNaoPublicavel,
            IsContatoCRM = dbRec.FIsContatoCRM,
            MasterID = dbRec.FMasterID,
            ListaPara = dbRec.FListaPara ?? string.Empty,
            Typed = dbRec.FTyped,
            AssuntoRecado = dbRec.FAssuntoRecado,
            Historico = dbRec.FHistorico,
            ContatoCRM = dbRec.FContatoCRM,
            Ligacoes = dbRec.FLigacoes,
            Agenda = dbRec.FAgenda,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FHora, out _))
            recados.Hora = dbRec.FHora;
        if (DateTime.TryParse(dbRec.FData, out _))
            recados.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FRetornoData, out _))
            recados.RetornoData = dbRec.FRetornoData;
        return recados;
    }

    public RecadosResponse? Read(DBRecados dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var recados = new RecadosResponse
        {
            Id = dbRec.ID,
            ClienteNome = dbRec.FClienteNome ?? string.Empty,
            De = dbRec.FDe ?? string.Empty,
            Para = dbRec.FPara ?? string.Empty,
            Assunto = dbRec.FAssunto ?? string.Empty,
            Concluido = dbRec.FConcluido,
            Processo = dbRec.FProcesso,
            Cliente = dbRec.FCliente,
            Recado = dbRec.FRecado ?? string.Empty,
            Urgente = dbRec.FUrgente,
            Importante = dbRec.FImportante,
            Voltara = dbRec.FVoltara,
            Pessoal = dbRec.FPessoal,
            Retornar = dbRec.FRetornar,
            Emotion = dbRec.FEmotion,
            InternetID = dbRec.FInternetID,
            Uploaded = dbRec.FUploaded,
            Natureza = dbRec.FNatureza,
            BIU = dbRec.FBIU,
            AguardarRetorno = dbRec.FAguardarRetorno,
            AguardarRetornoPara = dbRec.FAguardarRetornoPara ?? string.Empty,
            AguardarRetornoOK = dbRec.FAguardarRetornoOK,
            ParaID = dbRec.FParaID,
            NaoPublicavel = dbRec.FNaoPublicavel,
            IsContatoCRM = dbRec.FIsContatoCRM,
            MasterID = dbRec.FMasterID,
            ListaPara = dbRec.FListaPara ?? string.Empty,
            Typed = dbRec.FTyped,
            AssuntoRecado = dbRec.FAssuntoRecado,
            Historico = dbRec.FHistorico,
            ContatoCRM = dbRec.FContatoCRM,
            Ligacoes = dbRec.FLigacoes,
            Agenda = dbRec.FAgenda,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FHora, out _))
            recados.Hora = dbRec.FHora;
        if (DateTime.TryParse(dbRec.FData, out _))
            recados.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FRetornoData, out _))
            recados.RetornoData = dbRec.FRetornoData;
        return recados;
    }

    public RecadosResponseAll? ReadAll(DBRecados dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var recados = new RecadosResponseAll
        {
            Id = dbRec.ID,
            ClienteNome = dbRec.FClienteNome ?? string.Empty,
            De = dbRec.FDe ?? string.Empty,
            Para = dbRec.FPara ?? string.Empty,
            Assunto = dbRec.FAssunto ?? string.Empty,
            Concluido = dbRec.FConcluido,
            Processo = dbRec.FProcesso,
            Cliente = dbRec.FCliente,
            Recado = dbRec.FRecado ?? string.Empty,
            Urgente = dbRec.FUrgente,
            Importante = dbRec.FImportante,
            Voltara = dbRec.FVoltara,
            Pessoal = dbRec.FPessoal,
            Retornar = dbRec.FRetornar,
            Emotion = dbRec.FEmotion,
            InternetID = dbRec.FInternetID,
            Uploaded = dbRec.FUploaded,
            Natureza = dbRec.FNatureza,
            BIU = dbRec.FBIU,
            AguardarRetorno = dbRec.FAguardarRetorno,
            AguardarRetornoPara = dbRec.FAguardarRetornoPara ?? string.Empty,
            AguardarRetornoOK = dbRec.FAguardarRetornoOK,
            ParaID = dbRec.FParaID,
            NaoPublicavel = dbRec.FNaoPublicavel,
            IsContatoCRM = dbRec.FIsContatoCRM,
            MasterID = dbRec.FMasterID,
            ListaPara = dbRec.FListaPara ?? string.Empty,
            Typed = dbRec.FTyped,
            AssuntoRecado = dbRec.FAssuntoRecado,
            Historico = dbRec.FHistorico,
            ContatoCRM = dbRec.FContatoCRM,
            Ligacoes = dbRec.FLigacoes,
            Agenda = dbRec.FAgenda,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FHora, out _))
            recados.Hora = dbRec.FHora;
        if (DateTime.TryParse(dbRec.FData, out _))
            recados.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FRetornoData, out _))
            recados.RetornoData = dbRec.FRetornoData;
        recados.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        recados.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        recados.NomeLigacoes = dr["ligNome"]?.ToString() ?? string.Empty;
        return recados;
    }

    public RecadosResponseAll? ReadAll(DBRecados dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var recados = new RecadosResponseAll
        {
            Id = dbRec.ID,
            ClienteNome = dbRec.FClienteNome ?? string.Empty,
            De = dbRec.FDe ?? string.Empty,
            Para = dbRec.FPara ?? string.Empty,
            Assunto = dbRec.FAssunto ?? string.Empty,
            Concluido = dbRec.FConcluido,
            Processo = dbRec.FProcesso,
            Cliente = dbRec.FCliente,
            Recado = dbRec.FRecado ?? string.Empty,
            Urgente = dbRec.FUrgente,
            Importante = dbRec.FImportante,
            Voltara = dbRec.FVoltara,
            Pessoal = dbRec.FPessoal,
            Retornar = dbRec.FRetornar,
            Emotion = dbRec.FEmotion,
            InternetID = dbRec.FInternetID,
            Uploaded = dbRec.FUploaded,
            Natureza = dbRec.FNatureza,
            BIU = dbRec.FBIU,
            AguardarRetorno = dbRec.FAguardarRetorno,
            AguardarRetornoPara = dbRec.FAguardarRetornoPara ?? string.Empty,
            AguardarRetornoOK = dbRec.FAguardarRetornoOK,
            ParaID = dbRec.FParaID,
            NaoPublicavel = dbRec.FNaoPublicavel,
            IsContatoCRM = dbRec.FIsContatoCRM,
            MasterID = dbRec.FMasterID,
            ListaPara = dbRec.FListaPara ?? string.Empty,
            Typed = dbRec.FTyped,
            AssuntoRecado = dbRec.FAssuntoRecado,
            Historico = dbRec.FHistorico,
            ContatoCRM = dbRec.FContatoCRM,
            Ligacoes = dbRec.FLigacoes,
            Agenda = dbRec.FAgenda,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FHora, out _))
            recados.Hora = dbRec.FHora;
        if (DateTime.TryParse(dbRec.FData, out _))
            recados.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FRetornoData, out _))
            recados.RetornoData = dbRec.FRetornoData;
        recados.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        recados.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        recados.NomeLigacoes = dr["ligNome"]?.ToString() ?? string.Empty;
        return recados;
    }
}