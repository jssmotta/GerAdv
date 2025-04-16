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
        group.MapGet("/GetAll", async (int max, string uri, IAuditor4KValidation validation, IAuditor4KWriter writer, IAuditor4KService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Auditor4K: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Auditor4K_GetAll").WithDisplayName("Get All Auditor4K");
        group.MapPost("/Filter", async (Filters.FilterAuditor4K filtro, string uri, IAuditor4KValidation validation, IAuditor4KWriter writer, IAuditor4KService service) =>
        {
            logger.Info("Auditor4K: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Auditor4K_Filter").WithDisplayName("Filter Auditor4K");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAuditor4KValidation validation, IAuditor4KWriter writer, IAuditor4KService service, CancellationToken token) =>
        {
            logger.Info("Auditor4K: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Auditor4K found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Auditor4K_GetById").WithDisplayName("Get Auditor4K By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IAuditor4KValidation validation, IAuditor4KWriter writer, IAuditor4KService service) =>
        {
            logger.Info("Auditor4K: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Auditor4K found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Auditor4K_GetByName").WithDisplayName("Get Auditor4K By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterAuditor4K? filtro, string uri, IAuditor4KValidation validation, IAuditor4KWriter writer, IAuditor4KService service) =>
        {
            logger.Info("Auditor4K: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Auditor4K_GetListN").WithDisplayName("Get Auditor4K List N");
        group.MapPost("/AddAndUpdate", async (Models.Auditor4K regAuditor4K, string uri, IAuditor4KValidation validation, IAuditor4KWriter writer, IAuditor4KService service) =>
        {
            logger.LogInfo("Auditor4K", "AddAndUpdate", $"regAuditor4K = {regAuditor4K}", uri);
            var result = await service.AddAndUpdate(regAuditor4K, uri);
            if (result == null)
            {
                logger.LogWarn("Auditor4K", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Auditor4K_AddAndUpdate").WithDisplayName("Add or Update Auditor4K");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IAuditor4KValidation validation, IAuditor4KWriter writer, IAuditor4KService service) =>
        {
            logger.LogInfo("Auditor4K", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("Auditor4K", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Auditor4K_GetColumns").WithDisplayName("Get Auditor4K Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IAuditor4KValidation validation, IAuditor4KWriter writer, IAuditor4KService service) =>
        {
            logger.LogInfo("Auditor4K", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("Auditor4K", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("Auditor4K_UpdateColumns").WithDisplayName("Update Auditor4K Columns");
        group.MapDelete("/Delete", async (int id, string uri, IAuditor4KValidation validation, IAuditor4KWriter writer, IAuditor4KService service) =>
        {
            logger.LogInfo("Auditor4K", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Auditor4K", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Auditor4K_Delete").WithDisplayName("Delete Auditor4K");
    }
}