#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class AlertasEndpoints
{
    public static IEndpointRouteBuilder MapAlertasEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Alertas").WithTags("Alertas").RequireAuthorization();
        MapAlertasRoutes(group);
        return app;
    }

    private static void MapAlertasRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IAlertasService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Alertas_GetAll").WithDisplayName("Get All Alertas");
        group.MapPost("/Filter", async (Filters.FilterAlertas filtro, string uri, IAlertasService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Alertas_Filter").WithDisplayName("Filter Alertas");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAlertasService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Alertas found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Alertas_GetById").WithDisplayName("Get Alertas By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterAlertas? filtro, string uri, IAlertasService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Alertas_GetListN").WithDisplayName("Get Alertas List N");
        group.MapPost("/AddAndUpdate", async (Models.Alertas regAlertas, string uri, IAlertasValidation validation, IAlertasWriter writer, IOperadorReader operadorReader, IAlertasService service) =>
        {
            var result = await service.AddAndUpdate(regAlertas, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Alertas_AddAndUpdate").WithDisplayName("Add or Update Alertas");
        group.MapDelete("/Delete", async (int id, string uri, IAlertasValidation validation, IAlertasWriter writer, IOperadorReader operadorReader, IAlertasService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Alertas_Delete").WithDisplayName("Delete Alertas");
    }
}