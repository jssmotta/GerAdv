#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class TipoEnderecoSistemaEndpoints
{
    public static IEndpointRouteBuilder MapTipoEnderecoSistemaEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/TipoEnderecoSistema").WithTags("TipoEnderecoSistema").RequireAuthorization();
        MapTipoEnderecoSistemaRoutes(group);
        return app;
    }

    private static void MapTipoEnderecoSistemaRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ITipoEnderecoSistemaValidation validation, ITipoEnderecoSistemaWriter writer, ITipoEnderecoSistemaService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("TipoEnderecoSistema: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("TipoEnderecoSistema_GetAll").WithDisplayName("Get All TipoEnderecoSistema");
        group.MapPost("/Filter", async (Filters.FilterTipoEnderecoSistema filtro, string uri, ITipoEnderecoSistemaValidation validation, ITipoEnderecoSistemaWriter writer, ITipoEnderecoSistemaService service) =>
        {
            logger.Info("TipoEnderecoSistema: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoEnderecoSistema_Filter").WithDisplayName("Filter TipoEnderecoSistema");
        group.MapGet("/GetById/{id}", async (int id, string uri, ITipoEnderecoSistemaValidation validation, ITipoEnderecoSistemaWriter writer, ITipoEnderecoSistemaService service, CancellationToken token) =>
        {
            logger.Info("TipoEnderecoSistema: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No TipoEnderecoSistema found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoEnderecoSistema_GetById").WithDisplayName("Get TipoEnderecoSistema By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, ITipoEnderecoSistemaValidation validation, ITipoEnderecoSistemaWriter writer, ITipoEnderecoSistemaService service) =>
        {
            logger.Info("TipoEnderecoSistema: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No TipoEnderecoSistema found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoEnderecoSistema_GetByName").WithDisplayName("Get TipoEnderecoSistema By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterTipoEnderecoSistema? filtro, string uri, ITipoEnderecoSistemaValidation validation, ITipoEnderecoSistemaWriter writer, ITipoEnderecoSistemaService service) =>
        {
            logger.Info("TipoEnderecoSistema: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoEnderecoSistema_GetListN").WithDisplayName("Get TipoEnderecoSistema List N");
        group.MapPost("/AddAndUpdate", async (Models.TipoEnderecoSistema regTipoEnderecoSistema, string uri, ITipoEnderecoSistemaValidation validation, ITipoEnderecoSistemaWriter writer, ITipoEnderecoSistemaService service) =>
        {
            logger.LogInfo("TipoEnderecoSistema", "AddAndUpdate", $"regTipoEnderecoSistema = {regTipoEnderecoSistema}", uri);
            var result = await service.AddAndUpdate(regTipoEnderecoSistema, uri);
            if (result == null)
            {
                logger.LogWarn("TipoEnderecoSistema", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("TipoEnderecoSistema_AddAndUpdate").WithDisplayName("Add or Update TipoEnderecoSistema");
        group.MapDelete("/Delete", async (int id, string uri, ITipoEnderecoSistemaValidation validation, ITipoEnderecoSistemaWriter writer, ITipoEnderecoSistemaService service) =>
        {
            logger.LogInfo("TipoEnderecoSistema", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("TipoEnderecoSistema", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoEnderecoSistema_Delete").WithDisplayName("Delete TipoEnderecoSistema");
    }
}