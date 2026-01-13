namespace Domain.BaseCommon.Auditor;

[ExcludeFromCodeCoverage]
public class AuditorService : AuditorServiceBase
{
    private readonly DicionarioDeDadosManagedDatabaseCode _dicManager = new();

    public AuditorService(IHttpContextAccessor httpContextAccessor) 
        : base(httpContextAccessor)
    {
    }

    public override async Task<bool> CheckAuditor(AuditorRequest request, string uri, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        if (request.Id <= 0)
            return false;

        var dicInfo = _dicManager.GlobalObjectDicInfo(request.TableName);
        
        if (dicInfo is null || !dicInfo.HasAuditor())
            return false;

        using var oCnn = await ConfiguracoesSys.GetConnectionByUriRwAsync(uri);

        var sqlUpdate = $"UPDATE {dicInfo.ITabelaNome().dbo(oCnn)} set {dicInfo.IPrefix()}Visto=1 WHERE {dicInfo.IFieldId()}={request.Id};";

        try
        {
            ConfiguracoesDBT.ExecuteSql(sqlUpdate, oCnn);
        }
        catch (Exception ex)
        {
            throw new Exception("Error updating auditor", ex);
        }

        await Task.Delay(1, cancellationToken);
        return true;
    }
}