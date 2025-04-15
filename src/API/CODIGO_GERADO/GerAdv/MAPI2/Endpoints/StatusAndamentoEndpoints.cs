#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class StatusAndamentoEndpoints
{
    public static IEndpointRouteBuilder MapStatusAndamentoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/StatusAndamento").WithTags("StatusAndamento").RequireAuthorization();
        MapStatusAndamentoRoutes(group);
        return app;
    }

    private static void MapStatusAndamentoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IStatusAndamentoValidation validation, IStatusAndamentoWriter writer, IStatusAndamentoService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("StatusAndamento: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("StatusAndamento_GetAll").WithDisplayName("Get All StatusAndamento");
        group.MapPost("/Filter", async (Filters.FilterStatusAndamento filtro, string uri, IStatusAndamentoValidation validation, IStatusAndamentoWriter writer, IStatusAndamentoService service) =>
        {
            logger.Info("StatusAndamento: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("StatusAndamento_Filter").WithDisplayName("Filter StatusAndamento");
        group.MapGet("/GetById/{id}", async (int id, string uri, IStatusAndamentoValidation validation, IStatusAndamentoWriter writer, IStatusAndamentoService service, CancellationToken token) =>
        {
            logger.Info("StatusAndamento: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No StatusAndamento found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("StatusAndamento_GetById").WithDisplayName("Get StatusAndamento By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IStatusAndamentoValidation validation, IStatusAndamentoWriter writer, IStatusAndamentoService service) =>
        {
            logger.Info("StatusAndamento: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No StatusAndamento found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("StatusAndamento_GetByName").WithDisplayName("Get StatusAndamento By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterStatusAndamento? filtro, string uri, IStatusAndamentoValidation validation, IStatusAndamentoWriter writer, IStatusAndamentoService service) =>
        {
            logger.Info("StatusAndamento: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("StatusAndamento_GetListN").WithDisplayName("Get StatusAndamento List N");
        group.MapPost("/AddAndUpdate", async (Models.StatusAndamento regStatusAndamento, string uri, IStatusAndamentoValidation validation, IStatusAndamentoWriter writer, IStatusAndamentoService service) =>
        {
            logger.LogInfo("StatusAndamento", "AddAndUpdate", $"regStatusAndamento = {regStatusAndamento}", uri);
            var result = await service.AddAndUpdate(regStatusAndamento, uri);
            if (result == null)
            {
                logger.LogWarn("StatusAndamento", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("StatusAndamento_AddAndUpdate").WithDisplayName("Add or Update StatusAndamento");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IStatusAndamentoValidation validation, IStatusAndamentoWriter writer, IStatusAndamentoService service) =>
        {
            logger.LogInfo("StatusAndamento", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("StatusAndamento", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("StatusAndamento_GetColumns").WithDisplayName("Get StatusAndamento Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IStatusAndamentoValidation validation, IStatusAndamentoWriter writer, IStatusAndamentoService service) =>
        {
            logger.LogInfo("StatusAndamento", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("StatusAndamento", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("StatusAndamento_UpdateColumns").WithDisplayName("Update StatusAndamento Columns");
        group.MapDelete("/Delete", async (int id, string uri, IStatusAndamentoValidation validation, IStatusAndamentoWriter writer, IStatusAndamentoService service) =>
        {
            logger.LogInfo("StatusAndamento", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("StatusAndamento", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("StatusAndamento_Delete").WithDisplayName("Delete StatusAndamento");
    }
}