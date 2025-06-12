#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class Auditor4KEndpoints
{
    public static IEndpointRouteBuilder MapAuditor4KEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Auditor4K").WithTags("Auditor4K").RequireAuthorization();
        MapAuditor4KRoutes(group);
        return app;
    }

    private static void MapAuditor4KRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IAuditor4KService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Auditor4K_GetAll").WithDisplayName("Get All Auditor4K");
        group.MapPost("/Filter", async (Filters.FilterAuditor4K filtro, string uri, IAuditor4KService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Auditor4K_Filter").WithDisplayName("Filter Auditor4K");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAuditor4KService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Auditor4K found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Auditor4K_GetById").WithDisplayName("Get Auditor4K By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterAuditor4K? filtro, string uri, IAuditor4KService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Auditor4K_GetListN").WithDisplayName("Get Auditor4K List N");
        group.MapPost("/AddAndUpdate", async (Models.Auditor4K regAuditor4K, string uri, IAuditor4KValidation validation, IAuditor4KWriter writer, IAuditor4KService service) =>
        {
            var result = await service.AddAndUpdate(regAuditor4K, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Auditor4K_AddAndUpdate").WithDisplayName("Add or Update Auditor4K");
        group.MapDelete("/Delete", async (int id, string uri, IAuditor4KValidation validation, IAuditor4KWriter writer, IAuditor4KService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Auditor4K_Delete").WithDisplayName("Delete Auditor4K");
    }
}