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
        group.MapGet("/GetAll", async (int max, string uri, IContaCorrenteService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ContaCorrente_GetAll").WithDisplayName("Get All ContaCorrente");
        group.MapPost("/Filter", async (Filters.FilterContaCorrente filtro, string uri, IContaCorrenteService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ContaCorrente_Filter").WithDisplayName("Filter ContaCorrente");
        group.MapGet("/GetById/{id}", async (int id, string uri, IContaCorrenteService service, CancellationToken token) =>
        {
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
            var result = await service.AddAndUpdate(regContaCorrente, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ContaCorrente_AddAndUpdate").WithDisplayName("Add or Update ContaCorrente");
        group.MapDelete("/Delete", async (int id, string uri, IContaCorrenteValidation validation, IContaCorrenteWriter writer, IProcessosReader processosReader, IClientesReader clientesReader, IContaCorrenteService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ContaCorrente_Delete").WithDisplayName("Delete ContaCorrente");
    }
}