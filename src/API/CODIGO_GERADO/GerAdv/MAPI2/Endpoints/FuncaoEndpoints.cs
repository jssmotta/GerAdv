#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class FuncaoEndpoints
{
    public static IEndpointRouteBuilder MapFuncaoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Funcao").WithTags("Funcao").RequireAuthorization();
        MapFuncaoRoutes(group);
        return app;
    }

    private static void MapFuncaoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IFuncaoValidation validation, IFuncaoWriter writer, IFuncaoService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Funcao: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Funcao_GetAll").WithDisplayName("Get All Funcao");
        group.MapPost("/Filter", async (Filters.FilterFuncao filtro, string uri, IFuncaoValidation validation, IFuncaoWriter writer, IFuncaoService service) =>
        {
            logger.Info("Funcao: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Funcao_Filter").WithDisplayName("Filter Funcao");
        group.MapGet("/GetById/{id}", async (int id, string uri, IFuncaoValidation validation, IFuncaoWriter writer, IFuncaoService service, CancellationToken token) =>
        {
            logger.Info("Funcao: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Funcao found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Funcao_GetById").WithDisplayName("Get Funcao By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IFuncaoValidation validation, IFuncaoWriter writer, IFuncaoService service) =>
        {
            logger.Info("Funcao: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Funcao found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Funcao_GetByName").WithDisplayName("Get Funcao By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterFuncao? filtro, string uri, IFuncaoValidation validation, IFuncaoWriter writer, IFuncaoService service) =>
        {
            logger.Info("Funcao: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Funcao_GetListN").WithDisplayName("Get Funcao List N");
        group.MapPost("/AddAndUpdate", async (Models.Funcao regFuncao, string uri, IFuncaoValidation validation, IFuncaoWriter writer, IFuncaoService service) =>
        {
            logger.LogInfo("Funcao", "AddAndUpdate", $"regFuncao = {regFuncao}", uri);
            var result = await service.AddAndUpdate(regFuncao, uri);
            if (result == null)
            {
                logger.LogWarn("Funcao", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Funcao_AddAndUpdate").WithDisplayName("Add or Update Funcao");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IFuncaoValidation validation, IFuncaoWriter writer, IFuncaoService service) =>
        {
            logger.LogInfo("Funcao", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("Funcao", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Funcao_GetColumns").WithDisplayName("Get Funcao Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IFuncaoValidation validation, IFuncaoWriter writer, IFuncaoService service) =>
        {
            logger.LogInfo("Funcao", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("Funcao", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("Funcao_UpdateColumns").WithDisplayName("Update Funcao Columns");
        group.MapDelete("/Delete", async (int id, string uri, IFuncaoValidation validation, IFuncaoWriter writer, IFuncaoService service) =>
        {
            logger.LogInfo("Funcao", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Funcao", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Funcao_Delete").WithDisplayName("Delete Funcao");
    }
}