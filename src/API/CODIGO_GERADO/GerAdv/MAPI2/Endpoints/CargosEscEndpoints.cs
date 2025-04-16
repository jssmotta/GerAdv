#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class CargosEscEndpoints
{
    public static IEndpointRouteBuilder MapCargosEscEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/CargosEsc").WithTags("CargosEsc").RequireAuthorization();
        MapCargosEscRoutes(group);
        return app;
    }

    private static void MapCargosEscRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ICargosEscValidation validation, ICargosEscWriter writer, ICargosEscService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("CargosEsc: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("CargosEsc_GetAll").WithDisplayName("Get All CargosEsc");
        group.MapPost("/Filter", async (Filters.FilterCargosEsc filtro, string uri, ICargosEscValidation validation, ICargosEscWriter writer, ICargosEscService service) =>
        {
            logger.Info("CargosEsc: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("CargosEsc_Filter").WithDisplayName("Filter CargosEsc");
        group.MapGet("/GetById/{id}", async (int id, string uri, ICargosEscValidation validation, ICargosEscWriter writer, ICargosEscService service, CancellationToken token) =>
        {
            logger.Info("CargosEsc: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No CargosEsc found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("CargosEsc_GetById").WithDisplayName("Get CargosEsc By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, ICargosEscValidation validation, ICargosEscWriter writer, ICargosEscService service) =>
        {
            logger.Info("CargosEsc: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No CargosEsc found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("CargosEsc_GetByName").WithDisplayName("Get CargosEsc By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterCargosEsc? filtro, string uri, ICargosEscValidation validation, ICargosEscWriter writer, ICargosEscService service) =>
        {
            logger.Info("CargosEsc: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("CargosEsc_GetListN").WithDisplayName("Get CargosEsc List N");
        group.MapPost("/AddAndUpdate", async (Models.CargosEsc regCargosEsc, string uri, ICargosEscValidation validation, ICargosEscWriter writer, ICargosEscService service) =>
        {
            logger.LogInfo("CargosEsc", "AddAndUpdate", $"regCargosEsc = {regCargosEsc}", uri);
            var result = await service.AddAndUpdate(regCargosEsc, uri);
            if (result == null)
            {
                logger.LogWarn("CargosEsc", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("CargosEsc_AddAndUpdate").WithDisplayName("Add or Update CargosEsc");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, ICargosEscValidation validation, ICargosEscWriter writer, ICargosEscService service) =>
        {
            logger.LogInfo("CargosEsc", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("CargosEsc", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("CargosEsc_GetColumns").WithDisplayName("Get CargosEsc Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, ICargosEscValidation validation, ICargosEscWriter writer, ICargosEscService service) =>
        {
            logger.LogInfo("CargosEsc", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("CargosEsc", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("CargosEsc_UpdateColumns").WithDisplayName("Update CargosEsc Columns");
        group.MapDelete("/Delete", async (int id, string uri, ICargosEscValidation validation, ICargosEscWriter writer, ICargosEscService service) =>
        {
            logger.LogInfo("CargosEsc", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("CargosEsc", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("CargosEsc_Delete").WithDisplayName("Delete CargosEsc");
    }
}