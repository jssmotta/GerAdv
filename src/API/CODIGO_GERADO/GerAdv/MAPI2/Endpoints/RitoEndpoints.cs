#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class RitoEndpoints
{
    public static IEndpointRouteBuilder MapRitoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Rito").WithTags("Rito").RequireAuthorization();
        MapRitoRoutes(group);
        return app;
    }

    private static void MapRitoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IRitoValidation validation, IRitoWriter writer, IRitoService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Rito: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Rito_GetAll").WithDisplayName("Get All Rito");
        group.MapPost("/Filter", async (Filters.FilterRito filtro, string uri, IRitoValidation validation, IRitoWriter writer, IRitoService service) =>
        {
            logger.Info("Rito: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Rito_Filter").WithDisplayName("Filter Rito");
        group.MapGet("/GetById/{id}", async (int id, string uri, IRitoValidation validation, IRitoWriter writer, IRitoService service, CancellationToken token) =>
        {
            logger.Info("Rito: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Rito found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Rito_GetById").WithDisplayName("Get Rito By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IRitoValidation validation, IRitoWriter writer, IRitoService service) =>
        {
            logger.Info("Rito: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Rito found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Rito_GetByName").WithDisplayName("Get Rito By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterRito? filtro, string uri, IRitoValidation validation, IRitoWriter writer, IRitoService service) =>
        {
            logger.Info("Rito: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Rito_GetListN").WithDisplayName("Get Rito List N");
        group.MapPost("/AddAndUpdate", async (Models.Rito regRito, string uri, IRitoValidation validation, IRitoWriter writer, IRitoService service) =>
        {
            logger.LogInfo("Rito", "AddAndUpdate", $"regRito = {regRito}", uri);
            var result = await service.AddAndUpdate(regRito, uri);
            if (result == null)
            {
                logger.LogWarn("Rito", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Rito_AddAndUpdate").WithDisplayName("Add or Update Rito");
        group.MapDelete("/Delete", async (int id, string uri, IRitoValidation validation, IRitoWriter writer, IRitoService service) =>
        {
            logger.LogInfo("Rito", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Rito", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Rito_Delete").WithDisplayName("Delete Rito");
    }
}