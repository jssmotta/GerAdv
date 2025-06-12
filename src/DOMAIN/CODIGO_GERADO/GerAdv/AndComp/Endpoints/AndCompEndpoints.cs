#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class AndCompEndpoints
{
    public static IEndpointRouteBuilder MapAndCompEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/AndComp").WithTags("AndComp").RequireAuthorization();
        MapAndCompRoutes(group);
        return app;
    }

    private static void MapAndCompRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IAndCompService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("AndComp_GetAll").WithDisplayName("Get All AndComp");
        group.MapPost("/Filter", async (Filters.FilterAndComp filtro, string uri, IAndCompService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("AndComp_Filter").WithDisplayName("Filter AndComp");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAndCompService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No AndComp found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AndComp_GetById").WithDisplayName("Get AndComp By Id");
        group.MapPost("/AddAndUpdate", async (Models.AndComp regAndComp, string uri, IAndCompValidation validation, IAndCompWriter writer, IAndCompService service) =>
        {
            var result = await service.AddAndUpdate(regAndComp, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("AndComp_AddAndUpdate").WithDisplayName("Add or Update AndComp");
        group.MapDelete("/Delete", async (int id, string uri, IAndCompValidation validation, IAndCompWriter writer, IAndCompService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AndComp_Delete").WithDisplayName("Delete AndComp");
    }
}