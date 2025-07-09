#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IAlarmSMSReader
{
    AlarmSMSResponse? Read(int id, MsiSqlConnection oCnn);
    AlarmSMSResponse? Read(Entity.DBAlarmSMS dbRec, MsiSqlConnection oCnn);
    AlarmSMSResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AlarmSMSResponse? Read(Entity.DBAlarmSMS dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    AlarmSMSResponse? Read(DBAlarmSMS dbRec);
    AlarmSMSResponseAll? ReadAll(DBAlarmSMS dbRec, DataRow dr);
    AlarmSMSResponseAll? ReadAll(DBAlarmSMS dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<AlarmSMSResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class AlarmSMS : IAlarmSMSReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{alrCodigo, alrDescricao}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<AlarmSMSResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<AlarmSMSResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<AlarmSMSResponseAll>> ReadLocalAsync()
        {
            var result = new List<AlarmSMSResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBAlarmSMS(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"AlarmSMS".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}alrDescricao");
        }

        return query.ToString();
    }

    public AlarmSMSResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAlarmSMS(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AlarmSMSResponse? Read(Entity.DBAlarmSMS dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public AlarmSMSResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBAlarmSMS(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public AlarmSMSResponse? Read(Entity.DBAlarmSMS dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var alarmsms = new AlarmSMSResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Hora = dbRec.FHora,
            Minuto = dbRec.FMinuto,
            D1 = dbRec.FD1,
            D2 = dbRec.FD2,
            D3 = dbRec.FD3,
            D4 = dbRec.FD4,
            D5 = dbRec.FD5,
            D6 = dbRec.FD6,
            D7 = dbRec.FD7,
            EMail = dbRec.FEMail ?? string.Empty,
            Desativar = dbRec.FDesativar,
            ExcetoDiasFelizes = dbRec.FExcetoDiasFelizes,
            Desktop = dbRec.FDesktop,
            Operador = dbRec.FOperador,
            GuidExo = dbRec.FGuidExo ?? string.Empty,
            Agenda = dbRec.FAgenda,
            Recado = dbRec.FRecado,
            Emocao = dbRec.FEmocao,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FToday, out _))
            alarmsms.Today = dbRec.FToday;
        if (DateTime.TryParse(dbRec.FAlertarDataHora, out _))
            alarmsms.AlertarDataHora = dbRec.FAlertarDataHora;
        return alarmsms;
    }

    public AlarmSMSResponse? Read(DBAlarmSMS dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var alarmsms = new AlarmSMSResponse
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Hora = dbRec.FHora,
            Minuto = dbRec.FMinuto,
            D1 = dbRec.FD1,
            D2 = dbRec.FD2,
            D3 = dbRec.FD3,
            D4 = dbRec.FD4,
            D5 = dbRec.FD5,
            D6 = dbRec.FD6,
            D7 = dbRec.FD7,
            EMail = dbRec.FEMail ?? string.Empty,
            Desativar = dbRec.FDesativar,
            ExcetoDiasFelizes = dbRec.FExcetoDiasFelizes,
            Desktop = dbRec.FDesktop,
            Operador = dbRec.FOperador,
            GuidExo = dbRec.FGuidExo ?? string.Empty,
            Agenda = dbRec.FAgenda,
            Recado = dbRec.FRecado,
            Emocao = dbRec.FEmocao,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FToday, out _))
            alarmsms.Today = dbRec.FToday;
        if (DateTime.TryParse(dbRec.FAlertarDataHora, out _))
            alarmsms.AlertarDataHora = dbRec.FAlertarDataHora;
        return alarmsms;
    }

    public AlarmSMSResponseAll? ReadAll(DBAlarmSMS dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var alarmsms = new AlarmSMSResponseAll
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Hora = dbRec.FHora,
            Minuto = dbRec.FMinuto,
            D1 = dbRec.FD1,
            D2 = dbRec.FD2,
            D3 = dbRec.FD3,
            D4 = dbRec.FD4,
            D5 = dbRec.FD5,
            D6 = dbRec.FD6,
            D7 = dbRec.FD7,
            EMail = dbRec.FEMail ?? string.Empty,
            Desativar = dbRec.FDesativar,
            ExcetoDiasFelizes = dbRec.FExcetoDiasFelizes,
            Desktop = dbRec.FDesktop,
            Operador = dbRec.FOperador,
            GuidExo = dbRec.FGuidExo ?? string.Empty,
            Agenda = dbRec.FAgenda,
            Recado = dbRec.FRecado,
            Emocao = dbRec.FEmocao,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FToday, out _))
            alarmsms.Today = dbRec.FToday;
        if (DateTime.TryParse(dbRec.FAlertarDataHora, out _))
            alarmsms.AlertarDataHora = dbRec.FAlertarDataHora;
        alarmsms.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return alarmsms;
    }

    public AlarmSMSResponseAll? ReadAll(DBAlarmSMS dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var alarmsms = new AlarmSMSResponseAll
        {
            Id = dbRec.ID,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Hora = dbRec.FHora,
            Minuto = dbRec.FMinuto,
            D1 = dbRec.FD1,
            D2 = dbRec.FD2,
            D3 = dbRec.FD3,
            D4 = dbRec.FD4,
            D5 = dbRec.FD5,
            D6 = dbRec.FD6,
            D7 = dbRec.FD7,
            EMail = dbRec.FEMail ?? string.Empty,
            Desativar = dbRec.FDesativar,
            ExcetoDiasFelizes = dbRec.FExcetoDiasFelizes,
            Desktop = dbRec.FDesktop,
            Operador = dbRec.FOperador,
            GuidExo = dbRec.FGuidExo ?? string.Empty,
            Agenda = dbRec.FAgenda,
            Recado = dbRec.FRecado,
            Emocao = dbRec.FEmocao,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FToday, out _))
            alarmsms.Today = dbRec.FToday;
        if (DateTime.TryParse(dbRec.FAlertarDataHora, out _))
            alarmsms.AlertarDataHora = dbRec.FAlertarDataHora;
        alarmsms.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return alarmsms;
    }
}