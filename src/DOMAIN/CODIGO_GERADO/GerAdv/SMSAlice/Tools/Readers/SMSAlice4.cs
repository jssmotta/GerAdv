#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ISMSAliceReader
{
    SMSAliceResponse? Read(int id, MsiSqlConnection oCnn);
    SMSAliceResponse? Read(Entity.DBSMSAlice dbRec, MsiSqlConnection oCnn);
    SMSAliceResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    SMSAliceResponse? Read(Entity.DBSMSAlice dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    SMSAliceResponse? Read(DBSMSAlice dbRec);
    SMSAliceResponseAll? ReadAll(DBSMSAlice dbRec, DataRow dr);
    SMSAliceResponseAll? ReadAll(DBSMSAlice dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<SMSAliceResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class SMSAlice : ISMSAliceReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{smaCodigo, smaNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<SMSAliceResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<SMSAliceResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<SMSAliceResponseAll>> ReadLocalAsync()
        {
            var result = new List<SMSAliceResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBSMSAlice(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"SMSAlice".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}smaNome");
        }

        return query.ToString();
    }

    public SMSAliceResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBSMSAlice(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public SMSAliceResponse? Read(Entity.DBSMSAlice dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public SMSAliceResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBSMSAlice(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public SMSAliceResponse? Read(Entity.DBSMSAlice dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var smsalice = new SMSAliceResponse
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Nome = dbRec.FNome ?? string.Empty,
            TipoEMail = dbRec.FTipoEMail,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return smsalice;
    }

    public SMSAliceResponse? Read(DBSMSAlice dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var smsalice = new SMSAliceResponse
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Nome = dbRec.FNome ?? string.Empty,
            TipoEMail = dbRec.FTipoEMail,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return smsalice;
    }

    public SMSAliceResponseAll? ReadAll(DBSMSAlice dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var smsalice = new SMSAliceResponseAll
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Nome = dbRec.FNome ?? string.Empty,
            TipoEMail = dbRec.FTipoEMail,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        smsalice.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        smsalice.NomeTipoEMail = dr["tmlNome"]?.ToString() ?? string.Empty;
        return smsalice;
    }

    public SMSAliceResponseAll? ReadAll(DBSMSAlice dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var smsalice = new SMSAliceResponseAll
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Nome = dbRec.FNome ?? string.Empty,
            TipoEMail = dbRec.FTipoEMail,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        smsalice.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        smsalice.NomeTipoEMail = dr["tmlNome"]?.ToString() ?? string.Empty;
        return smsalice;
    }
}