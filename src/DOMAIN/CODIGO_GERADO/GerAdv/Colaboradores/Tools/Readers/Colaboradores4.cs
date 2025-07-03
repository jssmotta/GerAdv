#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IColaboradoresReader
{
    ColaboradoresResponse? Read(int id, MsiSqlConnection oCnn);
    ColaboradoresResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ColaboradoresResponse? Read(Entity.DBColaboradores dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ColaboradoresResponse? Read(DBColaboradores dbRec);
    ColaboradoresResponseAll? ReadAll(DBColaboradores dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Colaboradores : IColaboradoresReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) colCodigo, colNome FROM {"Colaboradores".dbo(oCnn)} (NOLOCK) ");
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
}