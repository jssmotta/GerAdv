#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IClientesSociosReader
{
    ClientesSociosResponse? Read(int id, MsiSqlConnection oCnn);
    ClientesSociosResponse? Read(Entity.DBClientesSocios dbRec, MsiSqlConnection oCnn);
    ClientesSociosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ClientesSociosResponse? Read(Entity.DBClientesSocios dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ClientesSociosResponse? Read(DBClientesSocios dbRec);
    ClientesSociosResponseAll? ReadAll(DBClientesSocios dbRec, DataRow dr);
    ClientesSociosResponseAll? ReadAll(DBClientesSocios dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<ClientesSociosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ClientesSocios : IClientesSociosReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{cscCodigo, cscNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<ClientesSociosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<ClientesSociosResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<ClientesSociosResponseAll>> ReadLocalAsync()
        {
            var result = new List<ClientesSociosResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBClientesSocios(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"ClientesSocios".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}cscNome");
        }

        return query.ToString();
    }

    public ClientesSociosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBClientesSocios(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ClientesSociosResponse? Read(Entity.DBClientesSocios dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public ClientesSociosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBClientesSocios(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ClientesSociosResponse? Read(Entity.DBClientesSocios dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var clientessocios = new ClientesSociosResponse
        {
            Id = dbRec.ID,
            SomenteRepresentante = dbRec.FSomenteRepresentante,
            Idade = dbRec.FIdade,
            IsRepresentanteLegal = dbRec.FIsRepresentanteLegal,
            Qualificacao = dbRec.FQualificacao ?? string.Empty,
            Sexo = dbRec.FSexo,
            Nome = dbRec.FNome ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            RepresentanteLegal = dbRec.FRepresentanteLegal ?? string.Empty,
            Cliente = dbRec.FCliente,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Cidade = dbRec.FCidade,
            RG = dbRec.FRG ?? string.Empty,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Participacao = dbRec.FParticipacao ?? string.Empty,
            Cargo = dbRec.FCargo ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Obs = dbRec.FObs ?? string.Empty,
            CNH = dbRec.FCNH ?? string.Empty,
            CNPJ = dbRec.FCNPJ?.MaskCnpj() ?? string.Empty,
            InscEst = dbRec.FInscEst ?? string.Empty,
            SocioEmpresaAdminNome = dbRec.FSocioEmpresaAdminNome ?? string.Empty,
            EnderecoSocio = dbRec.FEnderecoSocio ?? string.Empty,
            BairroSocio = dbRec.FBairroSocio ?? string.Empty,
            CEPSocio = dbRec.FCEPSocio ?? string.Empty,
            CidadeSocio = dbRec.FCidadeSocio,
            SocioEmpresaAdminSomente = dbRec.FSocioEmpresaAdminSomente,
            Tipo = dbRec.FTipo,
            Fax = dbRec.FFax ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            clientessocios.DtNasc = dbRec.FDtNasc;
        if (DateTime.TryParse(dbRec.FDataContrato, out _))
            clientessocios.DataContrato = dbRec.FDataContrato;
        if (DateTime.TryParse(dbRec.FRGDataExp, out _))
            clientessocios.RGDataExp = dbRec.FRGDataExp;
        return clientessocios;
    }

    public ClientesSociosResponse? Read(DBClientesSocios dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var clientessocios = new ClientesSociosResponse
        {
            Id = dbRec.ID,
            SomenteRepresentante = dbRec.FSomenteRepresentante,
            Idade = dbRec.FIdade,
            IsRepresentanteLegal = dbRec.FIsRepresentanteLegal,
            Qualificacao = dbRec.FQualificacao ?? string.Empty,
            Sexo = dbRec.FSexo,
            Nome = dbRec.FNome ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            RepresentanteLegal = dbRec.FRepresentanteLegal ?? string.Empty,
            Cliente = dbRec.FCliente,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Cidade = dbRec.FCidade,
            RG = dbRec.FRG ?? string.Empty,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Participacao = dbRec.FParticipacao ?? string.Empty,
            Cargo = dbRec.FCargo ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Obs = dbRec.FObs ?? string.Empty,
            CNH = dbRec.FCNH ?? string.Empty,
            CNPJ = dbRec.FCNPJ?.MaskCnpj() ?? string.Empty,
            InscEst = dbRec.FInscEst ?? string.Empty,
            SocioEmpresaAdminNome = dbRec.FSocioEmpresaAdminNome ?? string.Empty,
            EnderecoSocio = dbRec.FEnderecoSocio ?? string.Empty,
            BairroSocio = dbRec.FBairroSocio ?? string.Empty,
            CEPSocio = dbRec.FCEPSocio ?? string.Empty,
            CidadeSocio = dbRec.FCidadeSocio,
            SocioEmpresaAdminSomente = dbRec.FSocioEmpresaAdminSomente,
            Tipo = dbRec.FTipo,
            Fax = dbRec.FFax ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            clientessocios.DtNasc = dbRec.FDtNasc;
        if (DateTime.TryParse(dbRec.FDataContrato, out _))
            clientessocios.DataContrato = dbRec.FDataContrato;
        if (DateTime.TryParse(dbRec.FRGDataExp, out _))
            clientessocios.RGDataExp = dbRec.FRGDataExp;
        return clientessocios;
    }

    public ClientesSociosResponseAll? ReadAll(DBClientesSocios dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var clientessocios = new ClientesSociosResponseAll
        {
            Id = dbRec.ID,
            SomenteRepresentante = dbRec.FSomenteRepresentante,
            Idade = dbRec.FIdade,
            IsRepresentanteLegal = dbRec.FIsRepresentanteLegal,
            Qualificacao = dbRec.FQualificacao ?? string.Empty,
            Sexo = dbRec.FSexo,
            Nome = dbRec.FNome ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            RepresentanteLegal = dbRec.FRepresentanteLegal ?? string.Empty,
            Cliente = dbRec.FCliente,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Cidade = dbRec.FCidade,
            RG = dbRec.FRG ?? string.Empty,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Participacao = dbRec.FParticipacao ?? string.Empty,
            Cargo = dbRec.FCargo ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Obs = dbRec.FObs ?? string.Empty,
            CNH = dbRec.FCNH ?? string.Empty,
            CNPJ = dbRec.FCNPJ?.MaskCnpj() ?? string.Empty,
            InscEst = dbRec.FInscEst ?? string.Empty,
            SocioEmpresaAdminNome = dbRec.FSocioEmpresaAdminNome ?? string.Empty,
            EnderecoSocio = dbRec.FEnderecoSocio ?? string.Empty,
            BairroSocio = dbRec.FBairroSocio ?? string.Empty,
            CEPSocio = dbRec.FCEPSocio ?? string.Empty,
            CidadeSocio = dbRec.FCidadeSocio,
            SocioEmpresaAdminSomente = dbRec.FSocioEmpresaAdminSomente,
            Tipo = dbRec.FTipo,
            Fax = dbRec.FFax ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            clientessocios.DtNasc = dbRec.FDtNasc;
        if (DateTime.TryParse(dbRec.FDataContrato, out _))
            clientessocios.DataContrato = dbRec.FDataContrato;
        if (DateTime.TryParse(dbRec.FRGDataExp, out _))
            clientessocios.RGDataExp = dbRec.FRGDataExp;
        clientessocios.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        clientessocios.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return clientessocios;
    }

    public ClientesSociosResponseAll? ReadAll(DBClientesSocios dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var clientessocios = new ClientesSociosResponseAll
        {
            Id = dbRec.ID,
            SomenteRepresentante = dbRec.FSomenteRepresentante,
            Idade = dbRec.FIdade,
            IsRepresentanteLegal = dbRec.FIsRepresentanteLegal,
            Qualificacao = dbRec.FQualificacao ?? string.Empty,
            Sexo = dbRec.FSexo,
            Nome = dbRec.FNome ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            RepresentanteLegal = dbRec.FRepresentanteLegal ?? string.Empty,
            Cliente = dbRec.FCliente,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Cidade = dbRec.FCidade,
            RG = dbRec.FRG ?? string.Empty,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Participacao = dbRec.FParticipacao ?? string.Empty,
            Cargo = dbRec.FCargo ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Obs = dbRec.FObs ?? string.Empty,
            CNH = dbRec.FCNH ?? string.Empty,
            CNPJ = dbRec.FCNPJ?.MaskCnpj() ?? string.Empty,
            InscEst = dbRec.FInscEst ?? string.Empty,
            SocioEmpresaAdminNome = dbRec.FSocioEmpresaAdminNome ?? string.Empty,
            EnderecoSocio = dbRec.FEnderecoSocio ?? string.Empty,
            BairroSocio = dbRec.FBairroSocio ?? string.Empty,
            CEPSocio = dbRec.FCEPSocio ?? string.Empty,
            CidadeSocio = dbRec.FCidadeSocio,
            SocioEmpresaAdminSomente = dbRec.FSocioEmpresaAdminSomente,
            Tipo = dbRec.FTipo,
            Fax = dbRec.FFax ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            clientessocios.DtNasc = dbRec.FDtNasc;
        if (DateTime.TryParse(dbRec.FDataContrato, out _))
            clientessocios.DataContrato = dbRec.FDataContrato;
        if (DateTime.TryParse(dbRec.FRGDataExp, out _))
            clientessocios.RGDataExp = dbRec.FRGDataExp;
        clientessocios.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        clientessocios.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return clientessocios;
    }
}