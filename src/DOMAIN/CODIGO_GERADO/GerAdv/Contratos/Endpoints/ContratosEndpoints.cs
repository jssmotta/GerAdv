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
        group.MapGet("/GetAll", async (int max, string uri, IContratosService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Contratos_GetAll").WithDisplayName("Get All Contratos");
        group.MapPost("/Filter", async (Filters.FilterContratos filtro, string uri, IContratosService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Contratos_Filter").WithDisplayName("Filter Contratos");
        group.MapGet("/GetById/{id}", async (int id, string uri, IContratosService service, CancellationToken token) =>
        {
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
            var result = await service.AddAndUpdate(regContratos, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Contratos_AddAndUpdate").WithDisplayName("Add or Update Contratos");
        group.MapDelete("/Delete", async (int id, string uri, IContratosValidation validation, IContratosWriter writer, IProcessosReader processosReader, IClientesReader clientesReader, IAdvogadosReader advogadosReader, IContratosService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Contratos_Delete").WithDisplayName("Delete Contratos");
    }
}