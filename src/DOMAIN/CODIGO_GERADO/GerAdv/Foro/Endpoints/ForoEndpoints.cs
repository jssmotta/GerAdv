#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ForoEndpoints
{
    public static IEndpointRouteBuilder MapForoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Foro").WithTags("Foro").RequireAuthorization();
        MapForoRoutes(group);
        return app;
    }

    private static void MapForoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IForoService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Foro_GetAll").WithDisplayName("Get All Foro");
        group.MapPost("/Filter", async (Filters.FilterForo filtro, string uri, IForoService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Foro_Filter").WithDisplayName("Filter Foro");
        group.MapGet("/GetById/{id}", async (int id, string uri, IForoService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Foro found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Foro_GetById").WithDisplayName("Get Foro By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterForo? filtro, string uri, IForoService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Foro_GetListN").WithDisplayName("Get Foro List N");
        group.MapPost("/AddAndUpdate", async (Models.Foro regForo, string uri, IForoValidation validation, IForoWriter writer, ICidadeReader cidadeReader, IForoService service) =>
        {
            var result = await service.AddAndUpdate(regForo, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Foro_AddAndUpdate").WithDisplayName("Add or Update Foro");
        group.MapDelete("/Delete", async (int id, string uri, IForoValidation validation, IForoWriter writer, ICidadeReader cidadeReader, IForoService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Foro_Delete").WithDisplayName("Delete Foro");
    }
}