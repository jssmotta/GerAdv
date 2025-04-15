#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class OperadorGruposEndpoints
{
    public static IEndpointRouteBuilder MapOperadorGruposEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/OperadorGrupos").WithTags("OperadorGrupos").RequireAuthorization();
        MapOperadorGruposRoutes(group);
        return app;
    }

    private static void MapOperadorGruposRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IOperadorGruposValidation validation, IOperadorGruposWriter writer, IOperadorGruposService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("OperadorGrupos: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("OperadorGrupos_GetAll").WithDisplayName("Get All OperadorGrupos");
        group.MapPost("/Filter", async (Filters.FilterOperadorGrupos filtro, string uri, IOperadorGruposValidation validation, IOperadorGruposWriter writer, IOperadorGruposService service) =>
        {
            logger.Info("OperadorGrupos: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("OperadorGrupos_Filter").WithDisplayName("Filter OperadorGrupos");
        group.MapGet("/GetById/{id}", async (int id, string uri, IOperadorGruposValidation validation, IOperadorGruposWriter writer, IOperadorGruposService service, CancellationToken token) =>
        {
            logger.Info("OperadorGrupos: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No OperadorGrupos found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OperadorGrupos_GetById").WithDisplayName("Get OperadorGrupos By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IOperadorGruposValidation validation, IOperadorGruposWriter writer, IOperadorGruposService service) =>
        {
            logger.Info("OperadorGrupos: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No OperadorGrupos found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OperadorGrupos_GetByName").WithDisplayName("Get OperadorGrupos By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterOperadorGrupos? filtro, string uri, IOperadorGruposValidation validation, IOperadorGruposWriter writer, IOperadorGruposService service) =>
        {
            logger.Info("OperadorGrupos: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("OperadorGrupos_GetListN").WithDisplayName("Get OperadorGrupos List N");
        group.MapPost("/AddAndUpdate", async (Models.OperadorGrupos regOperadorGrupos, string uri, IOperadorGruposValidation validation, IOperadorGruposWriter writer, IOperadorGruposService service) =>
        {
            logger.LogInfo("OperadorGrupos", "AddAndUpdate", $"regOperadorGrupos = {regOperadorGrupos}", uri);
            var result = await service.AddAndUpdate(regOperadorGrupos, uri);
            if (result == null)
            {
                logger.LogWarn("OperadorGrupos", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("OperadorGrupos_AddAndUpdate").WithDisplayName("Add or Update OperadorGrupos");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IOperadorGruposValidation validation, IOperadorGruposWriter writer, IOperadorGruposService service) =>
        {
            logger.LogInfo("OperadorGrupos", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("OperadorGrupos", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OperadorGrupos_GetColumns").WithDisplayName("Get OperadorGrupos Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IOperadorGruposValidation validation, IOperadorGruposWriter writer, IOperadorGruposService service) =>
        {
            logger.LogInfo("OperadorGrupos", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("OperadorGrupos", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("OperadorGrupos_UpdateColumns").WithDisplayName("Update OperadorGrupos Columns");
        group.MapDelete("/Delete", async (int id, string uri, IOperadorGruposValidation validation, IOperadorGruposWriter writer, IOperadorGruposService service) =>
        {
            logger.LogInfo("OperadorGrupos", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("OperadorGrupos", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OperadorGrupos_Delete").WithDisplayName("Delete OperadorGrupos");
    }
}