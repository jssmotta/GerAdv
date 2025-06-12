#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ProcessosParadosEndpoints
{
    public static IEndpointRouteBuilder MapProcessosParadosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ProcessosParados").WithTags("ProcessosParados").RequireAuthorization();
        MapProcessosParadosRoutes(group);
        return app;
    }

    private static void MapProcessosParadosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IProcessosParadosService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProcessosParados_GetAll").WithDisplayName("Get All ProcessosParados");
        group.MapPost("/Filter", async (Filters.FilterProcessosParados filtro, string uri, IProcessosParadosService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProcessosParados_Filter").WithDisplayName("Filter ProcessosParados");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProcessosParadosService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ProcessosParados found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProcessosParados_GetById").WithDisplayName("Get ProcessosParados By Id");
        group.MapPost("/AddAndUpdate", async (Models.ProcessosParados regProcessosParados, string uri, IProcessosParadosValidation validation, IProcessosParadosWriter writer, IProcessosReader processosReader, IOperadorReader operadorReader, IProcessosParadosService service) =>
        {
            var result = await service.AddAndUpdate(regProcessosParados, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProcessosParados_AddAndUpdate").WithDisplayName("Add or Update ProcessosParados");
        group.MapDelete("/Delete", async (int id, string uri, IProcessosParadosValidation validation, IProcessosParadosWriter writer, IProcessosReader processosReader, IOperadorReader operadorReader, IProcessosParadosService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProcessosParados_Delete").WithDisplayName("Delete ProcessosParados");
    }
}