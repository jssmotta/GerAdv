#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class TipoEnderecoEndpoints
{
    public static IEndpointRouteBuilder MapTipoEnderecoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/TipoEndereco").WithTags("TipoEndereco").RequireAuthorization();
        MapTipoEnderecoRoutes(group);
        return app;
    }

    private static void MapTipoEnderecoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ITipoEnderecoValidation validation, ITipoEnderecoWriter writer, ITipoEnderecoService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("TipoEndereco: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("TipoEndereco_GetAll").WithDisplayName("Get All TipoEndereco");
        group.MapPost("/Filter", async (Filters.FilterTipoEndereco filtro, string uri, ITipoEnderecoValidation validation, ITipoEnderecoWriter writer, ITipoEnderecoService service) =>
        {
            logger.Info("TipoEndereco: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoEndereco_Filter").WithDisplayName("Filter TipoEndereco");
        group.MapGet("/GetById/{id}", async (int id, string uri, ITipoEnderecoValidation validation, ITipoEnderecoWriter writer, ITipoEnderecoService service, CancellationToken token) =>
        {
            logger.Info("TipoEndereco: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No TipoEndereco found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoEndereco_GetById").WithDisplayName("Get TipoEndereco By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, ITipoEnderecoValidation validation, ITipoEnderecoWriter writer, ITipoEnderecoService service) =>
        {
            logger.Info("TipoEndereco: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No TipoEndereco found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoEndereco_GetByName").WithDisplayName("Get TipoEndereco By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterTipoEndereco? filtro, string uri, ITipoEnderecoValidation validation, ITipoEnderecoWriter writer, ITipoEnderecoService service) =>
        {
            logger.Info("TipoEndereco: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoEndereco_GetListN").WithDisplayName("Get TipoEndereco List N");
        group.MapPost("/AddAndUpdate", async (Models.TipoEndereco regTipoEndereco, string uri, ITipoEnderecoValidation validation, ITipoEnderecoWriter writer, ITipoEnderecoService service) =>
        {
            logger.LogInfo("TipoEndereco", "AddAndUpdate", $"regTipoEndereco = {regTipoEndereco}", uri);
            var result = await service.AddAndUpdate(regTipoEndereco, uri);
            if (result == null)
            {
                logger.LogWarn("TipoEndereco", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("TipoEndereco_AddAndUpdate").WithDisplayName("Add or Update TipoEndereco");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, ITipoEnderecoValidation validation, ITipoEnderecoWriter writer, ITipoEnderecoService service) =>
        {
            logger.LogInfo("TipoEndereco", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("TipoEndereco", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoEndereco_GetColumns").WithDisplayName("Get TipoEndereco Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, ITipoEnderecoValidation validation, ITipoEnderecoWriter writer, ITipoEnderecoService service) =>
        {
            logger.LogInfo("TipoEndereco", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("TipoEndereco", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("TipoEndereco_UpdateColumns").WithDisplayName("Update TipoEndereco Columns");
        group.MapDelete("/Delete", async (int id, string uri, ITipoEnderecoValidation validation, ITipoEnderecoWriter writer, ITipoEnderecoService service) =>
        {
            logger.LogInfo("TipoEndereco", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("TipoEndereco", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoEndereco_Delete").WithDisplayName("Delete TipoEndereco");
    }
}