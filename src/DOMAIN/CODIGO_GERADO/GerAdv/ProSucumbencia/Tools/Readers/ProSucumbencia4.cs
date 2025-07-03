#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IProSucumbenciaReader
{
    ProSucumbenciaResponse? Read(int id, MsiSqlConnection oCnn);
    ProSucumbenciaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProSucumbenciaResponse? Read(Entity.DBProSucumbencia dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ProSucumbenciaResponse? Read(DBProSucumbencia dbRec);
    ProSucumbenciaResponseAll? ReadAll(DBProSucumbencia dbRec, DataRow dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ProSucumbencia : IProSucumbenciaReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery(cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    static string BuildSqlQuery(string whereClause, string orderClause, int max, MsiSqlConnection? oCnn = null)
    {
        if (max <= 0)
        {
            max = 200;
        }

        var query = new StringBuilder($"SELECT TOP ({max}) scbCodigo, scbNome FROM {"ProSucumbencia".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}scbNome");
        }

        return query.ToString();
    }

    public ProSucumbenciaResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProSucumbencia(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProSucumbenciaResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBProSucumbencia(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ProSucumbenciaResponse? Read(Entity.DBProSucumbencia dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var prosucumbencia = new ProSucumbenciaResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Instancia = dbRec.FInstancia,
            Nome = dbRec.FNome ?? string.Empty,
            TipoOrigemSucumbencia = dbRec.FTipoOrigemSucumbencia,
            Valor = dbRec.FValor,
            Percentual = dbRec.FPercentual ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            prosucumbencia.Data = dbRec.FData;
        return prosucumbencia;
    }

    public ProSucumbenciaResponse? Read(DBProSucumbencia dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var prosucumbencia = new ProSucumbenciaResponse
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Instancia = dbRec.FInstancia,
            Nome = dbRec.FNome ?? string.Empty,
            TipoOrigemSucumbencia = dbRec.FTipoOrigemSucumbencia,
            Valor = dbRec.FValor,
            Percentual = dbRec.FPercentual ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            prosucumbencia.Data = dbRec.FData;
        return prosucumbencia;
    }

    public ProSucumbenciaResponseAll? ReadAll(DBProSucumbencia dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var prosucumbencia = new ProSucumbenciaResponseAll
        {
            Id = dbRec.ID,
            Processo = dbRec.FProcesso,
            Instancia = dbRec.FInstancia,
            Nome = dbRec.FNome ?? string.Empty,
            TipoOrigemSucumbencia = dbRec.FTipoOrigemSucumbencia,
            Valor = dbRec.FValor,
            Percentual = dbRec.FPercentual ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        if (DateTime.TryParse(dbRec.FData, out _))
            prosucumbencia.Data = dbRec.FData;
        prosucumbencia.NroPastaProcessos = dr["proNroPasta"]?.ToString() ?? string.Empty;
        prosucumbencia.NroProcessoInstancia = dr["insNroProcesso"]?.ToString() ?? string.Empty;
        prosucumbencia.NomeTipoOrigemSucumbencia = dr["tosNome"]?.ToString() ?? string.Empty;
        return prosucumbencia;
    }
}