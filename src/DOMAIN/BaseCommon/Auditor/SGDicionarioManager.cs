namespace Domain.BaseCommon.Auditor;

/// <summary>
/// Implementação do gerenciador de dicionário de dados para AppSG.
/// </summary>
[ExcludeFromCodeCoverage]
public class SGDicionarioManager : IDicionarioDeDadosManager
{
    private readonly DicionarioDeDadosManagedDatabaseCode _dicManager = new();

    public string? GetTableName(string? entityNameOrId)
    {
        var dicInfo = _dicManager.GlobalObjectDicInfo(entityNameOrId);
        return dicInfo?.ITabelaNome();
    }

    public bool HasAuditor(string? entityNameOrId)
    {
        var dicInfo = _dicManager.GlobalObjectDicInfo(entityNameOrId);
        return dicInfo?.HasAuditor() ?? false;
    }
}
