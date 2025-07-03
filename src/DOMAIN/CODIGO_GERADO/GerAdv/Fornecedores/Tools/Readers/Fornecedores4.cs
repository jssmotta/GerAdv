#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IFornecedoresReader
{
    FornecedoresResponse? Read(int id, MsiSqlConnection oCnn);
    FornecedoresResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    FornecedoresResponse? Read(Entity.DBFornecedores dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    FornecedoresResponse? Read(DBFornecedores dbRec);
    FornecedoresResponseAll? ReadAll(DBFornecedores dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Fornecedores : IFornecedoresReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) forCodigo, forNome FROM {"Fornecedores".dbo(oCnn)} (NOLOCK) ");
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

    public FornecedoresResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBFornecedores(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public FornecedoresResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBFornecedores(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public FornecedoresResponse? Read(Entity.DBFornecedores dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var fornecedores = new FornecedoresResponse
        {
            Id = dbRec.ID,
            Grupo = dbRec.FGrupo,
            Nome = dbRec.FNome ?? string.Empty,
            SubGrupo = dbRec.FSubGrupo,
            Tipo = dbRec.FTipo,
            Sexo = dbRec.FSexo,
            CNPJ = dbRec.FCNPJ?.MaskCnpj() ?? string.Empty,
            InscEst = dbRec.FInscEst ?? string.Empty,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Cidade = dbRec.FCidade,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Email = dbRec.FEmail ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            Obs = dbRec.FObs ?? string.Empty,
            Produtos = dbRec.FProdutos ?? string.Empty,
            Contatos = dbRec.FContatos ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return fornecedores;
    }

    public FornecedoresResponse? Read(DBFornecedores dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var fornecedores = new FornecedoresResponse
        {
            Id = dbRec.ID,
            Grupo = dbRec.FGrupo,
            Nome = dbRec.FNome ?? string.Empty,
            SubGrupo = dbRec.FSubGrupo,
            Tipo = dbRec.FTipo,
            Sexo = dbRec.FSexo,
            CNPJ = dbRec.FCNPJ?.MaskCnpj() ?? string.Empty,
            InscEst = dbRec.FInscEst ?? string.Empty,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Cidade = dbRec.FCidade,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Email = dbRec.FEmail ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            Obs = dbRec.FObs ?? string.Empty,
            Produtos = dbRec.FProdutos ?? string.Empty,
            Contatos = dbRec.FContatos ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return fornecedores;
    }

    public FornecedoresResponseAll? ReadAll(DBFornecedores dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var fornecedores = new FornecedoresResponseAll
        {
            Id = dbRec.ID,
            Grupo = dbRec.FGrupo,
            Nome = dbRec.FNome ?? string.Empty,
            SubGrupo = dbRec.FSubGrupo,
            Tipo = dbRec.FTipo,
            Sexo = dbRec.FSexo,
            CNPJ = dbRec.FCNPJ?.MaskCnpj() ?? string.Empty,
            InscEst = dbRec.FInscEst ?? string.Empty,
            CPF = dbRec.FCPF?.MaskCpf() ?? string.Empty,
            RG = dbRec.FRG ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Cidade = dbRec.FCidade,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Email = dbRec.FEmail ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            Obs = dbRec.FObs ?? string.Empty,
            Produtos = dbRec.FProdutos ?? string.Empty,
            Contatos = dbRec.FContatos ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        fornecedores.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return fornecedores;
    }
}