#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class AgendaRelatorioEndpoints
{
    public static IEndpointRouteBuilder MapAgendaRelatorioEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/AgendaRelatorio").WithTags("AgendaRelatorio").RequireAuthorization();
        MapAgendaRelatorioRoutes(group);
        return app;
    }

    private static void MapAgendaRelatorioRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetById/{id}", async (int id, string uri, IAgendaRelatorioService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No AgendaRelatorio found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AgendaRelatorio_GetById").WithDisplayName("Get AgendaRelatorio By Id");
    }
}