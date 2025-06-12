#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ProValoresEndpoints
{
    public static IEndpointRouteBuilder MapProValoresEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ProValores").WithTags("ProValores").RequireAuthorization();
        MapProValoresRoutes(group);
        return app;
    }

    private static void MapProValoresRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IProValoresService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProValores_GetAll").WithDisplayName("Get All ProValores");
        group.MapPost("/Filter", async (Filters.FilterProValores filtro, string uri, IProValoresService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProValores_Filter").WithDisplayName("Filter ProValores");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProValoresService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ProValores found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProValores_GetById").WithDisplayName("Get ProValores By Id");
        group.MapPost("/AddAndUpdate", async (Models.ProValores regProValores, string uri, IProValoresValidation validation, IProValoresWriter writer, IProcessosReader processosReader, ITipoValorProcessoReader tipovalorprocessoReader, IProValoresService service) =>
        {
            var result = await service.AddAndUpdate(regProValores, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProValores_AddAndUpdate").WithDisplayName("Add or Update ProValores");
        group.MapDelete("/Delete", async (int id, string uri, IProValoresValidation validation, IProValoresWriter writer, IProcessosReader processosReader, ITipoValorProcessoReader tipovalorprocessoReader, IProValoresService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProValores_Delete").WithDisplayName("Delete ProValores");
    }
}