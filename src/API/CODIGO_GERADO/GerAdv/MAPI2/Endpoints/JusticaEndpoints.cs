#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class JusticaEndpoints
{
    public static IEndpointRouteBuilder MapJusticaEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Justica").WithTags("Justica").RequireAuthorization();
        MapJusticaRoutes(group);
        return app;
    }

    private static void MapJusticaRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IJusticaValidation validation, IJusticaWriter writer, IJusticaService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Justica: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Justica_GetAll").WithDisplayName("Get All Justica");
        group.MapPost("/Filter", async (Filters.FilterJustica filtro, string uri, IJusticaValidation validation, IJusticaWriter writer, IJusticaService service) =>
        {
            logger.Info("Justica: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Justica_Filter").WithDisplayName("Filter Justica");
        group.MapGet("/GetById/{id}", async (int id, string uri, IJusticaValidation validation, IJusticaWriter writer, IJusticaService service, CancellationToken token) =>
        {
            logger.Info("Justica: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Justica found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Justica_GetById").WithDisplayName("Get Justica By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IJusticaValidation validation, IJusticaWriter writer, IJusticaService service) =>
        {
            logger.Info("Justica: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Justica found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Justica_GetByName").WithDisplayName("Get Justica By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterJustica? filtro, string uri, IJusticaValidation validation, IJusticaWriter writer, IJusticaService service) =>
        {
            logger.Info("Justica: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Justica_GetListN").WithDisplayName("Get Justica List N");
        group.MapPost("/AddAndUpdate", async (Models.Justica regJustica, string uri, IJusticaValidation validation, IJusticaWriter writer, IJusticaService service) =>
        {
            logger.LogInfo("Justica", "AddAndUpdate", $"regJustica = {regJustica}", uri);
            var result = await service.AddAndUpdate(regJustica, uri);
            if (result == null)
            {
                logger.LogWarn("Justica", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Justica_AddAndUpdate").WithDisplayName("Add or Update Justica");
        group.MapDelete("/Delete", async (int id, string uri, IJusticaValidation validation, IJusticaWriter writer, IJusticaService service) =>
        {
            logger.LogInfo("Justica", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Justica", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Justica_Delete").WithDisplayName("Delete Justica");
    }
}