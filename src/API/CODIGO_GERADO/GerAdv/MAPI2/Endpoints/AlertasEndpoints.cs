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
        group.MapGet("/GetAll", async (int max, string uri, IAlertasValidation validation, IAlertasWriter writer, IOperadorReader operadorReader, IAlertasService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Alertas: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Alertas_GetAll").WithDisplayName("Get All Alertas");
        group.MapPost("/Filter", async (Filters.FilterAlertas filtro, string uri, IAlertasValidation validation, IAlertasWriter writer, IOperadorReader operadorReader, IAlertasService service) =>
        {
            logger.Info("Alertas: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Alertas_Filter").WithDisplayName("Filter Alertas");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAlertasValidation validation, IAlertasWriter writer, IOperadorReader operadorReader, IAlertasService service, CancellationToken token) =>
        {
            logger.Info("Alertas: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Alertas found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Alertas_GetById").WithDisplayName("Get Alertas By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IAlertasValidation validation, IAlertasWriter writer, IOperadorReader operadorReader, IAlertasService service) =>
        {
            logger.Info("Alertas: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Alertas found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Alertas_GetByName").WithDisplayName("Get Alertas By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterAlertas? filtro, string uri, IAlertasValidation validation, IAlertasWriter writer, IOperadorReader operadorReader, IAlertasService service) =>
        {
            logger.Info("Alertas: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Alertas_GetListN").WithDisplayName("Get Alertas List N");
        group.MapPost("/AddAndUpdate", async (Models.Alertas regAlertas, string uri, IAlertasValidation validation, IAlertasWriter writer, IOperadorReader operadorReader, IAlertasService service) =>
        {
            logger.LogInfo("Alertas", "AddAndUpdate", $"regAlertas = {regAlertas}", uri);
            var result = await service.AddAndUpdate(regAlertas, uri);
            if (result == null)
            {
                logger.LogWarn("Alertas", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Alertas_AddAndUpdate").WithDisplayName("Add or Update Alertas");
        group.MapDelete("/Delete", async (int id, string uri, IAlertasValidation validation, IAlertasWriter writer, IOperadorReader operadorReader, IAlertasService service) =>
        {
            logger.LogInfo("Alertas", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Alertas", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Alertas_Delete").WithDisplayName("Delete Alertas");
    }
}