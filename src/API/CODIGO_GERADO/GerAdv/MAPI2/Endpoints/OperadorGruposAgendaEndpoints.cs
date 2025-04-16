#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class OperadorGruposAgendaEndpoints
{
    public static IEndpointRouteBuilder MapOperadorGruposAgendaEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/OperadorGruposAgenda").WithTags("OperadorGruposAgenda").RequireAuthorization();
        MapOperadorGruposAgendaRoutes(group);
        return app;
    }

    private static void MapOperadorGruposAgendaRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IOperadorGruposAgendaValidation validation, IOperadorGruposAgendaWriter writer, IOperadorReader operadorReader, IOperadorGruposAgendaService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("OperadorGruposAgenda: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("OperadorGruposAgenda_GetAll").WithDisplayName("Get All OperadorGruposAgenda");
        group.MapPost("/Filter", async (Filters.FilterOperadorGruposAgenda filtro, string uri, IOperadorGruposAgendaValidation validation, IOperadorGruposAgendaWriter writer, IOperadorReader operadorReader, IOperadorGruposAgendaService service) =>
        {
            logger.Info("OperadorGruposAgenda: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("OperadorGruposAgenda_Filter").WithDisplayName("Filter OperadorGruposAgenda");
        group.MapGet("/GetById/{id}", async (int id, string uri, IOperadorGruposAgendaValidation validation, IOperadorGruposAgendaWriter writer, IOperadorReader operadorReader, IOperadorGruposAgendaService service, CancellationToken token) =>
        {
            logger.Info("OperadorGruposAgenda: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No OperadorGruposAgenda found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OperadorGruposAgenda_GetById").WithDisplayName("Get OperadorGruposAgenda By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IOperadorGruposAgendaValidation validation, IOperadorGruposAgendaWriter writer, IOperadorReader operadorReader, IOperadorGruposAgendaService service) =>
        {
            logger.Info("OperadorGruposAgenda: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No OperadorGruposAgenda found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OperadorGruposAgenda_GetByName").WithDisplayName("Get OperadorGruposAgenda By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterOperadorGruposAgenda? filtro, string uri, IOperadorGruposAgendaValidation validation, IOperadorGruposAgendaWriter writer, IOperadorReader operadorReader, IOperadorGruposAgendaService service) =>
        {
            logger.Info("OperadorGruposAgenda: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("OperadorGruposAgenda_GetListN").WithDisplayName("Get OperadorGruposAgenda List N");
        group.MapPost("/AddAndUpdate", async (Models.OperadorGruposAgenda regOperadorGruposAgenda, string uri, IOperadorGruposAgendaValidation validation, IOperadorGruposAgendaWriter writer, IOperadorReader operadorReader, IOperadorGruposAgendaService service) =>
        {
            logger.LogInfo("OperadorGruposAgenda", "AddAndUpdate", $"regOperadorGruposAgenda = {regOperadorGruposAgenda}", uri);
            var result = await service.AddAndUpdate(regOperadorGruposAgenda, uri);
            if (result == null)
            {
                logger.LogWarn("OperadorGruposAgenda", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("OperadorGruposAgenda_AddAndUpdate").WithDisplayName("Add or Update OperadorGruposAgenda");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IOperadorGruposAgendaValidation validation, IOperadorGruposAgendaWriter writer, IOperadorReader operadorReader, IOperadorGruposAgendaService service) =>
        {
            logger.LogInfo("OperadorGruposAgenda", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("OperadorGruposAgenda", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OperadorGruposAgenda_GetColumns").WithDisplayName("Get OperadorGruposAgenda Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IOperadorGruposAgendaValidation validation, IOperadorGruposAgendaWriter writer, IOperadorReader operadorReader, IOperadorGruposAgendaService service) =>
        {
            logger.LogInfo("OperadorGruposAgenda", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("OperadorGruposAgenda", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("OperadorGruposAgenda_UpdateColumns").WithDisplayName("Update OperadorGruposAgenda Columns");
        group.MapDelete("/Delete", async (int id, string uri, IOperadorGruposAgendaValidation validation, IOperadorGruposAgendaWriter writer, IOperadorReader operadorReader, IOperadorGruposAgendaService service) =>
        {
            logger.LogInfo("OperadorGruposAgenda", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("OperadorGruposAgenda", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OperadorGruposAgenda_Delete").WithDisplayName("Delete OperadorGruposAgenda");
    }
}