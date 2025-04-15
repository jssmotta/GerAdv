#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class AreaEndpoints
{
    public static IEndpointRouteBuilder MapAreaEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Area").WithTags("Area").RequireAuthorization();
        MapAreaRoutes(group);
        return app;
    }

    private static void MapAreaRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IAreaValidation validation, IAreaWriter writer, IAreaService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Area: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Area_GetAll").WithDisplayName("Get All Area");
        group.MapPost("/Filter", async (Filters.FilterArea filtro, string uri, IAreaValidation validation, IAreaWriter writer, IAreaService service) =>
        {
            logger.Info("Area: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Area_Filter").WithDisplayName("Filter Area");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAreaValidation validation, IAreaWriter writer, IAreaService service, CancellationToken token) =>
        {
            logger.Info("Area: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Area found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Area_GetById").WithDisplayName("Get Area By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IAreaValidation validation, IAreaWriter writer, IAreaService service) =>
        {
            logger.Info("Area: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Area found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Area_GetByName").WithDisplayName("Get Area By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterArea? filtro, string uri, IAreaValidation validation, IAreaWriter writer, IAreaService service) =>
        {
            logger.Info("Area: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Area_GetListN").WithDisplayName("Get Area List N");
        group.MapPost("/AddAndUpdate", async (Models.Area regArea, string uri, IAreaValidation validation, IAreaWriter writer, IAreaService service) =>
        {
            logger.LogInfo("Area", "AddAndUpdate", $"regArea = {regArea}", uri);
            var result = await service.AddAndUpdate(regArea, uri);
            if (result == null)
            {
                logger.LogWarn("Area", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Area_AddAndUpdate").WithDisplayName("Add or Update Area");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IAreaValidation validation, IAreaWriter writer, IAreaService service) =>
        {
            logger.LogInfo("Area", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("Area", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Area_GetColumns").WithDisplayName("Get Area Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IAreaValidation validation, IAreaWriter writer, IAreaService service) =>
        {
            logger.LogInfo("Area", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("Area", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("Area_UpdateColumns").WithDisplayName("Update Area Columns");
        group.MapDelete("/Delete", async (int id, string uri, IAreaValidation validation, IAreaWriter writer, IAreaService service) =>
        {
            logger.LogInfo("Area", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Area", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Area_Delete").WithDisplayName("Delete Area");
    }
}