#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class GUTAtividadesEndpoints
{
    public static IEndpointRouteBuilder MapGUTAtividadesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/GUTAtividades").WithTags("GUTAtividades").RequireAuthorization();
        MapGUTAtividadesRoutes(group);
        return app;
    }

    private static void MapGUTAtividadesRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IGUTAtividadesValidation validation, IGUTAtividadesWriter writer, IGUTPeriodicidadeReader gutperiodicidadeReader, IOperadorReader operadorReader, IGUTAtividadesService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("GUTAtividades: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("GUTAtividades_GetAll").WithDisplayName("Get All GUTAtividades");
        group.MapPost("/Filter", async (Filters.FilterGUTAtividades filtro, string uri, IGUTAtividadesValidation validation, IGUTAtividadesWriter writer, IGUTPeriodicidadeReader gutperiodicidadeReader, IOperadorReader operadorReader, IGUTAtividadesService service) =>
        {
            logger.Info("GUTAtividades: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("GUTAtividades_Filter").WithDisplayName("Filter GUTAtividades");
        group.MapGet("/GetById/{id}", async (int id, string uri, IGUTAtividadesValidation validation, IGUTAtividadesWriter writer, IGUTPeriodicidadeReader gutperiodicidadeReader, IOperadorReader operadorReader, IGUTAtividadesService service, CancellationToken token) =>
        {
            logger.Info("GUTAtividades: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No GUTAtividades found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GUTAtividades_GetById").WithDisplayName("Get GUTAtividades By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IGUTAtividadesValidation validation, IGUTAtividadesWriter writer, IGUTPeriodicidadeReader gutperiodicidadeReader, IOperadorReader operadorReader, IGUTAtividadesService service) =>
        {
            logger.Info("GUTAtividades: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No GUTAtividades found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GUTAtividades_GetByName").WithDisplayName("Get GUTAtividades By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterGUTAtividades? filtro, string uri, IGUTAtividadesValidation validation, IGUTAtividadesWriter writer, IGUTPeriodicidadeReader gutperiodicidadeReader, IOperadorReader operadorReader, IGUTAtividadesService service) =>
        {
            logger.Info("GUTAtividades: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("GUTAtividades_GetListN").WithDisplayName("Get GUTAtividades List N");
        group.MapPost("/AddAndUpdate", async (Models.GUTAtividades regGUTAtividades, string uri, IGUTAtividadesValidation validation, IGUTAtividadesWriter writer, IGUTPeriodicidadeReader gutperiodicidadeReader, IOperadorReader operadorReader, IGUTAtividadesService service) =>
        {
            logger.LogInfo("GUTAtividades", "AddAndUpdate", $"regGUTAtividades = {regGUTAtividades}", uri);
            var result = await service.AddAndUpdate(regGUTAtividades, uri);
            if (result == null)
            {
                logger.LogWarn("GUTAtividades", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("GUTAtividades_AddAndUpdate").WithDisplayName("Add or Update GUTAtividades");
        group.MapDelete("/Delete", async (int id, string uri, IGUTAtividadesValidation validation, IGUTAtividadesWriter writer, IGUTPeriodicidadeReader gutperiodicidadeReader, IOperadorReader operadorReader, IGUTAtividadesService service) =>
        {
            logger.LogInfo("GUTAtividades", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("GUTAtividades", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GUTAtividades_Delete").WithDisplayName("Delete GUTAtividades");
    }
}