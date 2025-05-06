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