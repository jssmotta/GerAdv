#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class PosicaoOutrasPartesEndpoints
{
    public static IEndpointRouteBuilder MapPosicaoOutrasPartesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/PosicaoOutrasPartes").WithTags("PosicaoOutrasPartes").RequireAuthorization();
        MapPosicaoOutrasPartesRoutes(group);
        return app;
    }

    private static void MapPosicaoOutrasPartesRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IPosicaoOutrasPartesValidation validation, IPosicaoOutrasPartesWriter writer, IPosicaoOutrasPartesService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("PosicaoOutrasPartes: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("PosicaoOutrasPartes_GetAll").WithDisplayName("Get All PosicaoOutrasPartes");
        group.MapPost("/Filter", async (Filters.FilterPosicaoOutrasPartes filtro, string uri, IPosicaoOutrasPartesValidation validation, IPosicaoOutrasPartesWriter writer, IPosicaoOutrasPartesService service) =>
        {
            logger.Info("PosicaoOutrasPartes: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("PosicaoOutrasPartes_Filter").WithDisplayName("Filter PosicaoOutrasPartes");
        group.MapGet("/GetById/{id}", async (int id, string uri, IPosicaoOutrasPartesValidation validation, IPosicaoOutrasPartesWriter writer, IPosicaoOutrasPartesService service, CancellationToken token) =>
        {
            logger.Info("PosicaoOutrasPartes: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No PosicaoOutrasPartes found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("PosicaoOutrasPartes_GetById").WithDisplayName("Get PosicaoOutrasPartes By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IPosicaoOutrasPartesValidation validation, IPosicaoOutrasPartesWriter writer, IPosicaoOutrasPartesService service) =>
        {
            logger.Info("PosicaoOutrasPartes: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No PosicaoOutrasPartes found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("PosicaoOutrasPartes_GetByName").WithDisplayName("Get PosicaoOutrasPartes By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterPosicaoOutrasPartes? filtro, string uri, IPosicaoOutrasPartesValidation validation, IPosicaoOutrasPartesWriter writer, IPosicaoOutrasPartesService service) =>
        {
            logger.Info("PosicaoOutrasPartes: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("PosicaoOutrasPartes_GetListN").WithDisplayName("Get PosicaoOutrasPartes List N");
        group.MapPost("/AddAndUpdate", async (Models.PosicaoOutrasPartes regPosicaoOutrasPartes, string uri, IPosicaoOutrasPartesValidation validation, IPosicaoOutrasPartesWriter writer, IPosicaoOutrasPartesService service) =>
        {
            logger.LogInfo("PosicaoOutrasPartes", "AddAndUpdate", $"regPosicaoOutrasPartes = {regPosicaoOutrasPartes}", uri);
            var result = await service.AddAndUpdate(regPosicaoOutrasPartes, uri);
            if (result == null)
            {
                logger.LogWarn("PosicaoOutrasPartes", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("PosicaoOutrasPartes_AddAndUpdate").WithDisplayName("Add or Update PosicaoOutrasPartes");
        group.MapDelete("/Delete", async (int id, string uri, IPosicaoOutrasPartesValidation validation, IPosicaoOutrasPartesWriter writer, IPosicaoOutrasPartesService service) =>
        {
            logger.LogInfo("PosicaoOutrasPartes", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("PosicaoOutrasPartes", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("PosicaoOutrasPartes_Delete").WithDisplayName("Delete PosicaoOutrasPartes");
    }
}