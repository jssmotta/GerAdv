#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class OperadorGrupoEndpoints
{
    public static IEndpointRouteBuilder MapOperadorGrupoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/OperadorGrupo").WithTags("OperadorGrupo").RequireAuthorization();
        MapOperadorGrupoRoutes(group);
        return app;
    }

    private static void MapOperadorGrupoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IOperadorGrupoValidation validation, IOperadorGrupoWriter writer, IOperadorReader operadorReader, IOperadorGrupoService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("OperadorGrupo: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("OperadorGrupo_GetAll").WithDisplayName("Get All OperadorGrupo");
        group.MapPost("/Filter", async (Filters.FilterOperadorGrupo filtro, string uri, IOperadorGrupoValidation validation, IOperadorGrupoWriter writer, IOperadorReader operadorReader, IOperadorGrupoService service) =>
        {
            logger.Info("OperadorGrupo: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("OperadorGrupo_Filter").WithDisplayName("Filter OperadorGrupo");
        group.MapGet("/GetById/{id}", async (int id, string uri, IOperadorGrupoValidation validation, IOperadorGrupoWriter writer, IOperadorReader operadorReader, IOperadorGrupoService service, CancellationToken token) =>
        {
            logger.Info("OperadorGrupo: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No OperadorGrupo found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OperadorGrupo_GetById").WithDisplayName("Get OperadorGrupo By Id");
        group.MapPost("/AddAndUpdate", async (Models.OperadorGrupo regOperadorGrupo, string uri, IOperadorGrupoValidation validation, IOperadorGrupoWriter writer, IOperadorReader operadorReader, IOperadorGrupoService service) =>
        {
            logger.LogInfo("OperadorGrupo", "AddAndUpdate", $"regOperadorGrupo = {regOperadorGrupo}", uri);
            var result = await service.AddAndUpdate(regOperadorGrupo, uri);
            if (result == null)
            {
                logger.LogWarn("OperadorGrupo", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("OperadorGrupo_AddAndUpdate").WithDisplayName("Add or Update OperadorGrupo");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IOperadorGrupoValidation validation, IOperadorGrupoWriter writer, IOperadorReader operadorReader, IOperadorGrupoService service) =>
        {
            logger.LogInfo("OperadorGrupo", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("OperadorGrupo", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OperadorGrupo_GetColumns").WithDisplayName("Get OperadorGrupo Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IOperadorGrupoValidation validation, IOperadorGrupoWriter writer, IOperadorReader operadorReader, IOperadorGrupoService service) =>
        {
            logger.LogInfo("OperadorGrupo", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("OperadorGrupo", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("OperadorGrupo_UpdateColumns").WithDisplayName("Update OperadorGrupo Columns");
        group.MapDelete("/Delete", async (int id, string uri, IOperadorGrupoValidation validation, IOperadorGrupoWriter writer, IOperadorReader operadorReader, IOperadorGrupoService service) =>
        {
            logger.LogInfo("OperadorGrupo", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("OperadorGrupo", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OperadorGrupo_Delete").WithDisplayName("Delete OperadorGrupo");
    }
}