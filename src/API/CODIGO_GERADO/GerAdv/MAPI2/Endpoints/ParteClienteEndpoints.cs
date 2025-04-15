#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ParteClienteEndpoints
{
    public static IEndpointRouteBuilder MapParteClienteEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ParteCliente").WithTags("ParteCliente").RequireAuthorization();
        MapParteClienteRoutes(group);
        return app;
    }

    private static void MapParteClienteRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapPost("/Filter", async (Filters.FilterParteCliente filtro, string uri, IParteClienteValidation validation, IClientesReader clientesReader, IProcessosReader processosReader, IParteClienteService service) =>
        {
            logger.Info("ParteCliente: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ParteCliente_Filter").WithDisplayName("Filter ParteCliente");
    }
}