#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOutrasPartesClienteReader
{
    OutrasPartesClienteResponse? Read(int id, MsiSqlConnection oCnn);
    OutrasPartesClienteResponse? Read(Entity.DBOutrasPartesCliente dbRec, MsiSqlConnection oCnn);
    OutrasPartesClienteResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OutrasPartesClienteResponse? Read(Entity.DBOutrasPartesCliente dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OutrasPartesClienteResponse? Read(DBOutrasPartesCliente dbRec);
    OutrasPartesClienteResponseAll? ReadAll(DBOutrasPartesCliente dbRec, DataRow dr);
    OutrasPartesClienteResponseAll? ReadAll(DBOutrasPartesCliente dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<OutrasPartesClienteResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class OutrasPartesCliente : IOutrasPartesClienteReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{opcCodigo, opcNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<OutrasPartesClienteResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<OutrasPartesClienteResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<OutrasPartesClienteResponseAll>> ReadLocalAsync()
        {
            var result = new List<OutrasPartesClienteResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBOutrasPartesCliente(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"OutrasPartesCliente".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}opcNome");
        }

        return query.ToString();
    }

    public OutrasPartesClienteResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOutrasPartesCliente(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OutrasPartesClienteResponse? Read(Entity.DBOutrasPartesCliente dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public OutrasPartesClienteResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBOutrasPartesCliente(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public OutrasPartesClienteResponse? Read(Entity.DBOutrasPartesCliente dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var outraspartescliente = new OutrasPartesClienteResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Terceirizado = dbRec.FTerceirizado,
            ClientePrincipal = dbRec.FClientePrincipal,
            Tipo = dbRec.FTipo,
            Sexo = dbRec.FSexo,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            CNPJ = dbRec.FCNPJ?.MaskCnpj() ?? string.Empty,
            InscEst = dbRec.FInscEst ?? string.Empty,
            NomeFantasia = dbRec.FNomeFantasia ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Cidade = dbRec.FCidade,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            outraspartescliente.DtNasc = dbRec.FDtNasc;
        return outraspartescliente;
    }

    public OutrasPartesClienteResponse? Read(DBOutrasPartesCliente dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var outraspartescliente = new OutrasPartesClienteResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Terceirizado = dbRec.FTerceirizado,
            ClientePrincipal = dbRec.FClientePrincipal,
            Tipo = dbRec.FTipo,
            Sexo = dbRec.FSexo,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            CNPJ = dbRec.FCNPJ?.MaskCnpj() ?? string.Empty,
            InscEst = dbRec.FInscEst ?? string.Empty,
            NomeFantasia = dbRec.FNomeFantasia ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Cidade = dbRec.FCidade,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            outraspartescliente.DtNasc = dbRec.FDtNasc;
        return outraspartescliente;
    }

    public OutrasPartesClienteResponseAll? ReadAll(DBOutrasPartesCliente dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var outraspartescliente = new OutrasPartesClienteResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Terceirizado = dbRec.FTerceirizado,
            ClientePrincipal = dbRec.FClientePrincipal,
            Tipo = dbRec.FTipo,
            Sexo = dbRec.FSexo,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            CNPJ = dbRec.FCNPJ?.MaskCnpj() ?? string.Empty,
            InscEst = dbRec.FInscEst ?? string.Empty,
            NomeFantasia = dbRec.FNomeFantasia ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Cidade = dbRec.FCidade,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            outraspartescliente.DtNasc = dbRec.FDtNasc;
        outraspartescliente.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return outraspartescliente;
    }

    public OutrasPartesClienteResponseAll? ReadAll(DBOutrasPartesCliente dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var outraspartescliente = new OutrasPartesClienteResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Terceirizado = dbRec.FTerceirizado,
            ClientePrincipal = dbRec.FClientePrincipal,
            Tipo = dbRec.FTipo,
            Sexo = dbRec.FSexo,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            CNPJ = dbRec.FCNPJ?.MaskCnpj() ?? string.Empty,
            InscEst = dbRec.FInscEst ?? string.Empty,
            NomeFantasia = dbRec.FNomeFantasia ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Cidade = dbRec.FCidade,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            outraspartescliente.DtNasc = dbRec.FDtNasc;
        outraspartescliente.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return outraspartescliente;
    }
}