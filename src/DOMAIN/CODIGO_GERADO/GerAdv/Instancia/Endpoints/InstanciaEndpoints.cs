#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class InstanciaEndpoints
{
    public static IEndpointRouteBuilder MapInstanciaEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Instancia").WithTags("Instancia").RequireAuthorization();
        MapInstanciaRoutes(group);
        return app;
    }

    private static void MapInstanciaRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IInstanciaService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Instancia_GetAll").WithDisplayName("Get All Instancia");
        group.MapPost("/Filter", async (Filters.FilterInstancia filtro, string uri, IInstanciaService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Instancia_Filter").WithDisplayName("Filter Instancia");
        group.MapGet("/GetById/{id}", async (int id, string uri, IInstanciaService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Instancia found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Instancia_GetById").WithDisplayName("Get Instancia By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterInstancia? filtro, string uri, IInstanciaService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Instancia_GetListN").WithDisplayName("Get Instancia List N");
        group.MapPost("/AddAndUpdate", async (Models.Instancia regInstancia, string uri, IInstanciaValidation validation, IInstanciaWriter writer, IProcessosReader processosReader, IAcaoReader acaoReader, IForoReader foroReader, ITipoRecursoReader tiporecursoReader, IInstanciaService service) =>
        {
            var result = await service.AddAndUpdate(regInstancia, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Instancia_AddAndUpdate").WithDisplayName("Add or Update Instancia");
        group.MapDelete("/Delete", async (int id, string uri, IInstanciaValidation validation, IInstanciaWriter writer, IProcessosReader processosReader, IAcaoReader acaoReader, IForoReader foroReader, ITipoRecursoReader tiporecursoReader, IInstanciaService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Instancia_Delete").WithDisplayName("Delete Instancia");
    }
}