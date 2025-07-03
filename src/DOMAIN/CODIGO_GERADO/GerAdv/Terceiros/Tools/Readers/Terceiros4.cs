#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface ITerceirosReader
{
    TerceirosResponse? Read(int id, MsiSqlConnection oCnn);
    TerceirosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TerceirosResponse? Read(Entity.DBTerceiros dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    TerceirosResponse? Read(DBTerceiros dbRec);
    TerceirosResponseAll? ReadAll(DBTerceiros dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Terceiros : ITerceirosReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) terCodigo, terNome FROM {"Terceiros".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}terNome");
        }

        return query.ToString();
    }

    public TerceirosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTerceiros(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TerceirosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBTerceiros(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public TerceirosResponse? Read(Entity.DBTerceiros dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var terceiros = new TerceirosResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Situacao = dbRec.FSituacao,
            Cidade = dbRec.FCidade,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            VaraForoComarca = dbRec.FVaraForoComarca ?? string.Empty,
            Sexo = dbRec.FSexo,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return terceiros;
    }

    public TerceirosResponse? Read(DBTerceiros dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var terceiros = new TerceirosResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Situacao = dbRec.FSituacao,
            Cidade = dbRec.FCidade,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            VaraForoComarca = dbRec.FVaraForoComarca ?? string.Empty,
            Sexo = dbRec.FSexo,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return terceiros;
    }

    public TerceirosResponseAll? ReadAll(DBTerceiros dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var terceiros = new TerceirosResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Nome = dbRec.FNome ?? string.Empty,
            Situacao = dbRec.FSituacao,
            Cidade = dbRec.FCidade,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Class = dbRec.FClass ?? string.Empty,
            VaraForoComarca = dbRec.FVaraForoComarca ?? string.Empty,
            Sexo = dbRec.FSexo,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        terceiros.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        terceiros.DescricaoPosicaoOutrasPartes = dr["posDescricao"]?.ToString() ?? string.Empty;
        terceiros.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return terceiros;
    }
}