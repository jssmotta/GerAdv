#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IForoReader
{
    ForoResponse? Read(int id, MsiSqlConnection oCnn);
    ForoResponse? Read(Entity.DBForo dbRec, MsiSqlConnection oCnn);
    ForoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ForoResponse? Read(Entity.DBForo dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ForoResponse? Read(DBForo dbRec);
    ForoResponseAll? ReadAll(DBForo dbRec, DataRow dr);
    ForoResponseAll? ReadAll(DBForo dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<ForoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Foro : IForoReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{forCodigo, forNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<ForoResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<ForoResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<ForoResponseAll>> ReadLocalAsync()
        {
            var result = new List<ForoResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBForo(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Foro".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}forNome");
        }

        return query.ToString();
    }

    public ForoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBForo(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ForoResponse? Read(Entity.DBForo dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public ForoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBForo(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ForoResponse? Read(Entity.DBForo dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var foro = new ForoResponse
        {
            Id = dbRec.ID,
            EMail = dbRec.FEMail ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Unico = dbRec.FUnico,
            Cidade = dbRec.FCidade,
            Site = dbRec.FSite ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            UnicoConfirmado = dbRec.FUnicoConfirmado,
            Web = dbRec.FWeb ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
        };
        return foro;
    }

    public ForoResponse? Read(DBForo dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var foro = new ForoResponse
        {
            Id = dbRec.ID,
            EMail = dbRec.FEMail ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Unico = dbRec.FUnico,
            Cidade = dbRec.FCidade,
            Site = dbRec.FSite ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            UnicoConfirmado = dbRec.FUnicoConfirmado,
            Web = dbRec.FWeb ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
        };
        return foro;
    }

    public ForoResponseAll? ReadAll(DBForo dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var foro = new ForoResponseAll
        {
            Id = dbRec.ID,
            EMail = dbRec.FEMail ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Unico = dbRec.FUnico,
            Cidade = dbRec.FCidade,
            Site = dbRec.FSite ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            UnicoConfirmado = dbRec.FUnicoConfirmado,
            Web = dbRec.FWeb ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
        };
        foro.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return foro;
    }

    public ForoResponseAll? ReadAll(DBForo dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var foro = new ForoResponseAll
        {
            Id = dbRec.ID,
            EMail = dbRec.FEMail ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Unico = dbRec.FUnico,
            Cidade = dbRec.FCidade,
            Site = dbRec.FSite ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            UnicoConfirmado = dbRec.FUnicoConfirmado,
            Web = dbRec.FWeb ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
        };
        foro.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return foro;
    }
}