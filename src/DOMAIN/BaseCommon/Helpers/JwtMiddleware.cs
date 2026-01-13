/// <summary>
/// JwtMiddleware específico.
/// Herda do JwtMiddleware genérico do Shared.
/// </summary>
public class JwtMiddlewareAppSG : JwtMiddleware<OperadorResponse>
{
    private readonly AppSettings _appSettings;

    public JwtMiddlewareAppSG(RequestDelegate next, IOptions<AppSettings> appSettings)
        : base(next, appSettings)
    {
        _appSettings = appSettings.Value;
    }

    /// <summary>
    /// URI padrão
    /// </summary>
    protected override string DefaultUri => _appSettings.DemoURI;
}