#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class GUTAtividadesMatrizEndpoints
{
    public static IEndpointRouteBuilder MapGUTAtividadesMatrizEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/GUTAtividadesMatriz").WithTags("GUTAtividadesMatriz").RequireAuthorization();
        MapGUTAtividadesMatrizRoutes(group);
        return app;
    }

    private static void MapGUTAtividadesMatrizRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IGUTAtividadesMatrizValidation validation, IGUTAtividadesMatrizWriter writer, IGUTMatrizReader gutmatrizReader, IGUTAtividadesReader gutatividadesReader, IGUTAtividadesMatrizService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("GUTAtividadesMatriz: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("GUTAtividadesMatriz_GetAll").WithDisplayName("Get All GUTAtividadesMatriz");
        group.MapPost("/Filter", async (Filters.FilterGUTAtividadesMatriz filtro, string uri, IGUTAtividadesMatrizValidation validation, IGUTAtividadesMatrizWriter writer, IGUTMatrizReader gutmatrizReader, IGUTAtividadesReader gutatividadesReader, IGUTAtividadesMatrizService service) =>
        {
            logger.Info("GUTAtividadesMatriz: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("GUTAtividadesMatriz_Filter").WithDisplayName("Filter GUTAtividadesMatriz");
        group.MapGet("/GetById/{id}", async (int id, string uri, IGUTAtividadesMatrizValidation validation, IGUTAtividadesMatrizWriter writer, IGUTMatrizReader gutmatrizReader, IGUTAtividadesReader gutatividadesReader, IGUTAtividadesMatrizService service, CancellationToken token) =>
        {
            logger.Info("GUTAtividadesMatriz: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No GUTAtividadesMatriz found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GUTAtividadesMatriz_GetById").WithDisplayName("Get GUTAtividadesMatriz By Id");
        group.MapPost("/AddAndUpdate", async (Models.GUTAtividadesMatriz regGUTAtividadesMatriz, string uri, IGUTAtividadesMatrizValidation validation, IGUTAtividadesMatrizWriter writer, IGUTMatrizReader gutmatrizReader, IGUTAtividadesReader gutatividadesReader, IGUTAtividadesMatrizService service) =>
        {
            logger.LogInfo("GUTAtividadesMatriz", "AddAndUpdate", $"regGUTAtividadesMatriz = {regGUTAtividadesMatriz}", uri);
            var result = await service.AddAndUpdate(regGUTAtividadesMatriz, uri);
            if (result == null)
            {
                logger.LogWarn("GUTAtividadesMatriz", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("GUTAtividadesMatriz_AddAndUpdate").WithDisplayName("Add or Update GUTAtividadesMatriz");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IGUTAtividadesMatrizValidation validation, IGUTAtividadesMatrizWriter writer, IGUTMatrizReader gutmatrizReader, IGUTAtividadesReader gutatividadesReader, IGUTAtividadesMatrizService service) =>
        {
            logger.LogInfo("GUTAtividadesMatriz", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("GUTAtividadesMatriz", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GUTAtividadesMatriz_GetColumns").WithDisplayName("Get GUTAtividadesMatriz Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IGUTAtividadesMatrizValidation validation, IGUTAtividadesMatrizWriter writer, IGUTMatrizReader gutmatrizReader, IGUTAtividadesReader gutatividadesReader, IGUTAtividadesMatrizService service) =>
        {
            logger.LogInfo("GUTAtividadesMatriz", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("GUTAtividadesMatriz", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("GUTAtividadesMatriz_UpdateColumns").WithDisplayName("Update GUTAtividadesMatriz Columns");
        group.MapDelete("/Delete", async (int id, string uri, IGUTAtividadesMatrizValidation validation, IGUTAtividadesMatrizWriter writer, IGUTMatrizReader gutmatrizReader, IGUTAtividadesReader gutatividadesReader, IGUTAtividadesMatrizService service) =>
        {
            logger.LogInfo("GUTAtividadesMatriz", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("GUTAtividadesMatriz", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GUTAtividadesMatriz_Delete").WithDisplayName("Delete GUTAtividadesMatriz");
    }
}