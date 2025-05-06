#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class StatusInstanciaEndpoints
{
    public static IEndpointRouteBuilder MapStatusInstanciaEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/StatusInstancia").WithTags("StatusInstancia").RequireAuthorization();
        MapStatusInstanciaRoutes(group);
        return app;
    }

    private static void MapStatusInstanciaRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IStatusInstanciaValidation validation, IStatusInstanciaWriter writer, IStatusInstanciaService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("StatusInstancia: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("StatusInstancia_GetAll").WithDisplayName("Get All StatusInstancia");
        group.MapPost("/Filter", async (Filters.FilterStatusInstancia filtro, string uri, IStatusInstanciaValidation validation, IStatusInstanciaWriter writer, IStatusInstanciaService service) =>
        {
            logger.Info("StatusInstancia: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("StatusInstancia_Filter").WithDisplayName("Filter StatusInstancia");
        group.MapGet("/GetById/{id}", async (int id, string uri, IStatusInstanciaValidation validation, IStatusInstanciaWriter writer, IStatusInstanciaService service, CancellationToken token) =>
        {
            logger.Info("StatusInstancia: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No StatusInstancia found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("StatusInstancia_GetById").WithDisplayName("Get StatusInstancia By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IStatusInstanciaValidation validation, IStatusInstanciaWriter writer, IStatusInstanciaService service) =>
        {
            logger.Info("StatusInstancia: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No StatusInstancia found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("StatusInstancia_GetByName").WithDisplayName("Get StatusInstancia By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterStatusInstancia? filtro, string uri, IStatusInstanciaValidation validation, IStatusInstanciaWriter writer, IStatusInstanciaService service) =>
        {
            logger.Info("StatusInstancia: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("StatusInstancia_GetListN").WithDisplayName("Get StatusInstancia List N");
        group.MapPost("/AddAndUpdate", async (Models.StatusInstancia regStatusInstancia, string uri, IStatusInstanciaValidation validation, IStatusInstanciaWriter writer, IStatusInstanciaService service) =>
        {
            logger.LogInfo("StatusInstancia", "AddAndUpdate", $"regStatusInstancia = {regStatusInstancia}", uri);
            var result = await service.AddAndUpdate(regStatusInstancia, uri);
            if (result == null)
            {
                logger.LogWarn("StatusInstancia", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("StatusInstancia_AddAndUpdate").WithDisplayName("Add or Update StatusInstancia");
        group.MapDelete("/Delete", async (int id, string uri, IStatusInstanciaValidation validation, IStatusInstanciaWriter writer, IStatusInstanciaService service) =>
        {
            logger.LogInfo("StatusInstancia", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("StatusInstancia", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("StatusInstancia_Delete").WithDisplayName("Delete StatusInstancia");
    }
}