#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IOponentesRepLegalReader
{
    OponentesRepLegalResponse? Read(int id, MsiSqlConnection oCnn);
    OponentesRepLegalResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OponentesRepLegalResponse? Read(Entity.DBOponentesRepLegal dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    OponentesRepLegalResponse? Read(DBOponentesRepLegal dbRec);
    OponentesRepLegalResponseAll? ReadAll(DBOponentesRepLegal dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class OponentesRepLegal : IOponentesRepLegalReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) oprCodigo, oprNome FROM {"OponentesRepLegal".dbo(oCnn)} (NOLOCK) ");
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
}