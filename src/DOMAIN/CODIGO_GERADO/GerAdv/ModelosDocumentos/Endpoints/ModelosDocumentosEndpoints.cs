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
        group.MapGet("/GetAll", async (int max, string uri, IModelosDocumentosService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ModelosDocumentos_GetAll").WithDisplayName("Get All ModelosDocumentos");
        group.MapPost("/Filter", async (Filters.FilterModelosDocumentos filtro, string uri, IModelosDocumentosService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ModelosDocumentos_Filter").WithDisplayName("Filter ModelosDocumentos");
        group.MapGet("/GetById/{id}", async (int id, string uri, IModelosDocumentosService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ModelosDocumentos found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ModelosDocumentos_GetById").WithDisplayName("Get ModelosDocumentos By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterModelosDocumentos? filtro, string uri, IModelosDocumentosService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("ModelosDocumentos_GetListN").WithDisplayName("Get ModelosDocumentos List N");
        group.MapPost("/AddAndUpdate", async (Models.ModelosDocumentos regModelosDocumentos, string uri, IModelosDocumentosValidation validation, IModelosDocumentosWriter writer, ITipoModeloDocumentoReader tipomodelodocumentoReader, IModelosDocumentosService service) =>
        {
            var result = await service.AddAndUpdate(regModelosDocumentos, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ModelosDocumentos_AddAndUpdate").WithDisplayName("Add or Update ModelosDocumentos");
        group.MapDelete("/Delete", async (int id, string uri, IModelosDocumentosValidation validation, IModelosDocumentosWriter writer, ITipoModeloDocumentoReader tipomodelodocumentoReader, IModelosDocumentosService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ModelosDocumentos_Delete").WithDisplayName("Delete ModelosDocumentos");
    }
}