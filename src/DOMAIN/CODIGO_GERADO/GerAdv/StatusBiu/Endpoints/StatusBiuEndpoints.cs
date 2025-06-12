#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class StatusBiuEndpoints
{
    public static IEndpointRouteBuilder MapStatusBiuEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/StatusBiu").WithTags("StatusBiu").RequireAuthorization();
        MapStatusBiuRoutes(group);
        return app;
    }

    private static void MapStatusBiuRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IStatusBiuService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("StatusBiu_GetAll").WithDisplayName("Get All StatusBiu");
        group.MapPost("/Filter", async (Filters.FilterStatusBiu filtro, string uri, IStatusBiuService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("StatusBiu_Filter").WithDisplayName("Filter StatusBiu");
        group.MapGet("/GetById/{id}", async (int id, string uri, IStatusBiuService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No StatusBiu found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("StatusBiu_GetById").WithDisplayName("Get StatusBiu By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterStatusBiu? filtro, string uri, IStatusBiuService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("StatusBiu_GetListN").WithDisplayName("Get StatusBiu List N");
        group.MapPost("/AddAndUpdate", async (Models.StatusBiu regStatusBiu, string uri, IStatusBiuValidation validation, IStatusBiuWriter writer, ITipoStatusBiuReader tipostatusbiuReader, IOperadorReader operadorReader, IStatusBiuService service) =>
        {
            var result = await service.AddAndUpdate(regStatusBiu, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("StatusBiu_AddAndUpdate").WithDisplayName("Add or Update StatusBiu");
        group.MapDelete("/Delete", async (int id, string uri, IStatusBiuValidation validation, IStatusBiuWriter writer, ITipoStatusBiuReader tipostatusbiuReader, IOperadorReader operadorReader, IStatusBiuService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("StatusBiu_Delete").WithDisplayName("Delete StatusBiu");
    }
}