#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ColaboradoresEndpoints
{
    public static IEndpointRouteBuilder MapColaboradoresEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Colaboradores").WithTags("Colaboradores").RequireAuthorization();
        MapColaboradoresRoutes(group);
        return app;
    }

    private static void MapColaboradoresRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IColaboradoresValidation validation, IColaboradoresWriter writer, ICargosReader cargosReader, IClientesReader clientesReader, IColaboradoresService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Colaboradores: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Colaboradores_GetAll").WithDisplayName("Get All Colaboradores");
        group.MapPost("/Filter", async (Filters.FilterColaboradores filtro, string uri, IColaboradoresValidation validation, IColaboradoresWriter writer, ICargosReader cargosReader, IClientesReader clientesReader, IColaboradoresService service) =>
        {
            logger.Info("Colaboradores: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Colaboradores_Filter").WithDisplayName("Filter Colaboradores");
        group.MapGet("/GetById/{id}", async (int id, string uri, IColaboradoresValidation validation, IColaboradoresWriter writer, ICargosReader cargosReader, IClientesReader clientesReader, IColaboradoresService service, CancellationToken token) =>
        {
            logger.Info("Colaboradores: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Colaboradores found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Colaboradores_GetById").WithDisplayName("Get Colaboradores By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IColaboradoresValidation validation, IColaboradoresWriter writer, ICargosReader cargosReader, IClientesReader clientesReader, IColaboradoresService service) =>
        {
            logger.Info("Colaboradores: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Colaboradores found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Colaboradores_GetByName").WithDisplayName("Get Colaboradores By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterColaboradores? filtro, string uri, IColaboradoresValidation validation, IColaboradoresWriter writer, ICargosReader cargosReader, IClientesReader clientesReader, IColaboradoresService service) =>
        {
            logger.Info("Colaboradores: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Colaboradores_GetListN").WithDisplayName("Get Colaboradores List N");
        group.MapPost("/AddAndUpdate", async (Models.Colaboradores regColaboradores, string uri, IColaboradoresValidation validation, IColaboradoresWriter writer, ICargosReader cargosReader, IClientesReader clientesReader, IColaboradoresService service) =>
        {
            logger.LogInfo("Colaboradores", "AddAndUpdate", $"regColaboradores = {regColaboradores}", uri);
            var result = await service.AddAndUpdate(regColaboradores, uri);
            if (result == null)
            {
                logger.LogWarn("Colaboradores", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Colaboradores_AddAndUpdate").WithDisplayName("Add or Update Colaboradores");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IColaboradoresValidation validation, IColaboradoresWriter writer, ICargosReader cargosReader, IClientesReader clientesReader, IColaboradoresService service) =>
        {
            logger.LogInfo("Colaboradores", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("Colaboradores", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Colaboradores_GetColumns").WithDisplayName("Get Colaboradores Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IColaboradoresValidation validation, IColaboradoresWriter writer, ICargosReader cargosReader, IClientesReader clientesReader, IColaboradoresService service) =>
        {
            logger.LogInfo("Colaboradores", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("Colaboradores", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("Colaboradores_UpdateColumns").WithDisplayName("Update Colaboradores Columns");
        group.MapDelete("/Delete", async (int id, string uri, IColaboradoresValidation validation, IColaboradoresWriter writer, ICargosReader cargosReader, IClientesReader clientesReader, IColaboradoresService service) =>
        {
            logger.LogInfo("Colaboradores", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Colaboradores", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Colaboradores_Delete").WithDisplayName("Delete Colaboradores");
    }
}