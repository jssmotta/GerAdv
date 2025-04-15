#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class CargosEndpoints
{
    public static IEndpointRouteBuilder MapCargosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Cargos").WithTags("Cargos").RequireAuthorization();
        MapCargosRoutes(group);
        return app;
    }

    private static void MapCargosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ICargosValidation validation, ICargosWriter writer, ICargosService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Cargos: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Cargos_GetAll").WithDisplayName("Get All Cargos");
        group.MapPost("/Filter", async (Filters.FilterCargos filtro, string uri, ICargosValidation validation, ICargosWriter writer, ICargosService service) =>
        {
            logger.Info("Cargos: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Cargos_Filter").WithDisplayName("Filter Cargos");
        group.MapGet("/GetById/{id}", async (int id, string uri, ICargosValidation validation, ICargosWriter writer, ICargosService service, CancellationToken token) =>
        {
            logger.Info("Cargos: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Cargos found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Cargos_GetById").WithDisplayName("Get Cargos By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, ICargosValidation validation, ICargosWriter writer, ICargosService service) =>
        {
            logger.Info("Cargos: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Cargos found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Cargos_GetByName").WithDisplayName("Get Cargos By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterCargos? filtro, string uri, ICargosValidation validation, ICargosWriter writer, ICargosService service) =>
        {
            logger.Info("Cargos: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Cargos_GetListN").WithDisplayName("Get Cargos List N");
        group.MapPost("/AddAndUpdate", async (Models.Cargos regCargos, string uri, ICargosValidation validation, ICargosWriter writer, ICargosService service) =>
        {
            logger.LogInfo("Cargos", "AddAndUpdate", $"regCargos = {regCargos}", uri);
            var result = await service.AddAndUpdate(regCargos, uri);
            if (result == null)
            {
                logger.LogWarn("Cargos", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Cargos_AddAndUpdate").WithDisplayName("Add or Update Cargos");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, ICargosValidation validation, ICargosWriter writer, ICargosService service) =>
        {
            logger.LogInfo("Cargos", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("Cargos", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Cargos_GetColumns").WithDisplayName("Get Cargos Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, ICargosValidation validation, ICargosWriter writer, ICargosService service) =>
        {
            logger.LogInfo("Cargos", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("Cargos", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("Cargos_UpdateColumns").WithDisplayName("Update Cargos Columns");
        group.MapDelete("/Delete", async (int id, string uri, ICargosValidation validation, ICargosWriter writer, ICargosService service) =>
        {
            logger.LogInfo("Cargos", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Cargos", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Cargos_Delete").WithDisplayName("Delete Cargos");
    }
}