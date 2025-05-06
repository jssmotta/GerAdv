#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class TipoEMailEndpoints
{
    public static IEndpointRouteBuilder MapTipoEMailEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/TipoEMail").WithTags("TipoEMail").RequireAuthorization();
        MapTipoEMailRoutes(group);
        return app;
    }

    private static void MapTipoEMailRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ITipoEMailValidation validation, ITipoEMailWriter writer, ITipoEMailService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("TipoEMail: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("TipoEMail_GetAll").WithDisplayName("Get All TipoEMail");
        group.MapPost("/Filter", async (Filters.FilterTipoEMail filtro, string uri, ITipoEMailValidation validation, ITipoEMailWriter writer, ITipoEMailService service) =>
        {
            logger.Info("TipoEMail: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoEMail_Filter").WithDisplayName("Filter TipoEMail");
        group.MapGet("/GetById/{id}", async (int id, string uri, ITipoEMailValidation validation, ITipoEMailWriter writer, ITipoEMailService service, CancellationToken token) =>
        {
            logger.Info("TipoEMail: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No TipoEMail found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoEMail_GetById").WithDisplayName("Get TipoEMail By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, ITipoEMailValidation validation, ITipoEMailWriter writer, ITipoEMailService service) =>
        {
            logger.Info("TipoEMail: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No TipoEMail found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoEMail_GetByName").WithDisplayName("Get TipoEMail By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterTipoEMail? filtro, string uri, ITipoEMailValidation validation, ITipoEMailWriter writer, ITipoEMailService service) =>
        {
            logger.Info("TipoEMail: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoEMail_GetListN").WithDisplayName("Get TipoEMail List N");
        group.MapPost("/AddAndUpdate", async (Models.TipoEMail regTipoEMail, string uri, ITipoEMailValidation validation, ITipoEMailWriter writer, ITipoEMailService service) =>
        {
            logger.LogInfo("TipoEMail", "AddAndUpdate", $"regTipoEMail = {regTipoEMail}", uri);
            var result = await service.AddAndUpdate(regTipoEMail, uri);
            if (result == null)
            {
                logger.LogWarn("TipoEMail", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("TipoEMail_AddAndUpdate").WithDisplayName("Add or Update TipoEMail");
        group.MapDelete("/Delete", async (int id, string uri, ITipoEMailValidation validation, ITipoEMailWriter writer, ITipoEMailService service) =>
        {
            logger.LogInfo("TipoEMail", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("TipoEMail", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoEMail_Delete").WithDisplayName("Delete TipoEMail");
    }
}