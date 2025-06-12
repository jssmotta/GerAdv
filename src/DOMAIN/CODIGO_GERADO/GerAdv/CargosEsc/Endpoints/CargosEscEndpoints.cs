#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class CargosEscEndpoints
{
    public static IEndpointRouteBuilder MapCargosEscEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/CargosEsc").WithTags("CargosEsc").RequireAuthorization();
        MapCargosEscRoutes(group);
        return app;
    }

    private static void MapCargosEscRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ICargosEscService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("CargosEsc_GetAll").WithDisplayName("Get All CargosEsc");
        group.MapPost("/Filter", async (Filters.FilterCargosEsc filtro, string uri, ICargosEscService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("CargosEsc_Filter").WithDisplayName("Filter CargosEsc");
        group.MapGet("/GetById/{id}", async (int id, string uri, ICargosEscService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No CargosEsc found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("CargosEsc_GetById").WithDisplayName("Get CargosEsc By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterCargosEsc? filtro, string uri, ICargosEscService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("CargosEsc_GetListN").WithDisplayName("Get CargosEsc List N");
        group.MapPost("/AddAndUpdate", async (Models.CargosEsc regCargosEsc, string uri, ICargosEscValidation validation, ICargosEscWriter writer, ICargosEscService service) =>
        {
            var result = await service.AddAndUpdate(regCargosEsc, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("CargosEsc_AddAndUpdate").WithDisplayName("Add or Update CargosEsc");
        group.MapDelete("/Delete", async (int id, string uri, ICargosEscValidation validation, ICargosEscWriter writer, ICargosEscService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("CargosEsc_Delete").WithDisplayName("Delete CargosEsc");
    }
}