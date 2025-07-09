#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOponentesRepLegalReader
{
    OponentesRepLegalResponse? Read(int id, MsiSqlConnection oCnn);
    OponentesRepLegalResponse? Read(Entity.DBOponentesRepLegal dbRec, MsiSqlConnection oCnn);
    OponentesRepLegalResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OponentesRepLegalResponse? Read(Entity.DBOponentesRepLegal dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OponentesRepLegalResponse? Read(DBOponentesRepLegal dbRec);
    OponentesRepLegalResponseAll? ReadAll(DBOponentesRepLegal dbRec, DataRow dr);
    OponentesRepLegalResponseAll? ReadAll(DBOponentesRepLegal dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<OponentesRepLegalResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class OponentesRepLegal : IOponentesRepLegalReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{oprCodigo, oprNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<OponentesRepLegalResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<OponentesRepLegalResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<OponentesRepLegalResponseAll>> ReadLocalAsync()
        {
            var result = new List<OponentesRepLegalResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBOponentesRepLegal(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"OponentesRepLegal".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}oprNome");
        }

        return query.ToString();
    }

    public OponentesRepLegalResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOponentesRepLegal(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OponentesRepLegalResponse? Read(Entity.DBOponentesRepLegal dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public OponentesRepLegalResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOponentesRepLegal(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OponentesRepLegalResponse? Read(Entity.DBOponentesRepLegal dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var oponentesreplegal = new OponentesRepLegalResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Oponente = dbRec.FOponente,
            Sexo = dbRec.FSexo,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Cidade = dbRec.FCidade,
            Fax = dbRec.FFax ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Bold = dbRec.FBold,
        };
        return oponentesreplegal;
    }

    public OponentesRepLegalResponse? Read(DBOponentesRepLegal dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var oponentesreplegal = new OponentesRepLegalResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Oponente = dbRec.FOponente,
            Sexo = dbRec.FSexo,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Cidade = dbRec.FCidade,
            Fax = dbRec.FFax ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Bold = dbRec.FBold,
        };
        return oponentesreplegal;
    }

    public OponentesRepLegalResponseAll? ReadAll(DBOponentesRepLegal dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var oponentesreplegal = new OponentesRepLegalResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Oponente = dbRec.FOponente,
            Sexo = dbRec.FSexo,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Cidade = dbRec.FCidade,
            Fax = dbRec.FFax ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Bold = dbRec.FBold,
        };
        oponentesreplegal.NomeOponentes = dr["opoNome"]?.ToString() ?? string.Empty;
        oponentesreplegal.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return oponentesreplegal;
    }

    public OponentesRepLegalResponseAll? ReadAll(DBOponentesRepLegal dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var oponentesreplegal = new OponentesRepLegalResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Oponente = dbRec.FOponente,
            Sexo = dbRec.FSexo,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Cidade = dbRec.FCidade,
            Fax = dbRec.FFax ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Bold = dbRec.FBold,
        };
        oponentesreplegal.NomeOponentes = dr["opoNome"]?.ToString() ?? string.Empty;
        oponentesreplegal.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return oponentesreplegal;
    }
}