#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IFuncionariosReader
{
    FuncionariosResponse? Read(int id, MsiSqlConnection oCnn);
    FuncionariosResponse? Read(Entity.DBFuncionarios dbRec, MsiSqlConnection oCnn);
    FuncionariosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    FuncionariosResponse? Read(Entity.DBFuncionarios dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    FuncionariosResponse? Read(DBFuncionarios dbRec);
    FuncionariosResponseAll? ReadAll(DBFuncionarios dbRec, DataRow dr);
    FuncionariosResponseAll? ReadAll(DBFuncionarios dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<FuncionariosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Funcionarios : IFuncionariosReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{funCodigo, funNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<FuncionariosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<FuncionariosResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<FuncionariosResponseAll>> ReadLocalAsync()
        {
            var result = new List<FuncionariosResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBFuncionarios(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Funcionarios".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}funNome");
        }

        return query.ToString();
    }

    public FuncionariosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBFuncionarios(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public FuncionariosResponse? Read(Entity.DBFuncionarios dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public FuncionariosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBFuncionarios(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public FuncionariosResponse? Read(Entity.DBFuncionarios dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var funcionarios = new FuncionariosResponse
        {
            Id = dbRec.ID,
            EMailPro = dbRec.FEMailPro ?? string.Empty,
            Cargo = dbRec.FCargo,
            Nome = dbRec.FNome ?? string.Empty,
            Funcao = dbRec.FFuncao,
            Sexo = dbRec.FSexo,
            Registro = dbRec.FRegistro ?? string.Empty,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Tipo = dbRec.FTipo,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Cidade = dbRec.FCidade,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Contato = dbRec.FContato ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            CTPSNumero = dbRec.FCTPSNumero ?? string.Empty,
            CTPSSerie = dbRec.FCTPSSerie ?? string.Empty,
            PIS = dbRec.FPIS ?? string.Empty,
            Salario = dbRec.FSalario,
            LiberaAgenda = dbRec.FLiberaAgenda,
            Pasta = dbRec.FPasta ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FPeriodo_Ini, out _))
            funcionarios.Periodo_Ini = dbRec.FPeriodo_Ini;
        if (DateTime.TryParse(dbRec.FPeriodo_Fim, out _))
            funcionarios.Periodo_Fim = dbRec.FPeriodo_Fim;
        if (DateTime.TryParse(dbRec.FCTPSDtEmissao, out _))
            funcionarios.CTPSDtEmissao = dbRec.FCTPSDtEmissao;
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            funcionarios.DtNasc = dbRec.FDtNasc;
        if (DateTime.TryParse(dbRec.FData, out _))
            funcionarios.Data = dbRec.FData;
        return funcionarios;
    }

    public FuncionariosResponse? Read(DBFuncionarios dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var funcionarios = new FuncionariosResponse
        {
            Id = dbRec.ID,
            EMailPro = dbRec.FEMailPro ?? string.Empty,
            Cargo = dbRec.FCargo,
            Nome = dbRec.FNome ?? string.Empty,
            Funcao = dbRec.FFuncao,
            Sexo = dbRec.FSexo,
            Registro = dbRec.FRegistro ?? string.Empty,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Tipo = dbRec.FTipo,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Cidade = dbRec.FCidade,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Contato = dbRec.FContato ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            CTPSNumero = dbRec.FCTPSNumero ?? string.Empty,
            CTPSSerie = dbRec.FCTPSSerie ?? string.Empty,
            PIS = dbRec.FPIS ?? string.Empty,
            Salario = dbRec.FSalario,
            LiberaAgenda = dbRec.FLiberaAgenda,
            Pasta = dbRec.FPasta ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FPeriodo_Ini, out _))
            funcionarios.Periodo_Ini = dbRec.FPeriodo_Ini;
        if (DateTime.TryParse(dbRec.FPeriodo_Fim, out _))
            funcionarios.Periodo_Fim = dbRec.FPeriodo_Fim;
        if (DateTime.TryParse(dbRec.FCTPSDtEmissao, out _))
            funcionarios.CTPSDtEmissao = dbRec.FCTPSDtEmissao;
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            funcionarios.DtNasc = dbRec.FDtNasc;
        if (DateTime.TryParse(dbRec.FData, out _))
            funcionarios.Data = dbRec.FData;
        return funcionarios;
    }

    public FuncionariosResponseAll? ReadAll(DBFuncionarios dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var funcionarios = new FuncionariosResponseAll
        {
            Id = dbRec.ID,
            EMailPro = dbRec.FEMailPro ?? string.Empty,
            Cargo = dbRec.FCargo,
            Nome = dbRec.FNome ?? string.Empty,
            Funcao = dbRec.FFuncao,
            Sexo = dbRec.FSexo,
            Registro = dbRec.FRegistro ?? string.Empty,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Tipo = dbRec.FTipo,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Cidade = dbRec.FCidade,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Contato = dbRec.FContato ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            CTPSNumero = dbRec.FCTPSNumero ?? string.Empty,
            CTPSSerie = dbRec.FCTPSSerie ?? string.Empty,
            PIS = dbRec.FPIS ?? string.Empty,
            Salario = dbRec.FSalario,
            LiberaAgenda = dbRec.FLiberaAgenda,
            Pasta = dbRec.FPasta ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FPeriodo_Ini, out _))
            funcionarios.Periodo_Ini = dbRec.FPeriodo_Ini;
        if (DateTime.TryParse(dbRec.FPeriodo_Fim, out _))
            funcionarios.Periodo_Fim = dbRec.FPeriodo_Fim;
        if (DateTime.TryParse(dbRec.FCTPSDtEmissao, out _))
            funcionarios.CTPSDtEmissao = dbRec.FCTPSDtEmissao;
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            funcionarios.DtNasc = dbRec.FDtNasc;
        if (DateTime.TryParse(dbRec.FData, out _))
            funcionarios.Data = dbRec.FData;
        funcionarios.NomeCargos = dr["carNome"]?.ToString() ?? string.Empty;
        funcionarios.DescricaoFuncao = dr["funDescricao"]?.ToString() ?? string.Empty;
        funcionarios.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return funcionarios;
    }

    public FuncionariosResponseAll? ReadAll(DBFuncionarios dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var funcionarios = new FuncionariosResponseAll
        {
            Id = dbRec.ID,
            EMailPro = dbRec.FEMailPro ?? string.Empty,
            Cargo = dbRec.FCargo,
            Nome = dbRec.FNome ?? string.Empty,
            Funcao = dbRec.FFuncao,
            Sexo = dbRec.FSexo,
            Registro = dbRec.FRegistro ?? string.Empty,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Tipo = dbRec.FTipo,
            Observacao = dbRec.FObservacao ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Cidade = dbRec.FCidade,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Contato = dbRec.FContato ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            CTPSNumero = dbRec.FCTPSNumero ?? string.Empty,
            CTPSSerie = dbRec.FCTPSSerie ?? string.Empty,
            PIS = dbRec.FPIS ?? string.Empty,
            Salario = dbRec.FSalario,
            LiberaAgenda = dbRec.FLiberaAgenda,
            Pasta = dbRec.FPasta ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FPeriodo_Ini, out _))
            funcionarios.Periodo_Ini = dbRec.FPeriodo_Ini;
        if (DateTime.TryParse(dbRec.FPeriodo_Fim, out _))
            funcionarios.Periodo_Fim = dbRec.FPeriodo_Fim;
        if (DateTime.TryParse(dbRec.FCTPSDtEmissao, out _))
            funcionarios.CTPSDtEmissao = dbRec.FCTPSDtEmissao;
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            funcionarios.DtNasc = dbRec.FDtNasc;
        if (DateTime.TryParse(dbRec.FData, out _))
            funcionarios.Data = dbRec.FData;
        funcionarios.NomeCargos = dr["carNome"]?.ToString() ?? string.Empty;
        funcionarios.DescricaoFuncao = dr["funDescricao"]?.ToString() ?? string.Empty;
        funcionarios.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return funcionarios;
    }
}