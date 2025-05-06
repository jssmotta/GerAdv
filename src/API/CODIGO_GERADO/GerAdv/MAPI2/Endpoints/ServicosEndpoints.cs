#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ServicosEndpoints
{
    public static IEndpointRouteBuilder MapServicosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Servicos").WithTags("Servicos").RequireAuthorization();
        MapServicosRoutes(group);
        return app;
    }

    private static void MapServicosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IServicosValidation validation, IServicosWriter writer, IServicosService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Servicos: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Servicos_GetAll").WithDisplayName("Get All Servicos");
        group.MapPost("/Filter", async (Filters.FilterServicos filtro, string uri, IServicosValidation validation, IServicosWriter writer, IServicosService service) =>
        {
            logger.Info("Servicos: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Servicos_Filter").WithDisplayName("Filter Servicos");
        group.MapGet("/GetById/{id}", async (int id, string uri, IServicosValidation validation, IServicosWriter writer, IServicosService service, CancellationToken token) =>
        {
            logger.Info("Servicos: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Servicos found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Servicos_GetById").WithDisplayName("Get Servicos By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IServicosValidation validation, IServicosWriter writer, IServicosService service) =>
        {
            logger.Info("Servicos: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Servicos found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Servicos_GetByName").WithDisplayName("Get Servicos By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterServicos? filtro, string uri, IServicosValidation validation, IServicosWriter writer, IServicosService service) =>
        {
            logger.Info("Servicos: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Servicos_GetListN").WithDisplayName("Get Servicos List N");
        group.MapPost("/AddAndUpdate", async (Models.Servicos regServicos, string uri, IServicosValidation validation, IServicosWriter writer, IServicosService service) =>
        {
            logger.LogInfo("Servicos", "AddAndUpdate", $"regServicos = {regServicos}", uri);
            var result = await service.AddAndUpdate(regServicos, uri);
            if (result == null)
            {
                logger.LogWarn("Servicos", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Servicos_AddAndUpdate").WithDisplayName("Add or Update Servicos");
        group.MapDelete("/Delete", async (int id, string uri, IServicosValidation validation, IServicosWriter writer, IServicosService service) =>
        {
            logger.LogInfo("Servicos", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Servicos", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Servicos_Delete").WithDisplayName("Delete Servicos");
    }
}