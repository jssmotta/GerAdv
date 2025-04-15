#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ProBarCODEEndpoints
{
    public static IEndpointRouteBuilder MapProBarCODEEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ProBarCODE").WithTags("ProBarCODE").RequireAuthorization();
        MapProBarCODERoutes(group);
        return app;
    }

    private static void MapProBarCODERoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapPost("/Filter", async (Filters.FilterProBarCODE filtro, string uri, IProBarCODEValidation validation, IProcessosReader processosReader, IProBarCODEService service) =>
        {
            logger.Info("ProBarCODE: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProBarCODE_Filter").WithDisplayName("Filter ProBarCODE");
    }
}