#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ParteClienteOutrasEndpoints
{
    public static IEndpointRouteBuilder MapParteClienteOutrasEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ParteClienteOutras").WithTags("ParteClienteOutras").RequireAuthorization();
        MapParteClienteOutrasRoutes(group);
        return app;
    }

    private static void MapParteClienteOutrasRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IParteClienteOutrasValidation validation, IParteClienteOutrasWriter writer, IOutrasPartesClienteReader outraspartesclienteReader, IProcessosReader processosReader, IParteClienteOutrasService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("ParteClienteOutras: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ParteClienteOutras_GetAll").WithDisplayName("Get All ParteClienteOutras");
        group.MapPost("/Filter", async (Filters.FilterParteClienteOutras filtro, string uri, IParteClienteOutrasValidation validation, IParteClienteOutrasWriter writer, IOutrasPartesClienteReader outraspartesclienteReader, IProcessosReader processosReader, IParteClienteOutrasService service) =>
        {
            logger.Info("ParteClienteOutras: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ParteClienteOutras_Filter").WithDisplayName("Filter ParteClienteOutras");
        group.MapGet("/GetById/{id}", async (int id, string uri, IParteClienteOutrasValidation validation, IParteClienteOutrasWriter writer, IOutrasPartesClienteReader outraspartesclienteReader, IProcessosReader processosReader, IParteClienteOutrasService service, CancellationToken token) =>
        {
            logger.Info("ParteClienteOutras: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ParteClienteOutras found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ParteClienteOutras_GetById").WithDisplayName("Get ParteClienteOutras By Id");
        group.MapPost("/AddAndUpdate", async (Models.ParteClienteOutras regParteClienteOutras, string uri, IParteClienteOutrasValidation validation, IParteClienteOutrasWriter writer, IOutrasPartesClienteReader outraspartesclienteReader, IProcessosReader processosReader, IParteClienteOutrasService service) =>
        {
            logger.LogInfo("ParteClienteOutras", "AddAndUpdate", $"regParteClienteOutras = {regParteClienteOutras}", uri);
            var result = await service.AddAndUpdate(regParteClienteOutras, uri);
            if (result == null)
            {
                logger.LogWarn("ParteClienteOutras", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ParteClienteOutras_AddAndUpdate").WithDisplayName("Add or Update ParteClienteOutras");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IParteClienteOutrasValidation validation, IParteClienteOutrasWriter writer, IOutrasPartesClienteReader outraspartesclienteReader, IProcessosReader processosReader, IParteClienteOutrasService service) =>
        {
            logger.LogInfo("ParteClienteOutras", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("ParteClienteOutras", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ParteClienteOutras_GetColumns").WithDisplayName("Get ParteClienteOutras Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IParteClienteOutrasValidation validation, IParteClienteOutrasWriter writer, IOutrasPartesClienteReader outraspartesclienteReader, IProcessosReader processosReader, IParteClienteOutrasService service) =>
        {
            logger.LogInfo("ParteClienteOutras", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("ParteClienteOutras", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("ParteClienteOutras_UpdateColumns").WithDisplayName("Update ParteClienteOutras Columns");
        group.MapDelete("/Delete", async (int id, string uri, IParteClienteOutrasValidation validation, IParteClienteOutrasWriter writer, IOutrasPartesClienteReader outraspartesclienteReader, IProcessosReader processosReader, IParteClienteOutrasService service) =>
        {
            logger.LogInfo("ParteClienteOutras", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("ParteClienteOutras", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ParteClienteOutras_Delete").WithDisplayName("Delete ParteClienteOutras");
    }
}