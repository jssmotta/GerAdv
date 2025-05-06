#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class TipoContatoCRMEndpoints
{
    public static IEndpointRouteBuilder MapTipoContatoCRMEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/TipoContatoCRM").WithTags("TipoContatoCRM").RequireAuthorization();
        MapTipoContatoCRMRoutes(group);
        return app;
    }

    private static void MapTipoContatoCRMRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ITipoContatoCRMValidation validation, ITipoContatoCRMWriter writer, ITipoContatoCRMService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("TipoContatoCRM: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("TipoContatoCRM_GetAll").WithDisplayName("Get All TipoContatoCRM");
        group.MapPost("/Filter", async (Filters.FilterTipoContatoCRM filtro, string uri, ITipoContatoCRMValidation validation, ITipoContatoCRMWriter writer, ITipoContatoCRMService service) =>
        {
            logger.Info("TipoContatoCRM: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoContatoCRM_Filter").WithDisplayName("Filter TipoContatoCRM");
        group.MapGet("/GetById/{id}", async (int id, string uri, ITipoContatoCRMValidation validation, ITipoContatoCRMWriter writer, ITipoContatoCRMService service, CancellationToken token) =>
        {
            logger.Info("TipoContatoCRM: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No TipoContatoCRM found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoContatoCRM_GetById").WithDisplayName("Get TipoContatoCRM By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, ITipoContatoCRMValidation validation, ITipoContatoCRMWriter writer, ITipoContatoCRMService service) =>
        {
            logger.Info("TipoContatoCRM: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No TipoContatoCRM found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoContatoCRM_GetByName").WithDisplayName("Get TipoContatoCRM By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterTipoContatoCRM? filtro, string uri, ITipoContatoCRMValidation validation, ITipoContatoCRMWriter writer, ITipoContatoCRMService service) =>
        {
            logger.Info("TipoContatoCRM: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoContatoCRM_GetListN").WithDisplayName("Get TipoContatoCRM List N");
        group.MapPost("/AddAndUpdate", async (Models.TipoContatoCRM regTipoContatoCRM, string uri, ITipoContatoCRMValidation validation, ITipoContatoCRMWriter writer, ITipoContatoCRMService service) =>
        {
            logger.LogInfo("TipoContatoCRM", "AddAndUpdate", $"regTipoContatoCRM = {regTipoContatoCRM}", uri);
            var result = await service.AddAndUpdate(regTipoContatoCRM, uri);
            if (result == null)
            {
                logger.LogWarn("TipoContatoCRM", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("TipoContatoCRM_AddAndUpdate").WithDisplayName("Add or Update TipoContatoCRM");
        group.MapDelete("/Delete", async (int id, string uri, ITipoContatoCRMValidation validation, ITipoContatoCRMWriter writer, ITipoContatoCRMService service) =>
        {
            logger.LogInfo("TipoContatoCRM", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("TipoContatoCRM", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoContatoCRM_Delete").WithDisplayName("Delete TipoContatoCRM");
    }
}