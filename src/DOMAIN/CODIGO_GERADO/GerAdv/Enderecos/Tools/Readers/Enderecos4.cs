#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEnderecosReader
{
    EnderecosResponse? Read(int id, MsiSqlConnection oCnn);
    EnderecosResponse? Read(Entity.DBEnderecos dbRec, MsiSqlConnection oCnn);
    EnderecosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    EnderecosResponse? Read(Entity.DBEnderecos dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    EnderecosResponse? Read(DBEnderecos dbRec);
    EnderecosResponseAll? ReadAll(DBEnderecos dbRec, DataRow dr);
    EnderecosResponseAll? ReadAll(DBEnderecos dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<EnderecosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Enderecos : IEnderecosReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{endCodigo, endDescricao}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<EnderecosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<EnderecosResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<EnderecosResponseAll>> ReadLocalAsync()
        {
            var result = new List<EnderecosResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBEnderecos(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Enderecos".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}endDescricao");
        }

        return query.ToString();
    }

    public EnderecosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEnderecos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EnderecosResponse? Read(Entity.DBEnderecos dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public EnderecosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEnderecos(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EnderecosResponse? Read(Entity.DBEnderecos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var enderecos = new EnderecosResponse
        {
            Id = dbRec.ID,
            TopIndex = dbRec.FTopIndex,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Contato = dbRec.FContato ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Privativo = dbRec.FPrivativo,
            AddContato = dbRec.FAddContato,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            OAB = dbRec.FOAB ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Tratamento = dbRec.FTratamento ?? string.Empty,
            Cidade = dbRec.FCidade,
            Site = dbRec.FSite ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Quem = dbRec.FQuem,
            QuemIndicou = dbRec.FQuemIndicou ?? string.Empty,
            ReportECBOnly = dbRec.FReportECBOnly,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            enderecos.DtNasc = dbRec.FDtNasc;
        return enderecos;
    }

    public EnderecosResponse? Read(DBEnderecos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var enderecos = new EnderecosResponse
        {
            Id = dbRec.ID,
            TopIndex = dbRec.FTopIndex,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Contato = dbRec.FContato ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Privativo = dbRec.FPrivativo,
            AddContato = dbRec.FAddContato,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            OAB = dbRec.FOAB ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Tratamento = dbRec.FTratamento ?? string.Empty,
            Cidade = dbRec.FCidade,
            Site = dbRec.FSite ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Quem = dbRec.FQuem,
            QuemIndicou = dbRec.FQuemIndicou ?? string.Empty,
            ReportECBOnly = dbRec.FReportECBOnly,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            enderecos.DtNasc = dbRec.FDtNasc;
        return enderecos;
    }

    public EnderecosResponseAll? ReadAll(DBEnderecos dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var enderecos = new EnderecosResponseAll
        {
            Id = dbRec.ID,
            TopIndex = dbRec.FTopIndex,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Contato = dbRec.FContato ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Privativo = dbRec.FPrivativo,
            AddContato = dbRec.FAddContato,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            OAB = dbRec.FOAB ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Tratamento = dbRec.FTratamento ?? string.Empty,
            Cidade = dbRec.FCidade,
            Site = dbRec.FSite ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Quem = dbRec.FQuem,
            QuemIndicou = dbRec.FQuemIndicou ?? string.Empty,
            ReportECBOnly = dbRec.FReportECBOnly,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            enderecos.DtNasc = dbRec.FDtNasc;
        enderecos.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return enderecos;
    }

    public EnderecosResponseAll? ReadAll(DBEnderecos dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var enderecos = new EnderecosResponseAll
        {
            Id = dbRec.ID,
            TopIndex = dbRec.FTopIndex,
            Descricao = dbRec.FDescricao ?? string.Empty,
            Contato = dbRec.FContato ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Privativo = dbRec.FPrivativo,
            AddContato = dbRec.FAddContato,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            OAB = dbRec.FOAB ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Tratamento = dbRec.FTratamento ?? string.Empty,
            Cidade = dbRec.FCidade,
            Site = dbRec.FSite ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Quem = dbRec.FQuem,
            QuemIndicou = dbRec.FQuemIndicou ?? string.Empty,
            ReportECBOnly = dbRec.FReportECBOnly,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            enderecos.DtNasc = dbRec.FDtNasc;
        enderecos.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return enderecos;
    }
}