#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class PreClientesEndpoints
{
    public static IEndpointRouteBuilder MapPreClientesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/PreClientes").WithTags("PreClientes").RequireAuthorization();
        MapPreClientesRoutes(group);
        return app;
    }

    private static void MapPreClientesRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IPreClientesValidation validation, IPreClientesWriter writer, IClientesReader clientesReader, IPreClientesService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("PreClientes: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("PreClientes_GetAll").WithDisplayName("Get All PreClientes");
        group.MapPost("/Filter", async (Filters.FilterPreClientes filtro, string uri, IPreClientesValidation validation, IPreClientesWriter writer, IClientesReader clientesReader, IPreClientesService service) =>
        {
            logger.Info("PreClientes: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("PreClientes_Filter").WithDisplayName("Filter PreClientes");
        group.MapGet("/GetById/{id}", async (int id, string uri, IPreClientesValidation validation, IPreClientesWriter writer, IClientesReader clientesReader, IPreClientesService service, CancellationToken token) =>
        {
            logger.Info("PreClientes: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No PreClientes found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("PreClientes_GetById").WithDisplayName("Get PreClientes By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IPreClientesValidation validation, IPreClientesWriter writer, IClientesReader clientesReader, IPreClientesService service) =>
        {
            logger.Info("PreClientes: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No PreClientes found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("PreClientes_GetByName").WithDisplayName("Get PreClientes By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterPreClientes? filtro, string uri, IPreClientesValidation validation, IPreClientesWriter writer, IClientesReader clientesReader, IPreClientesService service) =>
        {
            logger.Info("PreClientes: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("PreClientes_GetListN").WithDisplayName("Get PreClientes List N");
        group.MapPost("/AddAndUpdate", async (Models.PreClientes regPreClientes, string uri, IPreClientesValidation validation, IPreClientesWriter writer, IClientesReader clientesReader, IPreClientesService service) =>
        {
            logger.LogInfo("PreClientes", "AddAndUpdate", $"regPreClientes = {regPreClientes}", uri);
            var result = await service.AddAndUpdate(regPreClientes, uri);
            if (result == null)
            {
                logger.LogWarn("PreClientes", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("PreClientes_AddAndUpdate").WithDisplayName("Add or Update PreClientes");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IPreClientesValidation validation, IPreClientesWriter writer, IClientesReader clientesReader, IPreClientesService service) =>
        {
            logger.LogInfo("PreClientes", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("PreClientes", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("PreClientes_GetColumns").WithDisplayName("Get PreClientes Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IPreClientesValidation validation, IPreClientesWriter writer, IClientesReader clientesReader, IPreClientesService service) =>
        {
            logger.LogInfo("PreClientes", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("PreClientes", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("PreClientes_UpdateColumns").WithDisplayName("Update PreClientes Columns");
        group.MapDelete("/Delete", async (int id, string uri, IPreClientesValidation validation, IPreClientesWriter writer, IClientesReader clientesReader, IPreClientesService service) =>
        {
            logger.LogInfo("PreClientes", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("PreClientes", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("PreClientes_Delete").WithDisplayName("Delete PreClientes");
    }
}