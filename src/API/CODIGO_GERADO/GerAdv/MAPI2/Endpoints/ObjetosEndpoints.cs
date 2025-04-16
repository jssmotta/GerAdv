#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ObjetosEndpoints
{
    public static IEndpointRouteBuilder MapObjetosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Objetos").WithTags("Objetos").RequireAuthorization();
        MapObjetosRoutes(group);
        return app;
    }

    private static void MapObjetosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IObjetosValidation validation, IObjetosWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IObjetosService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Objetos: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Objetos_GetAll").WithDisplayName("Get All Objetos");
        group.MapPost("/Filter", async (Filters.FilterObjetos filtro, string uri, IObjetosValidation validation, IObjetosWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IObjetosService service) =>
        {
            logger.Info("Objetos: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Objetos_Filter").WithDisplayName("Filter Objetos");
        group.MapGet("/GetById/{id}", async (int id, string uri, IObjetosValidation validation, IObjetosWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IObjetosService service, CancellationToken token) =>
        {
            logger.Info("Objetos: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Objetos found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Objetos_GetById").WithDisplayName("Get Objetos By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IObjetosValidation validation, IObjetosWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IObjetosService service) =>
        {
            logger.Info("Objetos: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Objetos found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Objetos_GetByName").WithDisplayName("Get Objetos By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterObjetos? filtro, string uri, IObjetosValidation validation, IObjetosWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IObjetosService service) =>
        {
            logger.Info("Objetos: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Objetos_GetListN").WithDisplayName("Get Objetos List N");
        group.MapPost("/AddAndUpdate", async (Models.Objetos regObjetos, string uri, IObjetosValidation validation, IObjetosWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IObjetosService service) =>
        {
            logger.LogInfo("Objetos", "AddAndUpdate", $"regObjetos = {regObjetos}", uri);
            var result = await service.AddAndUpdate(regObjetos, uri);
            if (result == null)
            {
                logger.LogWarn("Objetos", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Objetos_AddAndUpdate").WithDisplayName("Add or Update Objetos");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IObjetosValidation validation, IObjetosWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IObjetosService service) =>
        {
            logger.LogInfo("Objetos", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("Objetos", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Objetos_GetColumns").WithDisplayName("Get Objetos Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IObjetosValidation validation, IObjetosWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IObjetosService service) =>
        {
            logger.LogInfo("Objetos", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("Objetos", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("Objetos_UpdateColumns").WithDisplayName("Update Objetos Columns");
        group.MapDelete("/Delete", async (int id, string uri, IObjetosValidation validation, IObjetosWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IObjetosService service) =>
        {
            logger.LogInfo("Objetos", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Objetos", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Objetos_Delete").WithDisplayName("Delete Objetos");
    }
}