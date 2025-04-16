#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ContaCorrenteEndpoints
{
    public static IEndpointRouteBuilder MapContaCorrenteEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ContaCorrente").WithTags("ContaCorrente").RequireAuthorization();
        MapContaCorrenteRoutes(group);
        return app;
    }

    private static void MapContaCorrenteRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IContaCorrenteValidation validation, IContaCorrenteWriter writer, IProcessosReader processosReader, IClientesReader clientesReader, IContaCorrenteService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("ContaCorrente: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ContaCorrente_GetAll").WithDisplayName("Get All ContaCorrente");
        group.MapPost("/Filter", async (Filters.FilterContaCorrente filtro, string uri, IContaCorrenteValidation validation, IContaCorrenteWriter writer, IProcessosReader processosReader, IClientesReader clientesReader, IContaCorrenteService service) =>
        {
            logger.Info("ContaCorrente: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ContaCorrente_Filter").WithDisplayName("Filter ContaCorrente");
        group.MapGet("/GetById/{id}", async (int id, string uri, IContaCorrenteValidation validation, IContaCorrenteWriter writer, IProcessosReader processosReader, IClientesReader clientesReader, IContaCorrenteService service, CancellationToken token) =>
        {
            logger.Info("ContaCorrente: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ContaCorrente found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ContaCorrente_GetById").WithDisplayName("Get ContaCorrente By Id");
        group.MapPost("/AddAndUpdate", async (Models.ContaCorrente regContaCorrente, string uri, IContaCorrenteValidation validation, IContaCorrenteWriter writer, IProcessosReader processosReader, IClientesReader clientesReader, IContaCorrenteService service) =>
        {
            logger.LogInfo("ContaCorrente", "AddAndUpdate", $"regContaCorrente = {regContaCorrente}", uri);
            var result = await service.AddAndUpdate(regContaCorrente, uri);
            if (result == null)
            {
                logger.LogWarn("ContaCorrente", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ContaCorrente_AddAndUpdate").WithDisplayName("Add or Update ContaCorrente");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IContaCorrenteValidation validation, IContaCorrenteWriter writer, IProcessosReader processosReader, IClientesReader clientesReader, IContaCorrenteService service) =>
        {
            logger.LogInfo("ContaCorrente", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("ContaCorrente", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ContaCorrente_GetColumns").WithDisplayName("Get ContaCorrente Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IContaCorrenteValidation validation, IContaCorrenteWriter writer, IProcessosReader processosReader, IClientesReader clientesReader, IContaCorrenteService service) =>
        {
            logger.LogInfo("ContaCorrente", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("ContaCorrente", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("ContaCorrente_UpdateColumns").WithDisplayName("Update ContaCorrente Columns");
        group.MapDelete("/Delete", async (int id, string uri, IContaCorrenteValidation validation, IContaCorrenteWriter writer, IProcessosReader processosReader, IClientesReader clientesReader, IContaCorrenteService service) =>
        {
            logger.LogInfo("ContaCorrente", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("ContaCorrente", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ContaCorrente_Delete").WithDisplayName("Delete ContaCorrente");
    }
}