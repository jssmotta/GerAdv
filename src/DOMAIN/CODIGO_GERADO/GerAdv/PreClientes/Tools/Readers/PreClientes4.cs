#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IPreClientesReader
{
    PreClientesResponse? Read(int id, MsiSqlConnection oCnn);
    PreClientesResponse? Read(Entity.DBPreClientes dbRec, MsiSqlConnection oCnn);
    PreClientesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    PreClientesResponse? Read(Entity.DBPreClientes dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    PreClientesResponse? Read(DBPreClientes dbRec);
    PreClientesResponseAll? ReadAll(DBPreClientes dbRec, DataRow dr);
    PreClientesResponseAll? ReadAll(DBPreClientes dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<PreClientesResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class PreClientes : IPreClientesReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{cliCodigo, cliNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<PreClientesResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<PreClientesResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<PreClientesResponseAll>> ReadLocalAsync()
        {
            var result = new List<PreClientesResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBPreClientes(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"PreClientes".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}cliNome");
        }

        return query.ToString();
    }

    public PreClientesResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPreClientes(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PreClientesResponse? Read(Entity.DBPreClientes dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public PreClientesResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBPreClientes(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public PreClientesResponse? Read(Entity.DBPreClientes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var preclientes = new PreClientesResponse
        {
            Id = dbRec.ID,
            Inativo = dbRec.FInativo,
            QuemIndicou = dbRec.FQuemIndicou ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Adv = dbRec.FAdv,
            IDRep = dbRec.FIDRep,
            Juridica = dbRec.FJuridica,
            NomeFantasia = dbRec.FNomeFantasia ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Tipo = dbRec.FTipo,
            InscEst = dbRec.FInscEst ?? string.Empty,
            Qualificacao = dbRec.FQualificacao ?? string.Empty,
            Sexo = dbRec.FSexo,
            Idade = dbRec.FIdade,
            CNPJ = dbRec.FCNPJ?.MaskCnpj() ?? string.Empty,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            TipoCaptacao = dbRec.FTipoCaptacao,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Cidade = dbRec.FCidade,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            HomePage = dbRec.FHomePage ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Assistido = dbRec.FAssistido ?? string.Empty,
            AssRG = dbRec.FAssRG ?? string.Empty,
            AssCPF = dbRec.FAssCPF ?? string.Empty,
            AssEndereco = dbRec.FAssEndereco ?? string.Empty,
            CNH = dbRec.FCNH ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            preclientes.DtNasc = dbRec.FDtNasc;
        if (DateTime.TryParse(dbRec.FData, out _))
            preclientes.Data = dbRec.FData;
        return preclientes;
    }

    public PreClientesResponse? Read(DBPreClientes dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var preclientes = new PreClientesResponse
        {
            Id = dbRec.ID,
            Inativo = dbRec.FInativo,
            QuemIndicou = dbRec.FQuemIndicou ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Adv = dbRec.FAdv,
            IDRep = dbRec.FIDRep,
            Juridica = dbRec.FJuridica,
            NomeFantasia = dbRec.FNomeFantasia ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Tipo = dbRec.FTipo,
            InscEst = dbRec.FInscEst ?? string.Empty,
            Qualificacao = dbRec.FQualificacao ?? string.Empty,
            Sexo = dbRec.FSexo,
            Idade = dbRec.FIdade,
            CNPJ = dbRec.FCNPJ?.MaskCnpj() ?? string.Empty,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            TipoCaptacao = dbRec.FTipoCaptacao,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Cidade = dbRec.FCidade,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            HomePage = dbRec.FHomePage ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Assistido = dbRec.FAssistido ?? string.Empty,
            AssRG = dbRec.FAssRG ?? string.Empty,
            AssCPF = dbRec.FAssCPF ?? string.Empty,
            AssEndereco = dbRec.FAssEndereco ?? string.Empty,
            CNH = dbRec.FCNH ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            preclientes.DtNasc = dbRec.FDtNasc;
        if (DateTime.TryParse(dbRec.FData, out _))
            preclientes.Data = dbRec.FData;
        return preclientes;
    }

    public PreClientesResponseAll? ReadAll(DBPreClientes dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var preclientes = new PreClientesResponseAll
        {
            Id = dbRec.ID,
            Inativo = dbRec.FInativo,
            QuemIndicou = dbRec.FQuemIndicou ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Adv = dbRec.FAdv,
            IDRep = dbRec.FIDRep,
            Juridica = dbRec.FJuridica,
            NomeFantasia = dbRec.FNomeFantasia ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Tipo = dbRec.FTipo,
            InscEst = dbRec.FInscEst ?? string.Empty,
            Qualificacao = dbRec.FQualificacao ?? string.Empty,
            Sexo = dbRec.FSexo,
            Idade = dbRec.FIdade,
            CNPJ = dbRec.FCNPJ?.MaskCnpj() ?? string.Empty,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            TipoCaptacao = dbRec.FTipoCaptacao,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Cidade = dbRec.FCidade,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            HomePage = dbRec.FHomePage ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Assistido = dbRec.FAssistido ?? string.Empty,
            AssRG = dbRec.FAssRG ?? string.Empty,
            AssCPF = dbRec.FAssCPF ?? string.Empty,
            AssEndereco = dbRec.FAssEndereco ?? string.Empty,
            CNH = dbRec.FCNH ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            preclientes.DtNasc = dbRec.FDtNasc;
        if (DateTime.TryParse(dbRec.FData, out _))
            preclientes.Data = dbRec.FData;
        preclientes.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        preclientes.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return preclientes;
    }

    public PreClientesResponseAll? ReadAll(DBPreClientes dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var preclientes = new PreClientesResponseAll
        {
            Id = dbRec.ID,
            Inativo = dbRec.FInativo,
            QuemIndicou = dbRec.FQuemIndicou ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Adv = dbRec.FAdv,
            IDRep = dbRec.FIDRep,
            Juridica = dbRec.FJuridica,
            NomeFantasia = dbRec.FNomeFantasia ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Tipo = dbRec.FTipo,
            InscEst = dbRec.FInscEst ?? string.Empty,
            Qualificacao = dbRec.FQualificacao ?? string.Empty,
            Sexo = dbRec.FSexo,
            Idade = dbRec.FIdade,
            CNPJ = dbRec.FCNPJ?.MaskCnpj() ?? string.Empty,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            TipoCaptacao = dbRec.FTipoCaptacao,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Cidade = dbRec.FCidade,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            HomePage = dbRec.FHomePage ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Assistido = dbRec.FAssistido ?? string.Empty,
            AssRG = dbRec.FAssRG ?? string.Empty,
            AssCPF = dbRec.FAssCPF ?? string.Empty,
            AssEndereco = dbRec.FAssEndereco ?? string.Empty,
            CNH = dbRec.FCNH ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            preclientes.DtNasc = dbRec.FDtNasc;
        if (DateTime.TryParse(dbRec.FData, out _))
            preclientes.Data = dbRec.FData;
        preclientes.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        preclientes.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return preclientes;
    }
}