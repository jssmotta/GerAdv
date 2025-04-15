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
        group.MapGet("/GetAll", async (int max, string uri, IAndCompValidation validation, IAndCompWriter writer, IAndCompService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("AndComp: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("AndComp_GetAll").WithDisplayName("Get All AndComp");
        group.MapPost("/Filter", async (Filters.FilterAndComp filtro, string uri, IAndCompValidation validation, IAndCompWriter writer, IAndCompService service) =>
        {
            logger.Info("AndComp: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("AndComp_Filter").WithDisplayName("Filter AndComp");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAndCompValidation validation, IAndCompWriter writer, IAndCompService service, CancellationToken token) =>
        {
            logger.Info("AndComp: GetById called with id = {0}, {1}", id, uri);
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
            logger.LogInfo("AndComp", "AddAndUpdate", $"regAndComp = {regAndComp}", uri);
            var result = await service.AddAndUpdate(regAndComp, uri);
            if (result == null)
            {
                logger.LogWarn("AndComp", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("AndComp_AddAndUpdate").WithDisplayName("Add or Update AndComp");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IAndCompValidation validation, IAndCompWriter writer, IAndCompService service) =>
        {
            logger.LogInfo("AndComp", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("AndComp", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AndComp_GetColumns").WithDisplayName("Get AndComp Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IAndCompValidation validation, IAndCompWriter writer, IAndCompService service) =>
        {
            logger.LogInfo("AndComp", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("AndComp", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("AndComp_UpdateColumns").WithDisplayName("Update AndComp Columns");
        group.MapDelete("/Delete", async (int id, string uri, IAndCompValidation validation, IAndCompWriter writer, IAndCompService service) =>
        {
            logger.LogInfo("AndComp", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("AndComp", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AndComp_Delete").WithDisplayName("Delete AndComp");
    }
}