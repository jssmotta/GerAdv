#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class NEPalavrasChavesEndpoints
{
    public static IEndpointRouteBuilder MapNEPalavrasChavesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/NEPalavrasChaves").WithTags("NEPalavrasChaves").RequireAuthorization();
        MapNEPalavrasChavesRoutes(group);
        return app;
    }

    private static void MapNEPalavrasChavesRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, INEPalavrasChavesValidation validation, INEPalavrasChavesWriter writer, INEPalavrasChavesService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("NEPalavrasChaves: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("NEPalavrasChaves_GetAll").WithDisplayName("Get All NEPalavrasChaves");
        group.MapPost("/Filter", async (Filters.FilterNEPalavrasChaves filtro, string uri, INEPalavrasChavesValidation validation, INEPalavrasChavesWriter writer, INEPalavrasChavesService service) =>
        {
            logger.Info("NEPalavrasChaves: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("NEPalavrasChaves_Filter").WithDisplayName("Filter NEPalavrasChaves");
        group.MapGet("/GetById/{id}", async (int id, string uri, INEPalavrasChavesValidation validation, INEPalavrasChavesWriter writer, INEPalavrasChavesService service, CancellationToken token) =>
        {
            logger.Info("NEPalavrasChaves: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No NEPalavrasChaves found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("NEPalavrasChaves_GetById").WithDisplayName("Get NEPalavrasChaves By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, INEPalavrasChavesValidation validation, INEPalavrasChavesWriter writer, INEPalavrasChavesService service) =>
        {
            logger.Info("NEPalavrasChaves: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No NEPalavrasChaves found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("NEPalavrasChaves_GetByName").WithDisplayName("Get NEPalavrasChaves By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterNEPalavrasChaves? filtro, string uri, INEPalavrasChavesValidation validation, INEPalavrasChavesWriter writer, INEPalavrasChavesService service) =>
        {
            logger.Info("NEPalavrasChaves: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("NEPalavrasChaves_GetListN").WithDisplayName("Get NEPalavrasChaves List N");
        group.MapPost("/AddAndUpdate", async (Models.NEPalavrasChaves regNEPalavrasChaves, string uri, INEPalavrasChavesValidation validation, INEPalavrasChavesWriter writer, INEPalavrasChavesService service) =>
        {
            logger.LogInfo("NEPalavrasChaves", "AddAndUpdate", $"regNEPalavrasChaves = {regNEPalavrasChaves}", uri);
            var result = await service.AddAndUpdate(regNEPalavrasChaves, uri);
            if (result == null)
            {
                logger.LogWarn("NEPalavrasChaves", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("NEPalavrasChaves_AddAndUpdate").WithDisplayName("Add or Update NEPalavrasChaves");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, INEPalavrasChavesValidation validation, INEPalavrasChavesWriter writer, INEPalavrasChavesService service) =>
        {
            logger.LogInfo("NEPalavrasChaves", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("NEPalavrasChaves", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("NEPalavrasChaves_GetColumns").WithDisplayName("Get NEPalavrasChaves Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, INEPalavrasChavesValidation validation, INEPalavrasChavesWriter writer, INEPalavrasChavesService service) =>
        {
            logger.LogInfo("NEPalavrasChaves", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("NEPalavrasChaves", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("NEPalavrasChaves_UpdateColumns").WithDisplayName("Update NEPalavrasChaves Columns");
        group.MapDelete("/Delete", async (int id, string uri, INEPalavrasChavesValidation validation, INEPalavrasChavesWriter writer, INEPalavrasChavesService service) =>
        {
            logger.LogInfo("NEPalavrasChaves", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("NEPalavrasChaves", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("NEPalavrasChaves_Delete").WithDisplayName("Delete NEPalavrasChaves");
    }
}