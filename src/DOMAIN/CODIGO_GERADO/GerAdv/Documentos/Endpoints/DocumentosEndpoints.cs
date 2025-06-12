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
        group.MapGet("/GetAll", async (int max, string uri, IDocumentosService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Documentos_GetAll").WithDisplayName("Get All Documentos");
        group.MapPost("/Filter", async (Filters.FilterDocumentos filtro, string uri, IDocumentosService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Documentos_Filter").WithDisplayName("Filter Documentos");
        group.MapGet("/GetById/{id}", async (int id, string uri, IDocumentosService service, CancellationToken token) =>
        {
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
            var result = await service.AddAndUpdate(regDocumentos, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Documentos_AddAndUpdate").WithDisplayName("Add or Update Documentos");
        group.MapDelete("/Delete", async (int id, string uri, IDocumentosValidation validation, IDocumentosWriter writer, IProcessosReader processosReader, IDocumentosService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Documentos_Delete").WithDisplayName("Delete Documentos");
    }
}