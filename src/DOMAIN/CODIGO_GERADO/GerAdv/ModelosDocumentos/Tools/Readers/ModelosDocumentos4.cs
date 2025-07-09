#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IModelosDocumentosReader
{
    ModelosDocumentosResponse? Read(int id, MsiSqlConnection oCnn);
    ModelosDocumentosResponse? Read(Entity.DBModelosDocumentos dbRec, MsiSqlConnection oCnn);
    ModelosDocumentosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ModelosDocumentosResponse? Read(Entity.DBModelosDocumentos dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    ModelosDocumentosResponse? Read(DBModelosDocumentos dbRec);
    ModelosDocumentosResponseAll? ReadAll(DBModelosDocumentos dbRec, DataRow dr);
    ModelosDocumentosResponseAll? ReadAll(DBModelosDocumentos dbRec, SqlDataReader dr);
    IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
    IEnumerable<ModelosDocumentosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class ModelosDocumentos : IModelosDocumentosReader
{
    public IEnumerable<DBNomeID> ListarN(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => DevourerSqlData.ListarNomeID(BuildSqlQuery("{mdcCodigo, mdcNome}", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    public IEnumerable<ModelosDocumentosResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<ModelosDocumentosResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<ModelosDocumentosResponseAll>> ReadLocalAsync()
        {
            var result = new List<ModelosDocumentosResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBModelosDocumentos(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"ModelosDocumentos".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}mdcNome");
        }

        return query.ToString();
    }

    public ModelosDocumentosResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBModelosDocumentos(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ModelosDocumentosResponse? Read(Entity.DBModelosDocumentos dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public ModelosDocumentosResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBModelosDocumentos(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public ModelosDocumentosResponse? Read(Entity.DBModelosDocumentos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var modelosdocumentos = new ModelosDocumentosResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Remuneracao = dbRec.FRemuneracao ?? string.Empty,
            Assinatura = dbRec.FAssinatura ?? string.Empty,
            Header = dbRec.FHeader ?? string.Empty,
            Footer = dbRec.FFooter ?? string.Empty,
            Extra1 = dbRec.FExtra1 ?? string.Empty,
            Extra2 = dbRec.FExtra2 ?? string.Empty,
            Extra3 = dbRec.FExtra3 ?? string.Empty,
            Outorgante = dbRec.FOutorgante ?? string.Empty,
            Outorgados = dbRec.FOutorgados ?? string.Empty,
            Poderes = dbRec.FPoderes ?? string.Empty,
            Objeto = dbRec.FObjeto ?? string.Empty,
            Titulo = dbRec.FTitulo ?? string.Empty,
            Testemunhas = dbRec.FTestemunhas ?? string.Empty,
            TipoModeloDocumento = dbRec.FTipoModeloDocumento,
            CSS = dbRec.FCSS ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return modelosdocumentos;
    }

    public ModelosDocumentosResponse? Read(DBModelosDocumentos dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var modelosdocumentos = new ModelosDocumentosResponse
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Remuneracao = dbRec.FRemuneracao ?? string.Empty,
            Assinatura = dbRec.FAssinatura ?? string.Empty,
            Header = dbRec.FHeader ?? string.Empty,
            Footer = dbRec.FFooter ?? string.Empty,
            Extra1 = dbRec.FExtra1 ?? string.Empty,
            Extra2 = dbRec.FExtra2 ?? string.Empty,
            Extra3 = dbRec.FExtra3 ?? string.Empty,
            Outorgante = dbRec.FOutorgante ?? string.Empty,
            Outorgados = dbRec.FOutorgados ?? string.Empty,
            Poderes = dbRec.FPoderes ?? string.Empty,
            Objeto = dbRec.FObjeto ?? string.Empty,
            Titulo = dbRec.FTitulo ?? string.Empty,
            Testemunhas = dbRec.FTestemunhas ?? string.Empty,
            TipoModeloDocumento = dbRec.FTipoModeloDocumento,
            CSS = dbRec.FCSS ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return modelosdocumentos;
    }

    public ModelosDocumentosResponseAll? ReadAll(DBModelosDocumentos dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var modelosdocumentos = new ModelosDocumentosResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Remuneracao = dbRec.FRemuneracao ?? string.Empty,
            Assinatura = dbRec.FAssinatura ?? string.Empty,
            Header = dbRec.FHeader ?? string.Empty,
            Footer = dbRec.FFooter ?? string.Empty,
            Extra1 = dbRec.FExtra1 ?? string.Empty,
            Extra2 = dbRec.FExtra2 ?? string.Empty,
            Extra3 = dbRec.FExtra3 ?? string.Empty,
            Outorgante = dbRec.FOutorgante ?? string.Empty,
            Outorgados = dbRec.FOutorgados ?? string.Empty,
            Poderes = dbRec.FPoderes ?? string.Empty,
            Objeto = dbRec.FObjeto ?? string.Empty,
            Titulo = dbRec.FTitulo ?? string.Empty,
            Testemunhas = dbRec.FTestemunhas ?? string.Empty,
            TipoModeloDocumento = dbRec.FTipoModeloDocumento,
            CSS = dbRec.FCSS ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        modelosdocumentos.NomeTipoModeloDocumento = dr["tpdNome"]?.ToString() ?? string.Empty;
        return modelosdocumentos;
    }

    public ModelosDocumentosResponseAll? ReadAll(DBModelosDocumentos dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var modelosdocumentos = new ModelosDocumentosResponseAll
        {
            Id = dbRec.ID,
            Nome = dbRec.FNome ?? string.Empty,
            Remuneracao = dbRec.FRemuneracao ?? string.Empty,
            Assinatura = dbRec.FAssinatura ?? string.Empty,
            Header = dbRec.FHeader ?? string.Empty,
            Footer = dbRec.FFooter ?? string.Empty,
            Extra1 = dbRec.FExtra1 ?? string.Empty,
            Extra2 = dbRec.FExtra2 ?? string.Empty,
            Extra3 = dbRec.FExtra3 ?? string.Empty,
            Outorgante = dbRec.FOutorgante ?? string.Empty,
            Outorgados = dbRec.FOutorgados ?? string.Empty,
            Poderes = dbRec.FPoderes ?? string.Empty,
            Objeto = dbRec.FObjeto ?? string.Empty,
            Titulo = dbRec.FTitulo ?? string.Empty,
            Testemunhas = dbRec.FTestemunhas ?? string.Empty,
            TipoModeloDocumento = dbRec.FTipoModeloDocumento,
            CSS = dbRec.FCSS ?? string.Empty,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        modelosdocumentos.NomeTipoModeloDocumento = dr["tpdNome"]?.ToString() ?? string.Empty;
        return modelosdocumentos;
    }
}