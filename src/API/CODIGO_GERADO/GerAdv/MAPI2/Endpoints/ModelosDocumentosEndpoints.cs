#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ModelosDocumentosEndpoints
{
    public static IEndpointRouteBuilder MapModelosDocumentosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ModelosDocumentos").WithTags("ModelosDocumentos").RequireAuthorization();
        MapModelosDocumentosRoutes(group);
        return app;
    }

    private static void MapModelosDocumentosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IModelosDocumentosValidation validation, IModelosDocumentosWriter writer, ITipoModeloDocumentoReader tipomodelodocumentoReader, IModelosDocumentosService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("ModelosDocumentos: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ModelosDocumentos_GetAll").WithDisplayName("Get All ModelosDocumentos");
        group.MapPost("/Filter", async (Filters.FilterModelosDocumentos filtro, string uri, IModelosDocumentosValidation validation, IModelosDocumentosWriter writer, ITipoModeloDocumentoReader tipomodelodocumentoReader, IModelosDocumentosService service) =>
        {
            logger.Info("ModelosDocumentos: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ModelosDocumentos_Filter").WithDisplayName("Filter ModelosDocumentos");
        group.MapGet("/GetById/{id}", async (int id, string uri, IModelosDocumentosValidation validation, IModelosDocumentosWriter writer, ITipoModeloDocumentoReader tipomodelodocumentoReader, IModelosDocumentosService service, CancellationToken token) =>
        {
            logger.Info("ModelosDocumentos: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ModelosDocumentos found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ModelosDocumentos_GetById").WithDisplayName("Get ModelosDocumentos By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IModelosDocumentosValidation validation, IModelosDocumentosWriter writer, ITipoModeloDocumentoReader tipomodelodocumentoReader, IModelosDocumentosService service) =>
        {
            logger.Info("ModelosDocumentos: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No ModelosDocumentos found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ModelosDocumentos_GetByName").WithDisplayName("Get ModelosDocumentos By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterModelosDocumentos? filtro, string uri, IModelosDocumentosValidation validation, IModelosDocumentosWriter writer, ITipoModeloDocumentoReader tipomodelodocumentoReader, IModelosDocumentosService service) =>
        {
            logger.Info("ModelosDocumentos: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("ModelosDocumentos_GetListN").WithDisplayName("Get ModelosDocumentos List N");
        group.MapPost("/AddAndUpdate", async (Models.ModelosDocumentos regModelosDocumentos, string uri, IModelosDocumentosValidation validation, IModelosDocumentosWriter writer, ITipoModeloDocumentoReader tipomodelodocumentoReader, IModelosDocumentosService service) =>
        {
            logger.LogInfo("ModelosDocumentos", "AddAndUpdate", $"regModelosDocumentos = {regModelosDocumentos}", uri);
            var result = await service.AddAndUpdate(regModelosDocumentos, uri);
            if (result == null)
            {
                logger.LogWarn("ModelosDocumentos", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ModelosDocumentos_AddAndUpdate").WithDisplayName("Add or Update ModelosDocumentos");
        group.MapDelete("/Delete", async (int id, string uri, IModelosDocumentosValidation validation, IModelosDocumentosWriter writer, ITipoModeloDocumentoReader tipomodelodocumentoReader, IModelosDocumentosService service) =>
        {
            logger.LogInfo("ModelosDocumentos", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("ModelosDocumentos", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ModelosDocumentos_Delete").WithDisplayName("Delete ModelosDocumentos");
    }
}