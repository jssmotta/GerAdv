#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class LivroCaixaClientesEndpoints
{
    public static IEndpointRouteBuilder MapLivroCaixaClientesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/LivroCaixaClientes").WithTags("LivroCaixaClientes").RequireAuthorization();
        MapLivroCaixaClientesRoutes(group);
        return app;
    }

    private static void MapLivroCaixaClientesRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ILivroCaixaClientesValidation validation, ILivroCaixaClientesWriter writer, ILivroCaixaReader livrocaixaReader, IClientesReader clientesReader, ILivroCaixaClientesService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("LivroCaixaClientes: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("LivroCaixaClientes_GetAll").WithDisplayName("Get All LivroCaixaClientes");
        group.MapPost("/Filter", async (Filters.FilterLivroCaixaClientes filtro, string uri, ILivroCaixaClientesValidation validation, ILivroCaixaClientesWriter writer, ILivroCaixaReader livrocaixaReader, IClientesReader clientesReader, ILivroCaixaClientesService service) =>
        {
            logger.Info("LivroCaixaClientes: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("LivroCaixaClientes_Filter").WithDisplayName("Filter LivroCaixaClientes");
        group.MapGet("/GetById/{id}", async (int id, string uri, ILivroCaixaClientesValidation validation, ILivroCaixaClientesWriter writer, ILivroCaixaReader livrocaixaReader, IClientesReader clientesReader, ILivroCaixaClientesService service, CancellationToken token) =>
        {
            logger.Info("LivroCaixaClientes: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No LivroCaixaClientes found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("LivroCaixaClientes_GetById").WithDisplayName("Get LivroCaixaClientes By Id");
        group.MapPost("/AddAndUpdate", async (Models.LivroCaixaClientes regLivroCaixaClientes, string uri, ILivroCaixaClientesValidation validation, ILivroCaixaClientesWriter writer, ILivroCaixaReader livrocaixaReader, IClientesReader clientesReader, ILivroCaixaClientesService service) =>
        {
            logger.LogInfo("LivroCaixaClientes", "AddAndUpdate", $"regLivroCaixaClientes = {regLivroCaixaClientes}", uri);
            var result = await service.AddAndUpdate(regLivroCaixaClientes, uri);
            if (result == null)
            {
                logger.LogWarn("LivroCaixaClientes", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("LivroCaixaClientes_AddAndUpdate").WithDisplayName("Add or Update LivroCaixaClientes");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, ILivroCaixaClientesValidation validation, ILivroCaixaClientesWriter writer, ILivroCaixaReader livrocaixaReader, IClientesReader clientesReader, ILivroCaixaClientesService service) =>
        {
            logger.LogInfo("LivroCaixaClientes", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("LivroCaixaClientes", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("LivroCaixaClientes_GetColumns").WithDisplayName("Get LivroCaixaClientes Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, ILivroCaixaClientesValidation validation, ILivroCaixaClientesWriter writer, ILivroCaixaReader livrocaixaReader, IClientesReader clientesReader, ILivroCaixaClientesService service) =>
        {
            logger.LogInfo("LivroCaixaClientes", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("LivroCaixaClientes", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("LivroCaixaClientes_UpdateColumns").WithDisplayName("Update LivroCaixaClientes Columns");
        group.MapDelete("/Delete", async (int id, string uri, ILivroCaixaClientesValidation validation, ILivroCaixaClientesWriter writer, ILivroCaixaReader livrocaixaReader, IClientesReader clientesReader, ILivroCaixaClientesService service) =>
        {
            logger.LogInfo("LivroCaixaClientes", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("LivroCaixaClientes", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("LivroCaixaClientes_Delete").WithDisplayName("Delete LivroCaixaClientes");
    }
}