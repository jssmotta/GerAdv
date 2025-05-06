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
        group.MapGet("/GetAll", async (int max, string uri, ITipoRecursoValidation validation, ITipoRecursoWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, ITipoRecursoService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("TipoRecurso: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("TipoRecurso_GetAll").WithDisplayName("Get All TipoRecurso");
        group.MapPost("/Filter", async (Filters.FilterTipoRecurso filtro, string uri, ITipoRecursoValidation validation, ITipoRecursoWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, ITipoRecursoService service) =>
        {
            logger.Info("TipoRecurso: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoRecurso_Filter").WithDisplayName("Filter TipoRecurso");
        group.MapGet("/GetById/{id}", async (int id, string uri, ITipoRecursoValidation validation, ITipoRecursoWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, ITipoRecursoService service, CancellationToken token) =>
        {
            logger.Info("TipoRecurso: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No TipoRecurso found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoRecurso_GetById").WithDisplayName("Get TipoRecurso By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, ITipoRecursoValidation validation, ITipoRecursoWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, ITipoRecursoService service) =>
        {
            logger.Info("TipoRecurso: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No TipoRecurso found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoRecurso_GetByName").WithDisplayName("Get TipoRecurso By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterTipoRecurso? filtro, string uri, ITipoRecursoValidation validation, ITipoRecursoWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, ITipoRecursoService service) =>
        {
            logger.Info("TipoRecurso: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoRecurso_GetListN").WithDisplayName("Get TipoRecurso List N");
        group.MapPost("/AddAndUpdate", async (Models.TipoRecurso regTipoRecurso, string uri, ITipoRecursoValidation validation, ITipoRecursoWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, ITipoRecursoService service) =>
        {
            logger.LogInfo("TipoRecurso", "AddAndUpdate", $"regTipoRecurso = {regTipoRecurso}", uri);
            var result = await service.AddAndUpdate(regTipoRecurso, uri);
            if (result == null)
            {
                logger.LogWarn("TipoRecurso", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("TipoRecurso_AddAndUpdate").WithDisplayName("Add or Update TipoRecurso");
        group.MapDelete("/Delete", async (int id, string uri, ITipoRecursoValidation validation, ITipoRecursoWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, ITipoRecursoService service) =>
        {
            logger.LogInfo("TipoRecurso", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("TipoRecurso", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoRecurso_Delete").WithDisplayName("Delete TipoRecurso");
    }
}