#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class OperadorGruposEndpoints
{
    public static IEndpointRouteBuilder MapOperadorGruposEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/OperadorGrupos").WithTags("OperadorGrupos").RequireAuthorization();
        MapOperadorGruposRoutes(group);
        return app;
    }

    private static void MapOperadorGruposRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IOperadorGruposService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("OperadorGrupos_GetAll").WithDisplayName("Get All OperadorGrupos");
        group.MapPost("/Filter", async (Filters.FilterOperadorGrupos filtro, string uri, IOperadorGruposService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("OperadorGrupos_Filter").WithDisplayName("Filter OperadorGrupos");
        group.MapGet("/GetById/{id}", async (int id, string uri, IOperadorGruposService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No OperadorGrupos found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OperadorGrupos_GetById").WithDisplayName("Get OperadorGrupos By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterOperadorGrupos? filtro, string uri, IOperadorGruposService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("OperadorGrupos_GetListN").WithDisplayName("Get OperadorGrupos List N");
        group.MapPost("/AddAndUpdate", async (Models.OperadorGrupos regOperadorGrupos, string uri, IOperadorGruposValidation validation, IOperadorGruposWriter writer, IOperadorGruposService service) =>
        {
            var result = await service.AddAndUpdate(regOperadorGrupos, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("OperadorGrupos_AddAndUpdate").WithDisplayName("Add or Update OperadorGrupos");
        group.MapDelete("/Delete", async (int id, string uri, IOperadorGruposValidation validation, IOperadorGruposWriter writer, IOperadorGruposService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OperadorGrupos_Delete").WithDisplayName("Delete OperadorGrupos");
    }
}