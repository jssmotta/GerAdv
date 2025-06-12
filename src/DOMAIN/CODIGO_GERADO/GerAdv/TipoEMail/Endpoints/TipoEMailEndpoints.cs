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
        group.MapGet("/GetAll", async (int max, string uri, ITipoEMailService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("TipoEMail_GetAll").WithDisplayName("Get All TipoEMail");
        group.MapPost("/Filter", async (Filters.FilterTipoEMail filtro, string uri, ITipoEMailService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoEMail_Filter").WithDisplayName("Filter TipoEMail");
        group.MapGet("/GetById/{id}", async (int id, string uri, ITipoEMailService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No TipoEMail found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoEMail_GetById").WithDisplayName("Get TipoEMail By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterTipoEMail? filtro, string uri, ITipoEMailService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoEMail_GetListN").WithDisplayName("Get TipoEMail List N");
        group.MapPost("/AddAndUpdate", async (Models.TipoEMail regTipoEMail, string uri, ITipoEMailValidation validation, ITipoEMailWriter writer, ITipoEMailService service) =>
        {
            var result = await service.AddAndUpdate(regTipoEMail, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("TipoEMail_AddAndUpdate").WithDisplayName("Add or Update TipoEMail");
        group.MapDelete("/Delete", async (int id, string uri, ITipoEMailValidation validation, ITipoEMailWriter writer, ITipoEMailService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoEMail_Delete").WithDisplayName("Delete TipoEMail");
    }
}