#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class TipoRecursoEndpoints
{
    public static IEndpointRouteBuilder MapTipoRecursoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/TipoRecurso").WithTags("TipoRecurso").RequireAuthorization();
        MapTipoRecursoRoutes(group);
        return app;
    }

    private static void MapTipoRecursoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ITipoRecursoService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("TipoRecurso_GetAll").WithDisplayName("Get All TipoRecurso");
        group.MapPost("/Filter", async (Filters.FilterTipoRecurso filtro, string uri, ITipoRecursoService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoRecurso_Filter").WithDisplayName("Filter TipoRecurso");
        group.MapGet("/GetById/{id}", async (int id, string uri, ITipoRecursoService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No TipoRecurso found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoRecurso_GetById").WithDisplayName("Get TipoRecurso By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterTipoRecurso? filtro, string uri, ITipoRecursoService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoRecurso_GetListN").WithDisplayName("Get TipoRecurso List N");
        group.MapPost("/AddAndUpdate", async (Models.TipoRecurso regTipoRecurso, string uri, ITipoRecursoValidation validation, ITipoRecursoWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, ITipoRecursoService service) =>
        {
            var result = await service.AddAndUpdate(regTipoRecurso, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("TipoRecurso_AddAndUpdate").WithDisplayName("Add or Update TipoRecurso");
        group.MapDelete("/Delete", async (int id, string uri, ITipoRecursoValidation validation, ITipoRecursoWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, ITipoRecursoService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoRecurso_Delete").WithDisplayName("Delete TipoRecurso");
    }
}