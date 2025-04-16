#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class TipoModeloDocumentoEndpoints
{
    public static IEndpointRouteBuilder MapTipoModeloDocumentoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/TipoModeloDocumento").WithTags("TipoModeloDocumento").RequireAuthorization();
        MapTipoModeloDocumentoRoutes(group);
        return app;
    }

    private static void MapTipoModeloDocumentoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ITipoModeloDocumentoValidation validation, ITipoModeloDocumentoWriter writer, ITipoModeloDocumentoService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("TipoModeloDocumento: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("TipoModeloDocumento_GetAll").WithDisplayName("Get All TipoModeloDocumento");
        group.MapPost("/Filter", async (Filters.FilterTipoModeloDocumento filtro, string uri, ITipoModeloDocumentoValidation validation, ITipoModeloDocumentoWriter writer, ITipoModeloDocumentoService service) =>
        {
            logger.Info("TipoModeloDocumento: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoModeloDocumento_Filter").WithDisplayName("Filter TipoModeloDocumento");
        group.MapGet("/GetById/{id}", async (int id, string uri, ITipoModeloDocumentoValidation validation, ITipoModeloDocumentoWriter writer, ITipoModeloDocumentoService service, CancellationToken token) =>
        {
            logger.Info("TipoModeloDocumento: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No TipoModeloDocumento found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoModeloDocumento_GetById").WithDisplayName("Get TipoModeloDocumento By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, ITipoModeloDocumentoValidation validation, ITipoModeloDocumentoWriter writer, ITipoModeloDocumentoService service) =>
        {
            logger.Info("TipoModeloDocumento: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No TipoModeloDocumento found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoModeloDocumento_GetByName").WithDisplayName("Get TipoModeloDocumento By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterTipoModeloDocumento? filtro, string uri, ITipoModeloDocumentoValidation validation, ITipoModeloDocumentoWriter writer, ITipoModeloDocumentoService service) =>
        {
            logger.Info("TipoModeloDocumento: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoModeloDocumento_GetListN").WithDisplayName("Get TipoModeloDocumento List N");
        group.MapPost("/AddAndUpdate", async (Models.TipoModeloDocumento regTipoModeloDocumento, string uri, ITipoModeloDocumentoValidation validation, ITipoModeloDocumentoWriter writer, ITipoModeloDocumentoService service) =>
        {
            logger.LogInfo("TipoModeloDocumento", "AddAndUpdate", $"regTipoModeloDocumento = {regTipoModeloDocumento}", uri);
            var result = await service.AddAndUpdate(regTipoModeloDocumento, uri);
            if (result == null)
            {
                logger.LogWarn("TipoModeloDocumento", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("TipoModeloDocumento_AddAndUpdate").WithDisplayName("Add or Update TipoModeloDocumento");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, ITipoModeloDocumentoValidation validation, ITipoModeloDocumentoWriter writer, ITipoModeloDocumentoService service) =>
        {
            logger.LogInfo("TipoModeloDocumento", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("TipoModeloDocumento", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoModeloDocumento_GetColumns").WithDisplayName("Get TipoModeloDocumento Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, ITipoModeloDocumentoValidation validation, ITipoModeloDocumentoWriter writer, ITipoModeloDocumentoService service) =>
        {
            logger.LogInfo("TipoModeloDocumento", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("TipoModeloDocumento", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("TipoModeloDocumento_UpdateColumns").WithDisplayName("Update TipoModeloDocumento Columns");
        group.MapDelete("/Delete", async (int id, string uri, ITipoModeloDocumentoValidation validation, ITipoModeloDocumentoWriter writer, ITipoModeloDocumentoService service) =>
        {
            logger.LogInfo("TipoModeloDocumento", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("TipoModeloDocumento", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoModeloDocumento_Delete").WithDisplayName("Delete TipoModeloDocumento");
    }
}