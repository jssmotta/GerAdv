#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class TipoOrigemSucumbenciaEndpoints
{
    public static IEndpointRouteBuilder MapTipoOrigemSucumbenciaEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/TipoOrigemSucumbencia").WithTags("TipoOrigemSucumbencia").RequireAuthorization();
        MapTipoOrigemSucumbenciaRoutes(group);
        return app;
    }

    private static void MapTipoOrigemSucumbenciaRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ITipoOrigemSucumbenciaValidation validation, ITipoOrigemSucumbenciaWriter writer, ITipoOrigemSucumbenciaService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("TipoOrigemSucumbencia: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("TipoOrigemSucumbencia_GetAll").WithDisplayName("Get All TipoOrigemSucumbencia");
        group.MapPost("/Filter", async (Filters.FilterTipoOrigemSucumbencia filtro, string uri, ITipoOrigemSucumbenciaValidation validation, ITipoOrigemSucumbenciaWriter writer, ITipoOrigemSucumbenciaService service) =>
        {
            logger.Info("TipoOrigemSucumbencia: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoOrigemSucumbencia_Filter").WithDisplayName("Filter TipoOrigemSucumbencia");
        group.MapGet("/GetById/{id}", async (int id, string uri, ITipoOrigemSucumbenciaValidation validation, ITipoOrigemSucumbenciaWriter writer, ITipoOrigemSucumbenciaService service, CancellationToken token) =>
        {
            logger.Info("TipoOrigemSucumbencia: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No TipoOrigemSucumbencia found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoOrigemSucumbencia_GetById").WithDisplayName("Get TipoOrigemSucumbencia By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, ITipoOrigemSucumbenciaValidation validation, ITipoOrigemSucumbenciaWriter writer, ITipoOrigemSucumbenciaService service) =>
        {
            logger.Info("TipoOrigemSucumbencia: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No TipoOrigemSucumbencia found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoOrigemSucumbencia_GetByName").WithDisplayName("Get TipoOrigemSucumbencia By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterTipoOrigemSucumbencia? filtro, string uri, ITipoOrigemSucumbenciaValidation validation, ITipoOrigemSucumbenciaWriter writer, ITipoOrigemSucumbenciaService service) =>
        {
            logger.Info("TipoOrigemSucumbencia: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoOrigemSucumbencia_GetListN").WithDisplayName("Get TipoOrigemSucumbencia List N");
        group.MapPost("/AddAndUpdate", async (Models.TipoOrigemSucumbencia regTipoOrigemSucumbencia, string uri, ITipoOrigemSucumbenciaValidation validation, ITipoOrigemSucumbenciaWriter writer, ITipoOrigemSucumbenciaService service) =>
        {
            logger.LogInfo("TipoOrigemSucumbencia", "AddAndUpdate", $"regTipoOrigemSucumbencia = {regTipoOrigemSucumbencia}", uri);
            var result = await service.AddAndUpdate(regTipoOrigemSucumbencia, uri);
            if (result == null)
            {
                logger.LogWarn("TipoOrigemSucumbencia", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("TipoOrigemSucumbencia_AddAndUpdate").WithDisplayName("Add or Update TipoOrigemSucumbencia");
        group.MapDelete("/Delete", async (int id, string uri, ITipoOrigemSucumbenciaValidation validation, ITipoOrigemSucumbenciaWriter writer, ITipoOrigemSucumbenciaService service) =>
        {
            logger.LogInfo("TipoOrigemSucumbencia", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("TipoOrigemSucumbencia", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoOrigemSucumbencia_Delete").WithDisplayName("Delete TipoOrigemSucumbencia");
    }
}