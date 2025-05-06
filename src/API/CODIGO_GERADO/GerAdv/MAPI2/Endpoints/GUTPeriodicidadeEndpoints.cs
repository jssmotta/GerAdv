#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class GUTPeriodicidadeEndpoints
{
    public static IEndpointRouteBuilder MapGUTPeriodicidadeEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/GUTPeriodicidade").WithTags("GUTPeriodicidade").RequireAuthorization();
        MapGUTPeriodicidadeRoutes(group);
        return app;
    }

    private static void MapGUTPeriodicidadeRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IGUTPeriodicidadeValidation validation, IGUTPeriodicidadeWriter writer, IGUTPeriodicidadeService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("GUTPeriodicidade: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("GUTPeriodicidade_GetAll").WithDisplayName("Get All GUTPeriodicidade");
        group.MapPost("/Filter", async (Filters.FilterGUTPeriodicidade filtro, string uri, IGUTPeriodicidadeValidation validation, IGUTPeriodicidadeWriter writer, IGUTPeriodicidadeService service) =>
        {
            logger.Info("GUTPeriodicidade: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("GUTPeriodicidade_Filter").WithDisplayName("Filter GUTPeriodicidade");
        group.MapGet("/GetById/{id}", async (int id, string uri, IGUTPeriodicidadeValidation validation, IGUTPeriodicidadeWriter writer, IGUTPeriodicidadeService service, CancellationToken token) =>
        {
            logger.Info("GUTPeriodicidade: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No GUTPeriodicidade found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GUTPeriodicidade_GetById").WithDisplayName("Get GUTPeriodicidade By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IGUTPeriodicidadeValidation validation, IGUTPeriodicidadeWriter writer, IGUTPeriodicidadeService service) =>
        {
            logger.Info("GUTPeriodicidade: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No GUTPeriodicidade found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GUTPeriodicidade_GetByName").WithDisplayName("Get GUTPeriodicidade By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterGUTPeriodicidade? filtro, string uri, IGUTPeriodicidadeValidation validation, IGUTPeriodicidadeWriter writer, IGUTPeriodicidadeService service) =>
        {
            logger.Info("GUTPeriodicidade: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("GUTPeriodicidade_GetListN").WithDisplayName("Get GUTPeriodicidade List N");
        group.MapPost("/AddAndUpdate", async (Models.GUTPeriodicidade regGUTPeriodicidade, string uri, IGUTPeriodicidadeValidation validation, IGUTPeriodicidadeWriter writer, IGUTPeriodicidadeService service) =>
        {
            logger.LogInfo("GUTPeriodicidade", "AddAndUpdate", $"regGUTPeriodicidade = {regGUTPeriodicidade}", uri);
            var result = await service.AddAndUpdate(regGUTPeriodicidade, uri);
            if (result == null)
            {
                logger.LogWarn("GUTPeriodicidade", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("GUTPeriodicidade_AddAndUpdate").WithDisplayName("Add or Update GUTPeriodicidade");
        group.MapDelete("/Delete", async (int id, string uri, IGUTPeriodicidadeValidation validation, IGUTPeriodicidadeWriter writer, IGUTPeriodicidadeService service) =>
        {
            logger.LogInfo("GUTPeriodicidade", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("GUTPeriodicidade", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GUTPeriodicidade_Delete").WithDisplayName("Delete GUTPeriodicidade");
    }
}