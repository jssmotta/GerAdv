#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class StatusBiuEndpoints
{
    public static IEndpointRouteBuilder MapStatusBiuEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/StatusBiu").WithTags("StatusBiu").RequireAuthorization();
        MapStatusBiuRoutes(group);
        return app;
    }

    private static void MapStatusBiuRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IStatusBiuValidation validation, IStatusBiuWriter writer, ITipoStatusBiuReader tipostatusbiuReader, IOperadorReader operadorReader, IStatusBiuService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("StatusBiu: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("StatusBiu_GetAll").WithDisplayName("Get All StatusBiu");
        group.MapPost("/Filter", async (Filters.FilterStatusBiu filtro, string uri, IStatusBiuValidation validation, IStatusBiuWriter writer, ITipoStatusBiuReader tipostatusbiuReader, IOperadorReader operadorReader, IStatusBiuService service) =>
        {
            logger.Info("StatusBiu: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("StatusBiu_Filter").WithDisplayName("Filter StatusBiu");
        group.MapGet("/GetById/{id}", async (int id, string uri, IStatusBiuValidation validation, IStatusBiuWriter writer, ITipoStatusBiuReader tipostatusbiuReader, IOperadorReader operadorReader, IStatusBiuService service, CancellationToken token) =>
        {
            logger.Info("StatusBiu: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No StatusBiu found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("StatusBiu_GetById").WithDisplayName("Get StatusBiu By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IStatusBiuValidation validation, IStatusBiuWriter writer, ITipoStatusBiuReader tipostatusbiuReader, IOperadorReader operadorReader, IStatusBiuService service) =>
        {
            logger.Info("StatusBiu: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No StatusBiu found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("StatusBiu_GetByName").WithDisplayName("Get StatusBiu By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterStatusBiu? filtro, string uri, IStatusBiuValidation validation, IStatusBiuWriter writer, ITipoStatusBiuReader tipostatusbiuReader, IOperadorReader operadorReader, IStatusBiuService service) =>
        {
            logger.Info("StatusBiu: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("StatusBiu_GetListN").WithDisplayName("Get StatusBiu List N");
        group.MapPost("/AddAndUpdate", async (Models.StatusBiu regStatusBiu, string uri, IStatusBiuValidation validation, IStatusBiuWriter writer, ITipoStatusBiuReader tipostatusbiuReader, IOperadorReader operadorReader, IStatusBiuService service) =>
        {
            logger.LogInfo("StatusBiu", "AddAndUpdate", $"regStatusBiu = {regStatusBiu}", uri);
            var result = await service.AddAndUpdate(regStatusBiu, uri);
            if (result == null)
            {
                logger.LogWarn("StatusBiu", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("StatusBiu_AddAndUpdate").WithDisplayName("Add or Update StatusBiu");
        group.MapDelete("/Delete", async (int id, string uri, IStatusBiuValidation validation, IStatusBiuWriter writer, ITipoStatusBiuReader tipostatusbiuReader, IOperadorReader operadorReader, IStatusBiuService service) =>
        {
            logger.LogInfo("StatusBiu", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("StatusBiu", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("StatusBiu_Delete").WithDisplayName("Delete StatusBiu");
    }
}