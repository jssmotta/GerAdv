#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IForoReader
{
    ForoResponse? Read(int id, MsiSqlConnection oCnn);
    ForoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ForoResponse? Read(Entity.DBForo dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ForoResponse? Read(DBForo dbRec);
    ForoResponseAll? ReadAll(DBForo dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class Foro : IForoReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max = 200, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) forCodigo, forNome FROM {"Foro".dbo(oCnn)} (NOLOCK) ");
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

    public ForoResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBForo(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ForoResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBForo(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ForoResponse? Read(Entity.DBForo dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var foro = new ForoResponse
        {
            Id = dbRec.ID,
            EMail = dbRec.FEMail ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Unico = dbRec.FUnico,
            Cidade = dbRec.FCidade,
            Site = dbRec.FSite ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            UnicoConfirmado = dbRec.FUnicoConfirmado,
            Web = dbRec.FWeb ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
        };
        return foro;
    }

    public ForoResponse? Read(DBForo dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var foro = new ForoResponse
        {
            Id = dbRec.ID,
            EMail = dbRec.FEMail ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Unico = dbRec.FUnico,
            Cidade = dbRec.FCidade,
            Site = dbRec.FSite ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            UnicoConfirmado = dbRec.FUnicoConfirmado,
            Web = dbRec.FWeb ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
        };
        return foro;
    }

    public ForoResponseAll? ReadAll(DBForo dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var foro = new ForoResponseAll
        {
            Id = dbRec.ID,
            EMail = dbRec.FEMail ?? string.Empty,
            Nome = dbRec.FNome ?? string.Empty,
            Unico = dbRec.FUnico,
            Cidade = dbRec.FCidade,
            Site = dbRec.FSite ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Bairro = dbRec.FBairro ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            OBS = dbRec.FOBS ?? string.Empty,
            UnicoConfirmado = dbRec.FUnicoConfirmado,
            Web = dbRec.FWeb ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
        };
        foro.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        return foro;
    }
}