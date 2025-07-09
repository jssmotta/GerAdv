#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv.Readers;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public partial interface IDivisaoTribunalReader
{
    DivisaoTribunalResponse? Read(int id, MsiSqlConnection oCnn);
    DivisaoTribunalResponse? Read(Entity.DBDivisaoTribunal dbRec, MsiSqlConnection oCnn);
    DivisaoTribunalResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    DivisaoTribunalResponse? Read(Entity.DBDivisaoTribunal dbRec);
    Task<string> ReadStringAuditor(int id, string uri, MsiSqlConnection oCnn);
    Task<string> ReadStringAuditor(string uri, string cWhere, List<SqlParameter> parameters, MsiSqlConnection oCnn);
    DivisaoTribunalResponse? Read(DBDivisaoTribunal dbRec);
    DivisaoTribunalResponseAll? ReadAll(DBDivisaoTribunal dbRec, DataRow dr);
    DivisaoTribunalResponseAll? ReadAll(DBDivisaoTribunal dbRec, SqlDataReader dr);
    IEnumerable<DivisaoTribunalResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order);
}

public partial class DivisaoTribunal : IDivisaoTribunalReader
{
    public IEnumerable<DivisaoTribunalResponseAll> Listar(int max, string uri, string cWhere, List<SqlParameter> parameters, string order) => ListarTabela(BuildSqlQuery("*", cWhere, order, max), parameters, uri, caching: DevourerOne.PCachingDefault, max: max);
    private IEnumerable<DivisaoTribunalResponseAll> ListarTabela(string sql, List<SqlParameter> parameters, string uri, bool caching = DevourerOne.PCachingDefault, int max = 200)
    {
        using var oCnn = new MsiSqlConnection(uri);
        return ReadLocalAsync().Result;
        async Task<List<DivisaoTribunalResponseAll>> ReadLocalAsync()
        {
            var result = new List<DivisaoTribunalResponseAll>(max);
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
                result.Add(ReadAll(new Entity.DBDivisaoTribunal(reader), reader)!);
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

        var query = new StringBuilder($"SELECT TOP ({max}) {campos}  FROM {"DivisaoTribunal".dbo(oCnn)} (NOLOCK) ");
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
            query.Append($"{TSql.OrderBy}");
        }

        return query.ToString();
    }

    public DivisaoTribunalResponse? Read(int id, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBDivisaoTribunal(id, oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public DivisaoTribunalResponse? Read(Entity.DBDivisaoTribunal dbRec, MsiSqlConnection oCnn)
    {
        return Read(dbRec);
    }

    public DivisaoTribunalResponse? Read(string where, List<SqlParameter> parameters, MsiSqlConnection oCnn)
    {
        using var dbRec = new Entity.DBDivisaoTribunal(sqlWhere: where, parameters: parameters, oCnn: oCnn);
        return dbRec.ID.IsEmptyIDNumber() ? null : Read(dbRec);
    }

    public DivisaoTribunalResponse? Read(Entity.DBDivisaoTribunal dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var divisaotribunal = new DivisaoTribunalResponse
        {
            Id = dbRec.ID,
            NumCodigo = dbRec.FNumCodigo,
            Justica = dbRec.FJustica,
            NomeEspecial = dbRec.FNomeEspecial ?? string.Empty,
            Area = dbRec.FArea,
            Cidade = dbRec.FCidade,
            Foro = dbRec.FForo,
            Tribunal = dbRec.FTribunal,
            CodigoDiv = dbRec.FCodigoDiv ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Obs = dbRec.FObs ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Andar = dbRec.FAndar ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return divisaotribunal;
    }

    public DivisaoTribunalResponse? Read(DBDivisaoTribunal dbRec)
    {
        if (dbRec == null)
        {
            return null;
        }

        var divisaotribunal = new DivisaoTribunalResponse
        {
            Id = dbRec.ID,
            NumCodigo = dbRec.FNumCodigo,
            Justica = dbRec.FJustica,
            NomeEspecial = dbRec.FNomeEspecial ?? string.Empty,
            Area = dbRec.FArea,
            Cidade = dbRec.FCidade,
            Foro = dbRec.FForo,
            Tribunal = dbRec.FTribunal,
            CodigoDiv = dbRec.FCodigoDiv ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Obs = dbRec.FObs ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Andar = dbRec.FAndar ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        return divisaotribunal;
    }

    public DivisaoTribunalResponseAll? ReadAll(DBDivisaoTribunal dbRec, DataRow dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var divisaotribunal = new DivisaoTribunalResponseAll
        {
            Id = dbRec.ID,
            NumCodigo = dbRec.FNumCodigo,
            Justica = dbRec.FJustica,
            NomeEspecial = dbRec.FNomeEspecial ?? string.Empty,
            Area = dbRec.FArea,
            Cidade = dbRec.FCidade,
            Foro = dbRec.FForo,
            Tribunal = dbRec.FTribunal,
            CodigoDiv = dbRec.FCodigoDiv ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Obs = dbRec.FObs ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Andar = dbRec.FAndar ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        divisaotribunal.NomeJustica = dr["jusNome"]?.ToString() ?? string.Empty;
        divisaotribunal.DescricaoArea = dr["areDescricao"]?.ToString() ?? string.Empty;
        divisaotribunal.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        divisaotribunal.NomeForo = dr["forNome"]?.ToString() ?? string.Empty;
        divisaotribunal.NomeTribunal = dr["triNome"]?.ToString() ?? string.Empty;
        return divisaotribunal;
    }

    public DivisaoTribunalResponseAll? ReadAll(DBDivisaoTribunal dbRec, SqlDataReader dr)
    {
        if (dbRec == null)
        {
            return null;
        }

        var divisaotribunal = new DivisaoTribunalResponseAll
        {
            Id = dbRec.ID,
            NumCodigo = dbRec.FNumCodigo,
            Justica = dbRec.FJustica,
            NomeEspecial = dbRec.FNomeEspecial ?? string.Empty,
            Area = dbRec.FArea,
            Cidade = dbRec.FCidade,
            Foro = dbRec.FForo,
            Tribunal = dbRec.FTribunal,
            CodigoDiv = dbRec.FCodigoDiv ?? string.Empty,
            Endereco = dbRec.FEndereco ?? string.Empty,
            Fone = dbRec.FFone ?? string.Empty,
            Fax = dbRec.FFax ?? string.Empty,
            CEP = dbRec.FCEP?.MaskCep() ?? string.Empty,
            Obs = dbRec.FObs ?? string.Empty,
            EMail = dbRec.FEMail ?? string.Empty,
            Andar = dbRec.FAndar ?? string.Empty,
            Etiqueta = dbRec.FEtiqueta,
            Bold = dbRec.FBold,
            GUID = dbRec.FGUID ?? string.Empty,
        };
        divisaotribunal.NomeJustica = dr["jusNome"]?.ToString() ?? string.Empty;
        divisaotribunal.DescricaoArea = dr["areDescricao"]?.ToString() ?? string.Empty;
        divisaotribunal.NomeCidade = dr["cidNome"]?.ToString() ?? string.Empty;
        divisaotribunal.NomeForo = dr["forNome"]?.ToString() ?? string.Empty;
        divisaotribunal.NomeTribunal = dr["triNome"]?.ToString() ?? string.Empty;
        return divisaotribunal;
    }
}