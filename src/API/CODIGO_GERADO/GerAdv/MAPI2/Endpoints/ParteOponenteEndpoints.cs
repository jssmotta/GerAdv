#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ParteOponenteEndpoints
{
    public static IEndpointRouteBuilder MapParteOponenteEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ParteOponente").WithTags("ParteOponente").RequireAuthorization();
        MapParteOponenteRoutes(group);
        return app;
    }

    private static void MapParteOponenteRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapPost("/Filter", async (Filters.FilterParteOponente filtro, string uri, IParteOponenteValidation validation, IOponentesReader oponentesReader, IProcessosReader processosReader, IParteOponenteService service) =>
        {
            logger.Info("ParteOponente: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ParteOponente_Filter").WithDisplayName("Filter ParteOponente");
    }
}