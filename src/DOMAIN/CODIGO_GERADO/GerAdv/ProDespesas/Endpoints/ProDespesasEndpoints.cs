#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ProDespesasEndpoints
{
    public static IEndpointRouteBuilder MapProDespesasEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ProDespesas").WithTags("ProDespesas").RequireAuthorization();
        MapProDespesasRoutes(group);
        return app;
    }

    private static void MapProDespesasRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IProDespesasService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProDespesas_GetAll").WithDisplayName("Get All ProDespesas");
        group.MapPost("/Filter", async (Filters.FilterProDespesas filtro, string uri, IProDespesasService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProDespesas_Filter").WithDisplayName("Filter ProDespesas");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProDespesasService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ProDespesas found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProDespesas_GetById").WithDisplayName("Get ProDespesas By Id");
        group.MapPost("/AddAndUpdate", async (Models.ProDespesas regProDespesas, string uri, IProDespesasValidation validation, IProDespesasWriter writer, IClientesReader clientesReader, IProcessosReader processosReader, IProDespesasService service) =>
        {
            var result = await service.AddAndUpdate(regProDespesas, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProDespesas_AddAndUpdate").WithDisplayName("Add or Update ProDespesas");
        group.MapDelete("/Delete", async (int id, string uri, IProDespesasValidation validation, IProDespesasWriter writer, IClientesReader clientesReader, IProcessosReader processosReader, IProDespesasService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProDespesas_Delete").WithDisplayName("Delete ProDespesas");
    }
}