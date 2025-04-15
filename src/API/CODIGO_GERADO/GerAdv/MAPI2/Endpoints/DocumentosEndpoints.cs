#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class DocumentosEndpoints
{
    public static IEndpointRouteBuilder MapDocumentosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Documentos").WithTags("Documentos").RequireAuthorization();
        MapDocumentosRoutes(group);
        return app;
    }

    private static void MapDocumentosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IDocumentosValidation validation, IDocumentosWriter writer, IProcessosReader processosReader, IDocumentosService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Documentos: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Documentos_GetAll").WithDisplayName("Get All Documentos");
        group.MapPost("/Filter", async (Filters.FilterDocumentos filtro, string uri, IDocumentosValidation validation, IDocumentosWriter writer, IProcessosReader processosReader, IDocumentosService service) =>
        {
            logger.Info("Documentos: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Documentos_Filter").WithDisplayName("Filter Documentos");
        group.MapGet("/GetById/{id}", async (int id, string uri, IDocumentosValidation validation, IDocumentosWriter writer, IProcessosReader processosReader, IDocumentosService service, CancellationToken token) =>
        {
            logger.Info("Documentos: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Documentos found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Documentos_GetById").WithDisplayName("Get Documentos By Id");
        group.MapPost("/AddAndUpdate", async (Models.Documentos regDocumentos, string uri, IDocumentosValidation validation, IDocumentosWriter writer, IProcessosReader processosReader, IDocumentosService service) =>
        {
            logger.LogInfo("Documentos", "AddAndUpdate", $"regDocumentos = {regDocumentos}", uri);
            var result = await service.AddAndUpdate(regDocumentos, uri);
            if (result == null)
            {
                logger.LogWarn("Documentos", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Documentos_AddAndUpdate").WithDisplayName("Add or Update Documentos");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IDocumentosValidation validation, IDocumentosWriter writer, IProcessosReader processosReader, IDocumentosService service) =>
        {
            logger.LogInfo("Documentos", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("Documentos", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Documentos_GetColumns").WithDisplayName("Get Documentos Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IDocumentosValidation validation, IDocumentosWriter writer, IProcessosReader processosReader, IDocumentosService service) =>
        {
            logger.LogInfo("Documentos", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("Documentos", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("Documentos_UpdateColumns").WithDisplayName("Update Documentos Columns");
        group.MapDelete("/Delete", async (int id, string uri, IDocumentosValidation validation, IDocumentosWriter writer, IProcessosReader processosReader, IDocumentosService service) =>
        {
            logger.LogInfo("Documentos", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Documentos", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Documentos_Delete").WithDisplayName("Delete Documentos");
    }
}