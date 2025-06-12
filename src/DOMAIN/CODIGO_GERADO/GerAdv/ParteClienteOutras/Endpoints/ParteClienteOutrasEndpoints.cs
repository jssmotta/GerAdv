#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ParteClienteOutrasEndpoints
{
    public static IEndpointRouteBuilder MapParteClienteOutrasEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ParteClienteOutras").WithTags("ParteClienteOutras").RequireAuthorization();
        MapParteClienteOutrasRoutes(group);
        return app;
    }

    private static void MapParteClienteOutrasRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IParteClienteOutrasService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ParteClienteOutras_GetAll").WithDisplayName("Get All ParteClienteOutras");
        group.MapPost("/Filter", async (Filters.FilterParteClienteOutras filtro, string uri, IParteClienteOutrasService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ParteClienteOutras_Filter").WithDisplayName("Filter ParteClienteOutras");
        group.MapGet("/GetById/{id}", async (int id, string uri, IParteClienteOutrasService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ParteClienteOutras found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ParteClienteOutras_GetById").WithDisplayName("Get ParteClienteOutras By Id");
        group.MapPost("/AddAndUpdate", async (Models.ParteClienteOutras regParteClienteOutras, string uri, IParteClienteOutrasValidation validation, IParteClienteOutrasWriter writer, IOutrasPartesClienteReader outraspartesclienteReader, IProcessosReader processosReader, IParteClienteOutrasService service) =>
        {
            var result = await service.AddAndUpdate(regParteClienteOutras, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ParteClienteOutras_AddAndUpdate").WithDisplayName("Add or Update ParteClienteOutras");
        group.MapDelete("/Delete", async (int id, string uri, IParteClienteOutrasValidation validation, IParteClienteOutrasWriter writer, IOutrasPartesClienteReader outraspartesclienteReader, IProcessosReader processosReader, IParteClienteOutrasService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ParteClienteOutras_Delete").WithDisplayName("Delete ParteClienteOutras");
    }
}