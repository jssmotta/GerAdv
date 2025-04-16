#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ForoEndpoints
{
    public static IEndpointRouteBuilder MapForoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Foro").WithTags("Foro").RequireAuthorization();
        MapForoRoutes(group);
        return app;
    }

    private static void MapForoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IForoValidation validation, IForoWriter writer, IForoService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Foro: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Foro_GetAll").WithDisplayName("Get All Foro");
        group.MapPost("/Filter", async (Filters.FilterForo filtro, string uri, IForoValidation validation, IForoWriter writer, IForoService service) =>
        {
            logger.Info("Foro: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Foro_Filter").WithDisplayName("Filter Foro");
        group.MapGet("/GetById/{id}", async (int id, string uri, IForoValidation validation, IForoWriter writer, IForoService service, CancellationToken token) =>
        {
            logger.Info("Foro: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Foro found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Foro_GetById").WithDisplayName("Get Foro By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IForoValidation validation, IForoWriter writer, IForoService service) =>
        {
            logger.Info("Foro: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Foro found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Foro_GetByName").WithDisplayName("Get Foro By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterForo? filtro, string uri, IForoValidation validation, IForoWriter writer, IForoService service) =>
        {
            logger.Info("Foro: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Foro_GetListN").WithDisplayName("Get Foro List N");
        group.MapPost("/AddAndUpdate", async (Models.Foro regForo, string uri, IForoValidation validation, IForoWriter writer, IForoService service) =>
        {
            logger.LogInfo("Foro", "AddAndUpdate", $"regForo = {regForo}", uri);
            var result = await service.AddAndUpdate(regForo, uri);
            if (result == null)
            {
                logger.LogWarn("Foro", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Foro_AddAndUpdate").WithDisplayName("Add or Update Foro");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IForoValidation validation, IForoWriter writer, IForoService service) =>
        {
            logger.LogInfo("Foro", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("Foro", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Foro_GetColumns").WithDisplayName("Get Foro Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IForoValidation validation, IForoWriter writer, IForoService service) =>
        {
            logger.LogInfo("Foro", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("Foro", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("Foro_UpdateColumns").WithDisplayName("Update Foro Columns");
        group.MapDelete("/Delete", async (int id, string uri, IForoValidation validation, IForoWriter writer, IForoService service) =>
        {
            logger.LogInfo("Foro", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Foro", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Foro_Delete").WithDisplayName("Delete Foro");
    }
}