#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ProResumosEndpoints
{
    public static IEndpointRouteBuilder MapProResumosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ProResumos").WithTags("ProResumos").RequireAuthorization();
        MapProResumosRoutes(group);
        return app;
    }

    private static void MapProResumosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IProResumosValidation validation, IProResumosWriter writer, IProcessosReader processosReader, IProResumosService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("ProResumos: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProResumos_GetAll").WithDisplayName("Get All ProResumos");
        group.MapPost("/Filter", async (Filters.FilterProResumos filtro, string uri, IProResumosValidation validation, IProResumosWriter writer, IProcessosReader processosReader, IProResumosService service) =>
        {
            logger.Info("ProResumos: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProResumos_Filter").WithDisplayName("Filter ProResumos");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProResumosValidation validation, IProResumosWriter writer, IProcessosReader processosReader, IProResumosService service, CancellationToken token) =>
        {
            logger.Info("ProResumos: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ProResumos found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProResumos_GetById").WithDisplayName("Get ProResumos By Id");
        group.MapPost("/AddAndUpdate", async (Models.ProResumos regProResumos, string uri, IProResumosValidation validation, IProResumosWriter writer, IProcessosReader processosReader, IProResumosService service) =>
        {
            logger.LogInfo("ProResumos", "AddAndUpdate", $"regProResumos = {regProResumos}", uri);
            var result = await service.AddAndUpdate(regProResumos, uri);
            if (result == null)
            {
                logger.LogWarn("ProResumos", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProResumos_AddAndUpdate").WithDisplayName("Add or Update ProResumos");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IProResumosValidation validation, IProResumosWriter writer, IProcessosReader processosReader, IProResumosService service) =>
        {
            logger.LogInfo("ProResumos", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("ProResumos", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProResumos_GetColumns").WithDisplayName("Get ProResumos Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IProResumosValidation validation, IProResumosWriter writer, IProcessosReader processosReader, IProResumosService service) =>
        {
            logger.LogInfo("ProResumos", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("ProResumos", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("ProResumos_UpdateColumns").WithDisplayName("Update ProResumos Columns");
        group.MapDelete("/Delete", async (int id, string uri, IProResumosValidation validation, IProResumosWriter writer, IProcessosReader processosReader, IProResumosService service) =>
        {
            logger.LogInfo("ProResumos", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("ProResumos", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProResumos_Delete").WithDisplayName("Delete ProResumos");
    }
}