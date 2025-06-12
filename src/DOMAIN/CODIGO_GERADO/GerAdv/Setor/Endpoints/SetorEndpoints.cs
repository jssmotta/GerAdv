#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class SetorEndpoints
{
    public static IEndpointRouteBuilder MapSetorEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Setor").WithTags("Setor").RequireAuthorization();
        MapSetorRoutes(group);
        return app;
    }

    private static void MapSetorRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ISetorService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Setor_GetAll").WithDisplayName("Get All Setor");
        group.MapPost("/Filter", async (Filters.FilterSetor filtro, string uri, ISetorService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Setor_Filter").WithDisplayName("Filter Setor");
        group.MapGet("/GetById/{id}", async (int id, string uri, ISetorService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Setor found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Setor_GetById").WithDisplayName("Get Setor By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterSetor? filtro, string uri, ISetorService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Setor_GetListN").WithDisplayName("Get Setor List N");
        group.MapPost("/AddAndUpdate", async (Models.Setor regSetor, string uri, ISetorValidation validation, ISetorWriter writer, ISetorService service) =>
        {
            var result = await service.AddAndUpdate(regSetor, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Setor_AddAndUpdate").WithDisplayName("Add or Update Setor");
        group.MapDelete("/Delete", async (int id, string uri, ISetorValidation validation, ISetorWriter writer, ISetorService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Setor_Delete").WithDisplayName("Delete Setor");
    }
}