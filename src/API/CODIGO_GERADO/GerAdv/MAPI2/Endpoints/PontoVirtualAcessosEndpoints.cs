#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class PontoVirtualAcessosEndpoints
{
    public static IEndpointRouteBuilder MapPontoVirtualAcessosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/PontoVirtualAcessos").WithTags("PontoVirtualAcessos").RequireAuthorization();
        MapPontoVirtualAcessosRoutes(group);
        return app;
    }

    private static void MapPontoVirtualAcessosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IPontoVirtualAcessosValidation validation, IPontoVirtualAcessosWriter writer, IOperadorReader operadorReader, IPontoVirtualAcessosService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("PontoVirtualAcessos: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("PontoVirtualAcessos_GetAll").WithDisplayName("Get All PontoVirtualAcessos");
        group.MapPost("/Filter", async (Filters.FilterPontoVirtualAcessos filtro, string uri, IPontoVirtualAcessosValidation validation, IPontoVirtualAcessosWriter writer, IOperadorReader operadorReader, IPontoVirtualAcessosService service) =>
        {
            logger.Info("PontoVirtualAcessos: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("PontoVirtualAcessos_Filter").WithDisplayName("Filter PontoVirtualAcessos");
        group.MapGet("/GetById/{id}", async (int id, string uri, IPontoVirtualAcessosValidation validation, IPontoVirtualAcessosWriter writer, IOperadorReader operadorReader, IPontoVirtualAcessosService service, CancellationToken token) =>
        {
            logger.Info("PontoVirtualAcessos: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No PontoVirtualAcessos found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("PontoVirtualAcessos_GetById").WithDisplayName("Get PontoVirtualAcessos By Id");
        group.MapPost("/AddAndUpdate", async (Models.PontoVirtualAcessos regPontoVirtualAcessos, string uri, IPontoVirtualAcessosValidation validation, IPontoVirtualAcessosWriter writer, IOperadorReader operadorReader, IPontoVirtualAcessosService service) =>
        {
            logger.LogInfo("PontoVirtualAcessos", "AddAndUpdate", $"regPontoVirtualAcessos = {regPontoVirtualAcessos}", uri);
            var result = await service.AddAndUpdate(regPontoVirtualAcessos, uri);
            if (result == null)
            {
                logger.LogWarn("PontoVirtualAcessos", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("PontoVirtualAcessos_AddAndUpdate").WithDisplayName("Add or Update PontoVirtualAcessos");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IPontoVirtualAcessosValidation validation, IPontoVirtualAcessosWriter writer, IOperadorReader operadorReader, IPontoVirtualAcessosService service) =>
        {
            logger.LogInfo("PontoVirtualAcessos", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("PontoVirtualAcessos", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("PontoVirtualAcessos_GetColumns").WithDisplayName("Get PontoVirtualAcessos Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IPontoVirtualAcessosValidation validation, IPontoVirtualAcessosWriter writer, IOperadorReader operadorReader, IPontoVirtualAcessosService service) =>
        {
            logger.LogInfo("PontoVirtualAcessos", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("PontoVirtualAcessos", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("PontoVirtualAcessos_UpdateColumns").WithDisplayName("Update PontoVirtualAcessos Columns");
        group.MapDelete("/Delete", async (int id, string uri, IPontoVirtualAcessosValidation validation, IPontoVirtualAcessosWriter writer, IOperadorReader operadorReader, IPontoVirtualAcessosService service) =>
        {
            logger.LogInfo("PontoVirtualAcessos", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("PontoVirtualAcessos", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("PontoVirtualAcessos_Delete").WithDisplayName("Delete PontoVirtualAcessos");
    }
}