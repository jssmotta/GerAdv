#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class OponentesEndpoints
{
    public static IEndpointRouteBuilder MapOponentesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Oponentes").WithTags("Oponentes").RequireAuthorization();
        MapOponentesRoutes(group);
        return app;
    }

    private static void MapOponentesRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IOponentesValidation validation, IOponentesWriter writer, IOponentesService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Oponentes: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Oponentes_GetAll").WithDisplayName("Get All Oponentes");
        group.MapPost("/Filter", async (Filters.FilterOponentes filtro, string uri, IOponentesValidation validation, IOponentesWriter writer, IOponentesService service) =>
        {
            logger.Info("Oponentes: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Oponentes_Filter").WithDisplayName("Filter Oponentes");
        group.MapGet("/GetById/{id}", async (int id, string uri, IOponentesValidation validation, IOponentesWriter writer, IOponentesService service, CancellationToken token) =>
        {
            logger.Info("Oponentes: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Oponentes found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Oponentes_GetById").WithDisplayName("Get Oponentes By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IOponentesValidation validation, IOponentesWriter writer, IOponentesService service) =>
        {
            logger.Info("Oponentes: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Oponentes found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Oponentes_GetByName").WithDisplayName("Get Oponentes By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterOponentes? filtro, string uri, IOponentesValidation validation, IOponentesWriter writer, IOponentesService service) =>
        {
            logger.Info("Oponentes: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Oponentes_GetListN").WithDisplayName("Get Oponentes List N");
        group.MapPost("/AddAndUpdate", async (Models.Oponentes regOponentes, string uri, IOponentesValidation validation, IOponentesWriter writer, IOponentesService service) =>
        {
            logger.LogInfo("Oponentes", "AddAndUpdate", $"regOponentes = {regOponentes}", uri);
            var result = await service.AddAndUpdate(regOponentes, uri);
            if (result == null)
            {
                logger.LogWarn("Oponentes", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Oponentes_AddAndUpdate").WithDisplayName("Add or Update Oponentes");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IOponentesValidation validation, IOponentesWriter writer, IOponentesService service) =>
        {
            logger.LogInfo("Oponentes", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("Oponentes", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Oponentes_GetColumns").WithDisplayName("Get Oponentes Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IOponentesValidation validation, IOponentesWriter writer, IOponentesService service) =>
        {
            logger.LogInfo("Oponentes", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("Oponentes", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("Oponentes_UpdateColumns").WithDisplayName("Update Oponentes Columns");
        group.MapDelete("/Delete", async (int id, string uri, IOponentesValidation validation, IOponentesWriter writer, IOponentesService service) =>
        {
            logger.LogInfo("Oponentes", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Oponentes", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Oponentes_Delete").WithDisplayName("Delete Oponentes");
    }
}