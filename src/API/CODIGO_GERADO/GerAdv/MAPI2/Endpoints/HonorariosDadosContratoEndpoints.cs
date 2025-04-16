#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class HonorariosDadosContratoEndpoints
{
    public static IEndpointRouteBuilder MapHonorariosDadosContratoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/HonorariosDadosContrato").WithTags("HonorariosDadosContrato").RequireAuthorization();
        MapHonorariosDadosContratoRoutes(group);
        return app;
    }

    private static void MapHonorariosDadosContratoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IHonorariosDadosContratoValidation validation, IHonorariosDadosContratoWriter writer, IClientesReader clientesReader, IProcessosReader processosReader, IHonorariosDadosContratoService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("HonorariosDadosContrato: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("HonorariosDadosContrato_GetAll").WithDisplayName("Get All HonorariosDadosContrato");
        group.MapPost("/Filter", async (Filters.FilterHonorariosDadosContrato filtro, string uri, IHonorariosDadosContratoValidation validation, IHonorariosDadosContratoWriter writer, IClientesReader clientesReader, IProcessosReader processosReader, IHonorariosDadosContratoService service) =>
        {
            logger.Info("HonorariosDadosContrato: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("HonorariosDadosContrato_Filter").WithDisplayName("Filter HonorariosDadosContrato");
        group.MapGet("/GetById/{id}", async (int id, string uri, IHonorariosDadosContratoValidation validation, IHonorariosDadosContratoWriter writer, IClientesReader clientesReader, IProcessosReader processosReader, IHonorariosDadosContratoService service, CancellationToken token) =>
        {
            logger.Info("HonorariosDadosContrato: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No HonorariosDadosContrato found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("HonorariosDadosContrato_GetById").WithDisplayName("Get HonorariosDadosContrato By Id");
        group.MapPost("/AddAndUpdate", async (Models.HonorariosDadosContrato regHonorariosDadosContrato, string uri, IHonorariosDadosContratoValidation validation, IHonorariosDadosContratoWriter writer, IClientesReader clientesReader, IProcessosReader processosReader, IHonorariosDadosContratoService service) =>
        {
            logger.LogInfo("HonorariosDadosContrato", "AddAndUpdate", $"regHonorariosDadosContrato = {regHonorariosDadosContrato}", uri);
            var result = await service.AddAndUpdate(regHonorariosDadosContrato, uri);
            if (result == null)
            {
                logger.LogWarn("HonorariosDadosContrato", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("HonorariosDadosContrato_AddAndUpdate").WithDisplayName("Add or Update HonorariosDadosContrato");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IHonorariosDadosContratoValidation validation, IHonorariosDadosContratoWriter writer, IClientesReader clientesReader, IProcessosReader processosReader, IHonorariosDadosContratoService service) =>
        {
            logger.LogInfo("HonorariosDadosContrato", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("HonorariosDadosContrato", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("HonorariosDadosContrato_GetColumns").WithDisplayName("Get HonorariosDadosContrato Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IHonorariosDadosContratoValidation validation, IHonorariosDadosContratoWriter writer, IClientesReader clientesReader, IProcessosReader processosReader, IHonorariosDadosContratoService service) =>
        {
            logger.LogInfo("HonorariosDadosContrato", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("HonorariosDadosContrato", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("HonorariosDadosContrato_UpdateColumns").WithDisplayName("Update HonorariosDadosContrato Columns");
        group.MapDelete("/Delete", async (int id, string uri, IHonorariosDadosContratoValidation validation, IHonorariosDadosContratoWriter writer, IClientesReader clientesReader, IProcessosReader processosReader, IHonorariosDadosContratoService service) =>
        {
            logger.LogInfo("HonorariosDadosContrato", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("HonorariosDadosContrato", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("HonorariosDadosContrato_Delete").WithDisplayName("Delete HonorariosDadosContrato");
    }
}