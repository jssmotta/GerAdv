#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IColaboradoresReader
{
    ColaboradoresResponse? Read(int id, MsiSqlConnection oCnn);
    ColaboradoresResponse? Read(Entity.DBColaboradores dbRec, MsiSqlConnection oCnn);
    ColaboradoresResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ColaboradoresResponse? Read(Entity.DBColaboradores dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ColaboradoresResponse? Read(DBColaboradores dbRec);
    ColaboradoresResponseAll? ReadAll(DBColaboradores dbRec, DataRow dr);
    ColaboradoresResponseAll? ReadAll(DBColaboradores dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<ColaboradoresResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Colaboradores : IColaboradoresReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{colCodigo, colNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<ColaboradoresResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<ColaboradoresResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<ColaboradoresResponseAll>> ReadLocalAsync()
        {
            var result = new List<ColaboradoresResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBColaboradores(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"Colaboradores".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}colNome");
        }

        return query.ToString();
    }

    public ColaboradoresResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBColaboradores(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ColaboradoresResponse? Read(Entity.DBColaboradores dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public ColaboradoresResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBColaboradores(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ColaboradoresResponse? Read(Entity.DBColaboradores dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var colaboradores = new ColaboradoresResponse
        {
            Id = dbRec.ID,
            Cargo = dbRec.FCargo,
            Cliente = dbRec.FCliente,
            Sexo = dbRec.FSexo,
            Nome = dbRec.FNome ?? string.Empty,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Idade = dbRec.FIdade,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Cidade = dbRec.FCidade,
            Fone = dbRec.FFone ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            CNH = dbRec.FCNH ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            colaboradores.DtNasc = dbRec.FDtNasc;
        return colaboradores;
    }

    public ColaboradoresResponse? Read(DBColaboradores dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var colaboradores = new ColaboradoresResponse
        {
            Id = dbRec.ID,
            Cargo = dbRec.FCargo,
            Cliente = dbRec.FCliente,
            Sexo = dbRec.FSexo,
            Nome = dbRec.FNome ?? string.Empty,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Idade = dbRec.FIdade,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Cidade = dbRec.FCidade,
            Fone = dbRec.FFone ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            CNH = dbRec.FCNH ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            colaboradores.DtNasc = dbRec.FDtNasc;
        return colaboradores;
    }

    public ColaboradoresResponseAll? ReadAll(DBColaboradores dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var colaboradores = new ColaboradoresResponseAll
        {
            Id = dbRec.ID,
            Cargo = dbRec.FCargo,
            Cliente = dbRec.FCliente,
            Sexo = dbRec.FSexo,
            Nome = dbRec.FNome ?? string.Empty,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Idade = dbRec.FIdade,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Cidade = dbRec.FCidade,
            Fone = dbRec.FFone ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            CNH = dbRec.FCNH ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            colaboradores.DtNasc = dbRec.FDtNasc;
        colaboradores.NomeCargos = dr["carNome"]?.ToString() ?? string.Empty;
        colaboradores.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        colaboradores.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return colaboradores;
    }

    public ColaboradoresResponseAll? ReadAll(DBColaboradores dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var colaboradores = new ColaboradoresResponseAll
        {
            Id = dbRec.ID,
            Cargo = dbRec.FCargo,
            Cliente = dbRec.FCliente,
            Sexo = dbRec.FSexo,
            Nome = dbRec.FNome ?? string.Empty,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Idade = dbRec.FIdade,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Cidade = dbRec.FCidade,
            Fone = dbRec.FFone ?? string.Empty,
            Observacao = dbRec.FObservacao ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            CNH = dbRec.FCNH ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Ani = dbRec.FAni,
            Bold = dbRec.FBold,
        };
        if (DateTime.TryParse(dbRec.FDtNasc, out _))
            colaboradores.DtNasc = dbRec.FDtNasc;
        colaboradores.NomeCargos = dr["carNome"]?.ToString() ?? string.Empty;
        colaboradores.NomeClientes = dr["cliNome"]?.ToString() ?? string.Empty;
        colaboradores.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return colaboradores;
    }
}