#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class OperadorEndpoints
{
    public static IEndpointRouteBuilder MapOperadorEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Operador").WithTags("Operador").RequireAuthorization();
        MapOperadorRoutes(group);
        return app;
    }

    private static void MapOperadorRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IOperadorValidation validation, IOperadorWriter writer, IStatusBiuReader statusbiuReader, IOperadorService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Operador: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Operador_GetAll").WithDisplayName("Get All Operador");
        group.MapGet("/GetById/{id}", async (int id, string uri, IOperadorValidation validation, IOperadorWriter writer, IStatusBiuReader statusbiuReader, IOperadorService service, CancellationToken token) =>
        {
            logger.Info("Operador: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Operador found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Operador_GetById").WithDisplayName("Get Operador By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IOperadorValidation validation, IOperadorWriter writer, IStatusBiuReader statusbiuReader, IOperadorService service) =>
        {
            logger.Info("Operador: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Operador found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Operador_GetByName").WithDisplayName("Get Operador By Name");
        group.MapGet("/GetListN", async (int max, string uri, IOperadorValidation validation, IOperadorWriter writer, IStatusBiuReader statusbiuReader, IOperadorService service) =>
        {
            logger.Info("Operador: GetListN called, max {0}, {1}", max, uri);
            var result = await service.GetListN(max, uri);
            return Results.Ok(result);
        }).WithName("Operador_GetListN").WithDisplayName("Get Operador List N");
        group.MapPost("/AddAndUpdate", async (Models.Operador regOperador, string uri, IOperadorValidation validation, IOperadorWriter writer, IStatusBiuReader statusbiuReader, IOperadorService service) =>
        {
            logger.LogInfo("Operador", "AddAndUpdate", $"regOperador = {regOperador}", uri);
            var result = await service.AddAndUpdate(regOperador, uri);
            if (result == null)
            {
                logger.LogWarn("Operador", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Operador_AddAndUpdate").WithDisplayName("Add or Update Operador");
        group.MapDelete("/Delete", async (int id, string uri, IOperadorValidation validation, IOperadorWriter writer, IStatusBiuReader statusbiuReader, IOperadorService service) =>
        {
            logger.LogInfo("Operador", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Operador", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Operador_Delete").WithDisplayName("Delete Operador");
    }
}