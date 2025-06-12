#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ClientesSociosEndpoints
{
    public static IEndpointRouteBuilder MapClientesSociosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ClientesSocios").WithTags("ClientesSocios").RequireAuthorization();
        MapClientesSociosRoutes(group);
        return app;
    }

    private static void MapClientesSociosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IClientesSociosService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ClientesSocios_GetAll").WithDisplayName("Get All ClientesSocios");
        group.MapPost("/Filter", async (Filters.FilterClientesSocios filtro, string uri, IClientesSociosService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ClientesSocios_Filter").WithDisplayName("Filter ClientesSocios");
        group.MapGet("/GetById/{id}", async (int id, string uri, IClientesSociosService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ClientesSocios found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ClientesSocios_GetById").WithDisplayName("Get ClientesSocios By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterClientesSocios? filtro, string uri, IClientesSociosService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("ClientesSocios_GetListN").WithDisplayName("Get ClientesSocios List N");
        group.MapPost("/AddAndUpdate", async (Models.ClientesSocios regClientesSocios, string uri, IClientesSociosValidation validation, IClientesSociosWriter writer, IClientesReader clientesReader, ICidadeReader cidadeReader, IClientesSociosService service) =>
        {
            var result = await service.AddAndUpdate(regClientesSocios, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ClientesSocios_AddAndUpdate").WithDisplayName("Add or Update ClientesSocios");
        group.MapDelete("/Delete", async (int id, string uri, IClientesSociosValidation validation, IClientesSociosWriter writer, IClientesReader clientesReader, ICidadeReader cidadeReader, IClientesSociosService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ClientesSocios_Delete").WithDisplayName("Delete ClientesSocios");
    }
}