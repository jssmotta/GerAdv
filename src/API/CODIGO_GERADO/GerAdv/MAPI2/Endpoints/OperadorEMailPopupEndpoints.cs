#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class OperadorEMailPopupEndpoints
{
    public static IEndpointRouteBuilder MapOperadorEMailPopupEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/OperadorEMailPopup").WithTags("OperadorEMailPopup").RequireAuthorization();
        MapOperadorEMailPopupRoutes(group);
        return app;
    }

    private static void MapOperadorEMailPopupRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IOperadorEMailPopupValidation validation, IOperadorEMailPopupWriter writer, IOperadorReader operadorReader, IOperadorEMailPopupService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("OperadorEMailPopup: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("OperadorEMailPopup_GetAll").WithDisplayName("Get All OperadorEMailPopup");
        group.MapPost("/Filter", async (Filters.FilterOperadorEMailPopup filtro, string uri, IOperadorEMailPopupValidation validation, IOperadorEMailPopupWriter writer, IOperadorReader operadorReader, IOperadorEMailPopupService service) =>
        {
            logger.Info("OperadorEMailPopup: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("OperadorEMailPopup_Filter").WithDisplayName("Filter OperadorEMailPopup");
        group.MapGet("/GetById/{id}", async (int id, string uri, IOperadorEMailPopupValidation validation, IOperadorEMailPopupWriter writer, IOperadorReader operadorReader, IOperadorEMailPopupService service, CancellationToken token) =>
        {
            logger.Info("OperadorEMailPopup: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No OperadorEMailPopup found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OperadorEMailPopup_GetById").WithDisplayName("Get OperadorEMailPopup By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IOperadorEMailPopupValidation validation, IOperadorEMailPopupWriter writer, IOperadorReader operadorReader, IOperadorEMailPopupService service) =>
        {
            logger.Info("OperadorEMailPopup: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No OperadorEMailPopup found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OperadorEMailPopup_GetByName").WithDisplayName("Get OperadorEMailPopup By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterOperadorEMailPopup? filtro, string uri, IOperadorEMailPopupValidation validation, IOperadorEMailPopupWriter writer, IOperadorReader operadorReader, IOperadorEMailPopupService service) =>
        {
            logger.Info("OperadorEMailPopup: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("OperadorEMailPopup_GetListN").WithDisplayName("Get OperadorEMailPopup List N");
        group.MapPost("/AddAndUpdate", async (Models.OperadorEMailPopup regOperadorEMailPopup, string uri, IOperadorEMailPopupValidation validation, IOperadorEMailPopupWriter writer, IOperadorReader operadorReader, IOperadorEMailPopupService service) =>
        {
            logger.LogInfo("OperadorEMailPopup", "AddAndUpdate", $"regOperadorEMailPopup = {regOperadorEMailPopup}", uri);
            var result = await service.AddAndUpdate(regOperadorEMailPopup, uri);
            if (result == null)
            {
                logger.LogWarn("OperadorEMailPopup", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("OperadorEMailPopup_AddAndUpdate").WithDisplayName("Add or Update OperadorEMailPopup");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IOperadorEMailPopupValidation validation, IOperadorEMailPopupWriter writer, IOperadorReader operadorReader, IOperadorEMailPopupService service) =>
        {
            logger.LogInfo("OperadorEMailPopup", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("OperadorEMailPopup", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OperadorEMailPopup_GetColumns").WithDisplayName("Get OperadorEMailPopup Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IOperadorEMailPopupValidation validation, IOperadorEMailPopupWriter writer, IOperadorReader operadorReader, IOperadorEMailPopupService service) =>
        {
            logger.LogInfo("OperadorEMailPopup", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("OperadorEMailPopup", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("OperadorEMailPopup_UpdateColumns").WithDisplayName("Update OperadorEMailPopup Columns");
        group.MapDelete("/Delete", async (int id, string uri, IOperadorEMailPopupValidation validation, IOperadorEMailPopupWriter writer, IOperadorReader operadorReader, IOperadorEMailPopupService service) =>
        {
            logger.LogInfo("OperadorEMailPopup", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("OperadorEMailPopup", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OperadorEMailPopup_Delete").WithDisplayName("Delete OperadorEMailPopup");
    }
}