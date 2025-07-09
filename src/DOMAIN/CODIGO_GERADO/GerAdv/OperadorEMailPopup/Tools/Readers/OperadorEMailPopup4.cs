#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOperadorEMailPopupReader
{
    OperadorEMailPopupResponse? Read(int id, MsiSqlConnection oCnn);
    OperadorEMailPopupResponse? Read(Entity.DBOperadorEMailPopup dbRec, MsiSqlConnection oCnn);
    OperadorEMailPopupResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OperadorEMailPopupResponse? Read(Entity.DBOperadorEMailPopup dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OperadorEMailPopupResponse? Read(DBOperadorEMailPopup dbRec);
    OperadorEMailPopupResponseAll? ReadAll(DBOperadorEMailPopup dbRec, DataRow dr);
    OperadorEMailPopupResponseAll? ReadAll(DBOperadorEMailPopup dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<OperadorEMailPopupResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class OperadorEMailPopup : IOperadorEMailPopupReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{oepCodigo, oepNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<OperadorEMailPopupResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<OperadorEMailPopupResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<OperadorEMailPopupResponseAll>> ReadLocalAsync()
        {
            var result = new List<OperadorEMailPopupResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBOperadorEMailPopup(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"OperadorEMailPopup".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}oepNome");
        }

        return query.ToString();
    }

    public OperadorEMailPopupResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorEMailPopup(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadorEMailPopupResponse? Read(Entity.DBOperadorEMailPopup dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public OperadorEMailPopupResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOperadorEMailPopup(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OperadorEMailPopupResponse? Read(Entity.DBOperadorEMailPopup dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadoremailpopup = new OperadorEMailPopupResponse
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Nome = dbRec.FNome ?? string.Empty,
            SMTP = dbRec.FSMTP ?? string.Empty,
            POP3 = dbRec.FPOP3 ?? string.Empty,
            Autenticacao = dbRec.FAutenticacao,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Usuario = dbRec.FUsuario ?? string.Empty,
            PortaSmtp = dbRec.FPortaSmtp,
            PortaPop3 = dbRec.FPortaPop3,
            Assinatura = dbRec.FAssinatura ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return operadoremailpopup;
    }

    public OperadorEMailPopupResponse? Read(DBOperadorEMailPopup dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadoremailpopup = new OperadorEMailPopupResponse
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Nome = dbRec.FNome ?? string.Empty,
            SMTP = dbRec.FSMTP ?? string.Empty,
            POP3 = dbRec.FPOP3 ?? string.Empty,
            Autenticacao = dbRec.FAutenticacao,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Usuario = dbRec.FUsuario ?? string.Empty,
            PortaSmtp = dbRec.FPortaSmtp,
            PortaPop3 = dbRec.FPortaPop3,
            Assinatura = dbRec.FAssinatura ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return operadoremailpopup;
    }

    public OperadorEMailPopupResponseAll? ReadAll(DBOperadorEMailPopup dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadoremailpopup = new OperadorEMailPopupResponseAll
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Nome = dbRec.FNome ?? string.Empty,
            SMTP = dbRec.FSMTP ?? string.Empty,
            POP3 = dbRec.FPOP3 ?? string.Empty,
            Autenticacao = dbRec.FAutenticacao,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Usuario = dbRec.FUsuario ?? string.Empty,
            PortaSmtp = dbRec.FPortaSmtp,
            PortaPop3 = dbRec.FPortaPop3,
            Assinatura = dbRec.FAssinatura ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        operadoremailpopup.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return operadoremailpopup;
    }

    public OperadorEMailPopupResponseAll? ReadAll(DBOperadorEMailPopup dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var operadoremailpopup = new OperadorEMailPopupResponseAll
        {
            Id = dbRec.ID,
            Operador = dbRec.FOperador,
            Nome = dbRec.FNome ?? string.Empty,
            SMTP = dbRec.FSMTP ?? string.Empty,
            POP3 = dbRec.FPOP3 ?? string.Empty,
            Autenticacao = dbRec.FAutenticacao,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Usuario = dbRec.FUsuario ?? string.Empty,
            PortaSmtp = dbRec.FPortaSmtp,
            PortaPop3 = dbRec.FPortaPop3,
            Assinatura = dbRec.FAssinatura ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        operadoremailpopup.NomeOperador = dr["operNome"]?.ToString() ?? string.Empty;
        return operadoremailpopup;
    }
}