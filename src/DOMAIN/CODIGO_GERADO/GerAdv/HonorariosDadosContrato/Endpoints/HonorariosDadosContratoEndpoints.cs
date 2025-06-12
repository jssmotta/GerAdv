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
        group.MapGet("/GetAll", async (int max, string uri, IHonorariosDadosContratoService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("HonorariosDadosContrato_GetAll").WithDisplayName("Get All HonorariosDadosContrato");
        group.MapPost("/Filter", async (Filters.FilterHonorariosDadosContrato filtro, string uri, IHonorariosDadosContratoService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("HonorariosDadosContrato_Filter").WithDisplayName("Filter HonorariosDadosContrato");
        group.MapGet("/GetById/{id}", async (int id, string uri, IHonorariosDadosContratoService service, CancellationToken token) =>
        {
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
            var result = await service.AddAndUpdate(regHonorariosDadosContrato, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("HonorariosDadosContrato_AddAndUpdate").WithDisplayName("Add or Update HonorariosDadosContrato");
        group.MapDelete("/Delete", async (int id, string uri, IHonorariosDadosContratoValidation validation, IHonorariosDadosContratoWriter writer, IClientesReader clientesReader, IProcessosReader processosReader, IHonorariosDadosContratoService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("HonorariosDadosContrato_Delete").WithDisplayName("Delete HonorariosDadosContrato");
    }
}