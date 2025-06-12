#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class CargosEndpoints
{
    public static IEndpointRouteBuilder MapCargosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Cargos").WithTags("Cargos").RequireAuthorization();
        MapCargosRoutes(group);
        return app;
    }

    private static void MapCargosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ICargosService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Cargos_GetAll").WithDisplayName("Get All Cargos");
        group.MapPost("/Filter", async (Filters.FilterCargos filtro, string uri, ICargosService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Cargos_Filter").WithDisplayName("Filter Cargos");
        group.MapGet("/GetById/{id}", async (int id, string uri, ICargosService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Cargos found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Cargos_GetById").WithDisplayName("Get Cargos By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterCargos? filtro, string uri, ICargosService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Cargos_GetListN").WithDisplayName("Get Cargos List N");
        group.MapPost("/AddAndUpdate", async (Models.Cargos regCargos, string uri, ICargosValidation validation, ICargosWriter writer, ICargosService service) =>
        {
            var result = await service.AddAndUpdate(regCargos, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Cargos_AddAndUpdate").WithDisplayName("Add or Update Cargos");
        group.MapDelete("/Delete", async (int id, string uri, ICargosValidation validation, ICargosWriter writer, ICargosService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Cargos_Delete").WithDisplayName("Delete Cargos");
    }
}