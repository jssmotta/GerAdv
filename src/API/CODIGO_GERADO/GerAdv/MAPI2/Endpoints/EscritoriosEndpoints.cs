#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class EscritoriosEndpoints
{
    public static IEndpointRouteBuilder MapEscritoriosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Escritorios").WithTags("Escritorios").RequireAuthorization();
        MapEscritoriosRoutes(group);
        return app;
    }

    private static void MapEscritoriosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IEscritoriosValidation validation, IEscritoriosWriter writer, IEscritoriosService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Escritorios: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Escritorios_GetAll").WithDisplayName("Get All Escritorios");
        group.MapPost("/Filter", async (Filters.FilterEscritorios filtro, string uri, IEscritoriosValidation validation, IEscritoriosWriter writer, IEscritoriosService service) =>
        {
            logger.Info("Escritorios: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Escritorios_Filter").WithDisplayName("Filter Escritorios");
        group.MapGet("/GetById/{id}", async (int id, string uri, IEscritoriosValidation validation, IEscritoriosWriter writer, IEscritoriosService service, CancellationToken token) =>
        {
            logger.Info("Escritorios: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Escritorios found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Escritorios_GetById").WithDisplayName("Get Escritorios By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IEscritoriosValidation validation, IEscritoriosWriter writer, IEscritoriosService service) =>
        {
            logger.Info("Escritorios: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Escritorios found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Escritorios_GetByName").WithDisplayName("Get Escritorios By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterEscritorios? filtro, string uri, IEscritoriosValidation validation, IEscritoriosWriter writer, IEscritoriosService service) =>
        {
            logger.Info("Escritorios: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Escritorios_GetListN").WithDisplayName("Get Escritorios List N");
        group.MapPost("/AddAndUpdate", async (Models.Escritorios regEscritorios, string uri, IEscritoriosValidation validation, IEscritoriosWriter writer, IEscritoriosService service) =>
        {
            logger.LogInfo("Escritorios", "AddAndUpdate", $"regEscritorios = {regEscritorios}", uri);
            var result = await service.AddAndUpdate(regEscritorios, uri);
            if (result == null)
            {
                logger.LogWarn("Escritorios", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Escritorios_AddAndUpdate").WithDisplayName("Add or Update Escritorios");
        group.MapDelete("/Delete", async (int id, string uri, IEscritoriosValidation validation, IEscritoriosWriter writer, IEscritoriosService service) =>
        {
            logger.LogInfo("Escritorios", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Escritorios", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Escritorios_Delete").WithDisplayName("Delete Escritorios");
    }
}