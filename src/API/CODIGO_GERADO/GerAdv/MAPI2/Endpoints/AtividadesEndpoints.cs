#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class AtividadesEndpoints
{
    public static IEndpointRouteBuilder MapAtividadesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Atividades").WithTags("Atividades").RequireAuthorization();
        MapAtividadesRoutes(group);
        return app;
    }

    private static void MapAtividadesRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IAtividadesValidation validation, IAtividadesWriter writer, IAtividadesService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Atividades: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Atividades_GetAll").WithDisplayName("Get All Atividades");
        group.MapPost("/Filter", async (Filters.FilterAtividades filtro, string uri, IAtividadesValidation validation, IAtividadesWriter writer, IAtividadesService service) =>
        {
            logger.Info("Atividades: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Atividades_Filter").WithDisplayName("Filter Atividades");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAtividadesValidation validation, IAtividadesWriter writer, IAtividadesService service, CancellationToken token) =>
        {
            logger.Info("Atividades: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Atividades found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Atividades_GetById").WithDisplayName("Get Atividades By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IAtividadesValidation validation, IAtividadesWriter writer, IAtividadesService service) =>
        {
            logger.Info("Atividades: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Atividades found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Atividades_GetByName").WithDisplayName("Get Atividades By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterAtividades? filtro, string uri, IAtividadesValidation validation, IAtividadesWriter writer, IAtividadesService service) =>
        {
            logger.Info("Atividades: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Atividades_GetListN").WithDisplayName("Get Atividades List N");
        group.MapPost("/AddAndUpdate", async (Models.Atividades regAtividades, string uri, IAtividadesValidation validation, IAtividadesWriter writer, IAtividadesService service) =>
        {
            logger.LogInfo("Atividades", "AddAndUpdate", $"regAtividades = {regAtividades}", uri);
            var result = await service.AddAndUpdate(regAtividades, uri);
            if (result == null)
            {
                logger.LogWarn("Atividades", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Atividades_AddAndUpdate").WithDisplayName("Add or Update Atividades");
        group.MapDelete("/Delete", async (int id, string uri, IAtividadesValidation validation, IAtividadesWriter writer, IAtividadesService service) =>
        {
            logger.LogInfo("Atividades", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Atividades", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Atividades_Delete").WithDisplayName("Delete Atividades");
    }
}