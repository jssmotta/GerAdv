#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ILigacoesReader
{
    LigacoesResponse? Read(int id, MsiSqlConnection oCnn);
    LigacoesResponse? Read(Entity.DBLigacoes dbRec, MsiSqlConnection oCnn);
    LigacoesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    LigacoesResponse? Read(Entity.DBLigacoes dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    LigacoesResponse? Read(DBLigacoes dbRec);
    LigacoesResponseAll? ReadAll(DBLigacoes dbRec, DataRow dr);
    LigacoesResponseAll? ReadAll(DBLigacoes dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<LigacoesResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Ligacoes : ILigacoesReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{ligCodigo, ligNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<LigacoesResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<LigacoesResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<LigacoesResponseAll>> ReadLocalAsync()
        {
            var result = new List<LigacoesResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBLigacoes(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Ligacoes".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}ligNome");
        }

        return query.ToString();
    }

    public LigacoesResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBLigacoes(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public LigacoesResponse? Read(Entity.DBLigacoes dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public LigacoesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBLigacoes(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public LigacoesResponse? Read(Entity.DBLigacoes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var ligacoes = new LigacoesResponse
        {
            Id = dbRec.ID,
            Assunto = dbRec.FAssunto ?? string.Empty,
            AgeClienteAvisado = dbRec.FAgeClienteAvisado,
            Celular = dbRec.FCelular,
            Cliente = dbRec.FCliente,
            Contato = dbRec.FContato ?? string.Empty,
            QuemID = dbRec.FQuemID,
            Telefonista = dbRec.FTelefonista,
            Nome = dbRec.FNome ?? string.Empty,
            QuemCodigo = dbRec.FQuemCodigo,
            Solicitante = dbRec.FSolicitante,
            Para = dbRec.FPara ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Ramal = dbRec.FRamal,
            Particular = dbRec.FParticular,
            Realizada = dbRec.FRealizada,
            Status = dbRec.FStatus ?? string.Empty,
            Urgente = dbRec.FUrgente,
            LigarPara = dbRec.FLigarPara ?? string.Empty,
            Processo = dbRec.FProcesso,
            StartScreen = dbRec.FStartScreen,
            Emotion = dbRec.FEmotion,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataRealizada, out _))
            ligacoes.DataRealizada = dbRec.FDataRealizada;
        if (DateTime.TryParse(dbRec.FUltimoAviso, out _))
            ligacoes.UltimoAviso = dbRec.FUltimoAviso;
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            ligacoes.HoraFinal = dbRec.FHoraFinal;
        if (DateTime.TryParse(dbRec.FData, out _))
            ligacoes.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHora, out _))
            ligacoes.Hora = dbRec.FHora;
        return ligacoes;
    }

    public LigacoesResponse? Read(DBLigacoes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var ligacoes = new LigacoesResponse
        {
            Id = dbRec.ID,
            Assunto = dbRec.FAssunto ?? string.Empty,
            AgeClienteAvisado = dbRec.FAgeClienteAvisado,
            Celular = dbRec.FCelular,
            Cliente = dbRec.FCliente,
            Contato = dbRec.FContato ?? string.Empty,
            QuemID = dbRec.FQuemID,
            Telefonista = dbRec.FTelefonista,
            Nome = dbRec.FNome ?? string.Empty,
            QuemCodigo = dbRec.FQuemCodigo,
            Solicitante = dbRec.FSolicitante,
            Para = dbRec.FPara ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Ramal = dbRec.FRamal,
            Particular = dbRec.FParticular,
            Realizada = dbRec.FRealizada,
            Status = dbRec.FStatus ?? string.Empty,
            Urgente = dbRec.FUrgente,
            LigarPara = dbRec.FLigarPara ?? string.Empty,
            Processo = dbRec.FProcesso,
            StartScreen = dbRec.FStartScreen,
            Emotion = dbRec.FEmotion,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataRealizada, out _))
            ligacoes.DataRealizada = dbRec.FDataRealizada;
        if (DateTime.TryParse(dbRec.FUltimoAviso, out _))
            ligacoes.UltimoAviso = dbRec.FUltimoAviso;
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            ligacoes.HoraFinal = dbRec.FHoraFinal;
        if (DateTime.TryParse(dbRec.FData, out _))
            ligacoes.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHora, out _))
            ligacoes.Hora = dbRec.FHora;
        return ligacoes;
    }

    public LigacoesResponseAll? ReadAll(DBLigacoes dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var ligacoes = new LigacoesResponseAll
        {
            Id = dbRec.ID,
            Assunto = dbRec.FAssunto ?? string.Empty,
            AgeClienteAvisado = dbRec.FAgeClienteAvisado,
            Celular = dbRec.FCelular,
            Cliente = dbRec.FCliente,
            Contato = dbRec.FContato ?? string.Empty,
            QuemID = dbRec.FQuemID,
            Telefonista = dbRec.FTelefonista,
            Nome = dbRec.FNome ?? string.Empty,
            QuemCodigo = dbRec.FQuemCodigo,
            Solicitante = dbRec.FSolicitante,
            Para = dbRec.FPara ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Ramal = dbRec.FRamal,
            Particular = dbRec.FParticular,
            Realizada = dbRec.FRealizada,
            Status = dbRec.FStatus ?? string.Empty,
            Urgente = dbRec.FUrgente,
            LigarPara = dbRec.FLigarPara ?? string.Empty,
            Processo = dbRec.FProcesso,
            StartScreen = dbRec.FStartScreen,
            Emotion = dbRec.FEmotion,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataRealizada, out _))
            ligacoes.DataRealizada = dbRec.FDataRealizada;
        if (DateTime.TryParse(dbRec.FUltimoAviso, out _))
            ligacoes.UltimoAviso = dbRec.FUltimoAviso;
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            ligacoes.HoraFinal = dbRec.FHoraFinal;
        if (DateTime.TryParse(dbRec.FData, out _))
            ligacoes.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHora, out _))
            ligacoes.Hora = dbRec.FHora;
        ligacoes.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        ligacoes.NomeRamal = dr["ramNome"]?.ToString() ?? string.Empty;
        ligacoes.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return ligacoes;
    }

    public LigacoesResponseAll? ReadAll(DBLigacoes dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var ligacoes = new LigacoesResponseAll
        {
            Id = dbRec.ID,
            Assunto = dbRec.FAssunto ?? string.Empty,
            AgeClienteAvisado = dbRec.FAgeClienteAvisado,
            Celular = dbRec.FCelular,
            Cliente = dbRec.FCliente,
            Contato = dbRec.FContato ?? string.Empty,
            QuemID = dbRec.FQuemID,
            Telefonista = dbRec.FTelefonista,
            Nome = dbRec.FNome ?? string.Empty,
            QuemCodigo = dbRec.FQuemCodigo,
            Solicitante = dbRec.FSolicitante,
            Para = dbRec.FPara ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Ramal = dbRec.FRamal,
            Particular = dbRec.FParticular,
            Realizada = dbRec.FRealizada,
            Status = dbRec.FStatus ?? string.Empty,
            Urgente = dbRec.FUrgente,
            LigarPara = dbRec.FLigarPara ?? string.Empty,
            Processo = dbRec.FProcesso,
            StartScreen = dbRec.FStartScreen,
            Emotion = dbRec.FEmotion,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDataRealizada, out _))
            ligacoes.DataRealizada = dbRec.FDataRealizada;
        if (DateTime.TryParse(dbRec.FUltimoAviso, out _))
            ligacoes.UltimoAviso = dbRec.FUltimoAviso;
        if (DateTime.TryParse(dbRec.FHoraFinal, out _))
            ligacoes.HoraFinal = dbRec.FHoraFinal;
        if (DateTime.TryParse(dbRec.FData, out _))
            ligacoes.Data = dbRec.FData;
        if (DateTime.TryParse(dbRec.FHora, out _))
            ligacoes.Hora = dbRec.FHora;
        ligacoes.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        ligacoes.NomeRamal = dr["ramNome"]?.ToString() ?? string.Empty;
        ligacoes.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        return ligacoes;
    }
}