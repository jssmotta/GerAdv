#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class AnexamentoRegistrosEndpoints
{
    public static IEndpointRouteBuilder MapAnexamentoRegistrosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/AnexamentoRegistros").WithTags("AnexamentoRegistros").RequireAuthorization();
        MapAnexamentoRegistrosRoutes(group);
        return app;
    }

    private static void MapAnexamentoRegistrosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IAnexamentoRegistrosValidation validation, IAnexamentoRegistrosWriter writer, IClientesReader clientesReader, IAnexamentoRegistrosService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("AnexamentoRegistros: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("AnexamentoRegistros_GetAll").WithDisplayName("Get All AnexamentoRegistros");
        group.MapPost("/Filter", async (Filters.FilterAnexamentoRegistros filtro, string uri, IAnexamentoRegistrosValidation validation, IAnexamentoRegistrosWriter writer, IClientesReader clientesReader, IAnexamentoRegistrosService service) =>
        {
            logger.Info("AnexamentoRegistros: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("AnexamentoRegistros_Filter").WithDisplayName("Filter AnexamentoRegistros");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAnexamentoRegistrosValidation validation, IAnexamentoRegistrosWriter writer, IClientesReader clientesReader, IAnexamentoRegistrosService service, CancellationToken token) =>
        {
            logger.Info("AnexamentoRegistros: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No AnexamentoRegistros found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AnexamentoRegistros_GetById").WithDisplayName("Get AnexamentoRegistros By Id");
        group.MapPost("/AddAndUpdate", async (Models.AnexamentoRegistros regAnexamentoRegistros, string uri, IAnexamentoRegistrosValidation validation, IAnexamentoRegistrosWriter writer, IClientesReader clientesReader, IAnexamentoRegistrosService service) =>
        {
            logger.LogInfo("AnexamentoRegistros", "AddAndUpdate", $"regAnexamentoRegistros = {regAnexamentoRegistros}", uri);
            var result = await service.AddAndUpdate(regAnexamentoRegistros, uri);
            if (result == null)
            {
                logger.LogWarn("AnexamentoRegistros", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("AnexamentoRegistros_AddAndUpdate").WithDisplayName("Add or Update AnexamentoRegistros");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IAnexamentoRegistrosValidation validation, IAnexamentoRegistrosWriter writer, IClientesReader clientesReader, IAnexamentoRegistrosService service) =>
        {
            logger.LogInfo("AnexamentoRegistros", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("AnexamentoRegistros", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AnexamentoRegistros_GetColumns").WithDisplayName("Get AnexamentoRegistros Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IAnexamentoRegistrosValidation validation, IAnexamentoRegistrosWriter writer, IClientesReader clientesReader, IAnexamentoRegistrosService service) =>
        {
            logger.LogInfo("AnexamentoRegistros", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("AnexamentoRegistros", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("AnexamentoRegistros_UpdateColumns").WithDisplayName("Update AnexamentoRegistros Columns");
        group.MapDelete("/Delete", async (int id, string uri, IAnexamentoRegistrosValidation validation, IAnexamentoRegistrosWriter writer, IClientesReader clientesReader, IAnexamentoRegistrosService service) =>
        {
            logger.LogInfo("AnexamentoRegistros", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("AnexamentoRegistros", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AnexamentoRegistros_Delete").WithDisplayName("Delete AnexamentoRegistros");
    }
}