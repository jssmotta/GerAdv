#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IEscritoriosReader
{
    EscritoriosResponse? Read(int id, MsiSqlConnection oCnn);
    EscritoriosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    EscritoriosResponse? Read(Entity.DBEscritorios dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    EscritoriosResponse? Read(DBEscritorios dbRec);
    EscritoriosResponseAll? ReadAll(DBEscritorios dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Escritorios : IEscritoriosReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) escCodigo, escNome FROM {"Escritorios".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}escNome");
        }

        return query.ToString();
    }

    public EscritoriosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEscritorios(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EscritoriosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBEscritorios(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public EscritoriosResponse? Read(Entity.DBEscritorios dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var escritorios = new EscritoriosResponse
        {
            Id = dbRec.ID,
            CNPJ = dbRec.FCNPJ?.MaskCnpj() ?? string.Empty,
            Casa = dbRec.FCasa,
            Parceria = dbRec.FParceria,
            Nome = dbRec.FNome ?? string.Empty,
            OAB = dbRec.FOAB ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Cidade = dbRec.FCidade,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            AdvResponsavel = dbRec.FAdvResponsavel ?? string.Empty,
            Secretaria = dbRec.FSecretaria ?? string.Empty,
            InscEst = dbRec.FInscEst ?? string.Empty,
            Correspondente = dbRec.FCorrespondente,
            Top = dbRec.FTop,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return escritorios;
    }

    public EscritoriosResponse? Read(DBEscritorios dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var escritorios = new EscritoriosResponse
        {
            Id = dbRec.ID,
            CNPJ = dbRec.FCNPJ?.MaskCnpj() ?? string.Empty,
            Casa = dbRec.FCasa,
            Parceria = dbRec.FParceria,
            Nome = dbRec.FNome ?? string.Empty,
            OAB = dbRec.FOAB ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Cidade = dbRec.FCidade,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            AdvResponsavel = dbRec.FAdvResponsavel ?? string.Empty,
            Secretaria = dbRec.FSecretaria ?? string.Empty,
            InscEst = dbRec.FInscEst ?? string.Empty,
            Correspondente = dbRec.FCorrespondente,
            Top = dbRec.FTop,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return escritorios;
    }

    public EscritoriosResponseAll? ReadAll(DBEscritorios dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var escritorios = new EscritoriosResponseAll
        {
            Id = dbRec.ID,
            CNPJ = dbRec.FCNPJ?.MaskCnpj() ?? string.Empty,
            Casa = dbRec.FCasa,
            Parceria = dbRec.FParceria,
            Nome = dbRec.FNome ?? string.Empty,
            OAB = dbRec.FOAB ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Cidade = dbRec.FCidade,
            Bairro = dbRec.FBairro ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            Site = dbRec.FSite ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            AdvResponsavel = dbRec.FAdvResponsavel ?? string.Empty,
            Secretaria = dbRec.FSecretaria ?? string.Empty,
            InscEst = dbRec.FInscEst ?? string.Empty,
            Correspondente = dbRec.FCorrespondente,
            Top = dbRec.FTop,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        escritorios.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return escritorios;
    }
}