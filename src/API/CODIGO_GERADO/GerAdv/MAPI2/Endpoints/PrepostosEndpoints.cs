#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class PrepostosEndpoints
{
    public static IEndpointRouteBuilder MapPrepostosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Prepostos").WithTags("Prepostos").RequireAuthorization();
        MapPrepostosRoutes(group);
        return app;
    }

    private static void MapPrepostosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IPrepostosValidation validation, IPrepostosWriter writer, IFuncaoReader funcaoReader, ISetorReader setorReader, IPrepostosService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Prepostos: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Prepostos_GetAll").WithDisplayName("Get All Prepostos");
        group.MapPost("/Filter", async (Filters.FilterPrepostos filtro, string uri, IPrepostosValidation validation, IPrepostosWriter writer, IFuncaoReader funcaoReader, ISetorReader setorReader, IPrepostosService service) =>
        {
            logger.Info("Prepostos: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Prepostos_Filter").WithDisplayName("Filter Prepostos");
        group.MapGet("/GetById/{id}", async (int id, string uri, IPrepostosValidation validation, IPrepostosWriter writer, IFuncaoReader funcaoReader, ISetorReader setorReader, IPrepostosService service, CancellationToken token) =>
        {
            logger.Info("Prepostos: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Prepostos found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Prepostos_GetById").WithDisplayName("Get Prepostos By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IPrepostosValidation validation, IPrepostosWriter writer, IFuncaoReader funcaoReader, ISetorReader setorReader, IPrepostosService service) =>
        {
            logger.Info("Prepostos: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Prepostos found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Prepostos_GetByName").WithDisplayName("Get Prepostos By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterPrepostos? filtro, string uri, IPrepostosValidation validation, IPrepostosWriter writer, IFuncaoReader funcaoReader, ISetorReader setorReader, IPrepostosService service) =>
        {
            logger.Info("Prepostos: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Prepostos_GetListN").WithDisplayName("Get Prepostos List N");
        group.MapPost("/AddAndUpdate", async (Models.Prepostos regPrepostos, string uri, IPrepostosValidation validation, IPrepostosWriter writer, IFuncaoReader funcaoReader, ISetorReader setorReader, IPrepostosService service) =>
        {
            logger.LogInfo("Prepostos", "AddAndUpdate", $"regPrepostos = {regPrepostos}", uri);
            var result = await service.AddAndUpdate(regPrepostos, uri);
            if (result == null)
            {
                logger.LogWarn("Prepostos", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Prepostos_AddAndUpdate").WithDisplayName("Add or Update Prepostos");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IPrepostosValidation validation, IPrepostosWriter writer, IFuncaoReader funcaoReader, ISetorReader setorReader, IPrepostosService service) =>
        {
            logger.LogInfo("Prepostos", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("Prepostos", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Prepostos_GetColumns").WithDisplayName("Get Prepostos Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IPrepostosValidation validation, IPrepostosWriter writer, IFuncaoReader funcaoReader, ISetorReader setorReader, IPrepostosService service) =>
        {
            logger.LogInfo("Prepostos", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("Prepostos", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("Prepostos_UpdateColumns").WithDisplayName("Update Prepostos Columns");
        group.MapDelete("/Delete", async (int id, string uri, IPrepostosValidation validation, IPrepostosWriter writer, IFuncaoReader funcaoReader, ISetorReader setorReader, IPrepostosService service) =>
        {
            logger.LogInfo("Prepostos", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Prepostos", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Prepostos_Delete").WithDisplayName("Delete Prepostos");
    }
}