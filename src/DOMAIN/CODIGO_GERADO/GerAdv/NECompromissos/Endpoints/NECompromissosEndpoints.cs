#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class NECompromissosEndpoints
{
    public static IEndpointRouteBuilder MapNECompromissosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/NECompromissos").WithTags("NECompromissos").RequireAuthorization();
        MapNECompromissosRoutes(group);
        return app;
    }

    private static void MapNECompromissosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, INECompromissosService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("NECompromissos_GetAll").WithDisplayName("Get All NECompromissos");
        group.MapPost("/Filter", async (Filters.FilterNECompromissos filtro, string uri, INECompromissosService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("NECompromissos_Filter").WithDisplayName("Filter NECompromissos");
        group.MapGet("/GetById/{id}", async (int id, string uri, INECompromissosService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No NECompromissos found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("NECompromissos_GetById").WithDisplayName("Get NECompromissos By Id");
        group.MapPost("/AddAndUpdate", async (Models.NECompromissos regNECompromissos, string uri, INECompromissosValidation validation, INECompromissosWriter writer, ITipoCompromissoReader tipocompromissoReader, INECompromissosService service) =>
        {
            var result = await service.AddAndUpdate(regNECompromissos, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("NECompromissos_AddAndUpdate").WithDisplayName("Add or Update NECompromissos");
        group.MapDelete("/Delete", async (int id, string uri, INECompromissosValidation validation, INECompromissosWriter writer, ITipoCompromissoReader tipocompromissoReader, INECompromissosService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("NECompromissos_Delete").WithDisplayName("Delete NECompromissos");
    }
}