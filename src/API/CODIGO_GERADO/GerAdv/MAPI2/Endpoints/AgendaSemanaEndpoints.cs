#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class AgendaSemanaEndpoints
{
    public static IEndpointRouteBuilder MapAgendaSemanaEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/AgendaSemana").WithTags("AgendaSemana").RequireAuthorization();
        MapAgendaSemanaRoutes(group);
        return app;
    }

    private static void MapAgendaSemanaRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetById/{id}", async (int id, string uri, IAgendaSemanaValidation validation, IFuncionariosReader funcionariosReader, IAdvogadosReader advogadosReader, ITipoCompromissoReader tipocompromissoReader, IClientesReader clientesReader, IAgendaSemanaService service, CancellationToken token) =>
        {
            logger.Info("AgendaSemana: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No AgendaSemana found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AgendaSemana_GetById").WithDisplayName("Get AgendaSemana By Id");
    }
}