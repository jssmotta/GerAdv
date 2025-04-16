#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ContratosEndpoints
{
    public static IEndpointRouteBuilder MapContratosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Contratos").WithTags("Contratos").RequireAuthorization();
        MapContratosRoutes(group);
        return app;
    }

    private static void MapContratosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IContratosValidation validation, IContratosWriter writer, IProcessosReader processosReader, IClientesReader clientesReader, IAdvogadosReader advogadosReader, IContratosService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Contratos: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Contratos_GetAll").WithDisplayName("Get All Contratos");
        group.MapPost("/Filter", async (Filters.FilterContratos filtro, string uri, IContratosValidation validation, IContratosWriter writer, IProcessosReader processosReader, IClientesReader clientesReader, IAdvogadosReader advogadosReader, IContratosService service) =>
        {
            logger.Info("Contratos: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Contratos_Filter").WithDisplayName("Filter Contratos");
        group.MapGet("/GetById/{id}", async (int id, string uri, IContratosValidation validation, IContratosWriter writer, IProcessosReader processosReader, IClientesReader clientesReader, IAdvogadosReader advogadosReader, IContratosService service, CancellationToken token) =>
        {
            logger.Info("Contratos: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Contratos found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Contratos_GetById").WithDisplayName("Get Contratos By Id");
        group.MapPost("/AddAndUpdate", async (Models.Contratos regContratos, string uri, IContratosValidation validation, IContratosWriter writer, IProcessosReader processosReader, IClientesReader clientesReader, IAdvogadosReader advogadosReader, IContratosService service) =>
        {
            logger.LogInfo("Contratos", "AddAndUpdate", $"regContratos = {regContratos}", uri);
            var result = await service.AddAndUpdate(regContratos, uri);
            if (result == null)
            {
                logger.LogWarn("Contratos", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Contratos_AddAndUpdate").WithDisplayName("Add or Update Contratos");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IContratosValidation validation, IContratosWriter writer, IProcessosReader processosReader, IClientesReader clientesReader, IAdvogadosReader advogadosReader, IContratosService service) =>
        {
            logger.LogInfo("Contratos", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("Contratos", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Contratos_GetColumns").WithDisplayName("Get Contratos Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IContratosValidation validation, IContratosWriter writer, IProcessosReader processosReader, IClientesReader clientesReader, IAdvogadosReader advogadosReader, IContratosService service) =>
        {
            logger.LogInfo("Contratos", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("Contratos", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("Contratos_UpdateColumns").WithDisplayName("Update Contratos Columns");
        group.MapDelete("/Delete", async (int id, string uri, IContratosValidation validation, IContratosWriter writer, IProcessosReader processosReader, IClientesReader clientesReader, IAdvogadosReader advogadosReader, IContratosService service) =>
        {
            logger.LogInfo("Contratos", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Contratos", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Contratos_Delete").WithDisplayName("Delete Contratos");
    }
}