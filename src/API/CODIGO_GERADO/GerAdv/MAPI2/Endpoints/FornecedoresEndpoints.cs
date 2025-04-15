#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class FornecedoresEndpoints
{
    public static IEndpointRouteBuilder MapFornecedoresEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Fornecedores").WithTags("Fornecedores").RequireAuthorization();
        MapFornecedoresRoutes(group);
        return app;
    }

    private static void MapFornecedoresRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IFornecedoresValidation validation, IFornecedoresWriter writer, IFornecedoresService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Fornecedores: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Fornecedores_GetAll").WithDisplayName("Get All Fornecedores");
        group.MapPost("/Filter", async (Filters.FilterFornecedores filtro, string uri, IFornecedoresValidation validation, IFornecedoresWriter writer, IFornecedoresService service) =>
        {
            logger.Info("Fornecedores: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Fornecedores_Filter").WithDisplayName("Filter Fornecedores");
        group.MapGet("/GetById/{id}", async (int id, string uri, IFornecedoresValidation validation, IFornecedoresWriter writer, IFornecedoresService service, CancellationToken token) =>
        {
            logger.Info("Fornecedores: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Fornecedores found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Fornecedores_GetById").WithDisplayName("Get Fornecedores By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IFornecedoresValidation validation, IFornecedoresWriter writer, IFornecedoresService service) =>
        {
            logger.Info("Fornecedores: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Fornecedores found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Fornecedores_GetByName").WithDisplayName("Get Fornecedores By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterFornecedores? filtro, string uri, IFornecedoresValidation validation, IFornecedoresWriter writer, IFornecedoresService service) =>
        {
            logger.Info("Fornecedores: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Fornecedores_GetListN").WithDisplayName("Get Fornecedores List N");
        group.MapPost("/AddAndUpdate", async (Models.Fornecedores regFornecedores, string uri, IFornecedoresValidation validation, IFornecedoresWriter writer, IFornecedoresService service) =>
        {
            logger.LogInfo("Fornecedores", "AddAndUpdate", $"regFornecedores = {regFornecedores}", uri);
            var result = await service.AddAndUpdate(regFornecedores, uri);
            if (result == null)
            {
                logger.LogWarn("Fornecedores", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Fornecedores_AddAndUpdate").WithDisplayName("Add or Update Fornecedores");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IFornecedoresValidation validation, IFornecedoresWriter writer, IFornecedoresService service) =>
        {
            logger.LogInfo("Fornecedores", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("Fornecedores", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Fornecedores_GetColumns").WithDisplayName("Get Fornecedores Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IFornecedoresValidation validation, IFornecedoresWriter writer, IFornecedoresService service) =>
        {
            logger.LogInfo("Fornecedores", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("Fornecedores", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("Fornecedores_UpdateColumns").WithDisplayName("Update Fornecedores Columns");
        group.MapDelete("/Delete", async (int id, string uri, IFornecedoresValidation validation, IFornecedoresWriter writer, IFornecedoresService service) =>
        {
            logger.LogInfo("Fornecedores", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Fornecedores", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Fornecedores_Delete").WithDisplayName("Delete Fornecedores");
    }
}