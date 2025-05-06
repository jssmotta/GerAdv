#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class RamalEndpoints
{
    public static IEndpointRouteBuilder MapRamalEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Ramal").WithTags("Ramal").RequireAuthorization();
        MapRamalRoutes(group);
        return app;
    }

    private static void MapRamalRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IRamalValidation validation, IRamalWriter writer, IRamalService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Ramal: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Ramal_GetAll").WithDisplayName("Get All Ramal");
        group.MapPost("/Filter", async (Filters.FilterRamal filtro, string uri, IRamalValidation validation, IRamalWriter writer, IRamalService service) =>
        {
            logger.Info("Ramal: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Ramal_Filter").WithDisplayName("Filter Ramal");
        group.MapGet("/GetById/{id}", async (int id, string uri, IRamalValidation validation, IRamalWriter writer, IRamalService service, CancellationToken token) =>
        {
            logger.Info("Ramal: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Ramal found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Ramal_GetById").WithDisplayName("Get Ramal By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IRamalValidation validation, IRamalWriter writer, IRamalService service) =>
        {
            logger.Info("Ramal: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Ramal found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Ramal_GetByName").WithDisplayName("Get Ramal By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterRamal? filtro, string uri, IRamalValidation validation, IRamalWriter writer, IRamalService service) =>
        {
            logger.Info("Ramal: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Ramal_GetListN").WithDisplayName("Get Ramal List N");
        group.MapPost("/AddAndUpdate", async (Models.Ramal regRamal, string uri, IRamalValidation validation, IRamalWriter writer, IRamalService service) =>
        {
            logger.LogInfo("Ramal", "AddAndUpdate", $"regRamal = {regRamal}", uri);
            var result = await service.AddAndUpdate(regRamal, uri);
            if (result == null)
            {
                logger.LogWarn("Ramal", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Ramal_AddAndUpdate").WithDisplayName("Add or Update Ramal");
        group.MapDelete("/Delete", async (int id, string uri, IRamalValidation validation, IRamalWriter writer, IRamalService service) =>
        {
            logger.LogInfo("Ramal", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Ramal", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Ramal_Delete").WithDisplayName("Delete Ramal");
    }
}