#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class OperadoresEndpoints
{
    public static IEndpointRouteBuilder MapOperadoresEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Operadores").WithTags("Operadores").RequireAuthorization();
        MapOperadoresRoutes(group);
        return app;
    }

    private static void MapOperadoresRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IOperadoresValidation validation, IOperadoresWriter writer, IClientesReader clientesReader, IOperadoresService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Operadores: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Operadores_GetAll").WithDisplayName("Get All Operadores");
        group.MapPost("/Filter", async (Filters.FilterOperadores filtro, string uri, IOperadoresValidation validation, IOperadoresWriter writer, IClientesReader clientesReader, IOperadoresService service) =>
        {
            logger.Info("Operadores: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Operadores_Filter").WithDisplayName("Filter Operadores");
        group.MapGet("/GetById/{id}", async (int id, string uri, IOperadoresValidation validation, IOperadoresWriter writer, IClientesReader clientesReader, IOperadoresService service, CancellationToken token) =>
        {
            logger.Info("Operadores: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Operadores found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Operadores_GetById").WithDisplayName("Get Operadores By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IOperadoresValidation validation, IOperadoresWriter writer, IClientesReader clientesReader, IOperadoresService service) =>
        {
            logger.Info("Operadores: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Operadores found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Operadores_GetByName").WithDisplayName("Get Operadores By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterOperadores? filtro, string uri, IOperadoresValidation validation, IOperadoresWriter writer, IClientesReader clientesReader, IOperadoresService service) =>
        {
            logger.Info("Operadores: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Operadores_GetListN").WithDisplayName("Get Operadores List N");
        group.MapPost("/AddAndUpdate", async (Models.Operadores regOperadores, string uri, IOperadoresValidation validation, IOperadoresWriter writer, IClientesReader clientesReader, IOperadoresService service) =>
        {
            logger.LogInfo("Operadores", "AddAndUpdate", $"regOperadores = {regOperadores}", uri);
            var result = await service.AddAndUpdate(regOperadores, uri);
            if (result == null)
            {
                logger.LogWarn("Operadores", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Operadores_AddAndUpdate").WithDisplayName("Add or Update Operadores");
        group.MapDelete("/Delete", async (int id, string uri, IOperadoresValidation validation, IOperadoresWriter writer, IClientesReader clientesReader, IOperadoresService service) =>
        {
            logger.LogInfo("Operadores", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Operadores", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Operadores_Delete").WithDisplayName("Delete Operadores");
    }
}