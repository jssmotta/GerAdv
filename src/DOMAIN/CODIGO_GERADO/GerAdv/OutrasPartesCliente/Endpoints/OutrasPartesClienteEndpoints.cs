#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class OutrasPartesClienteEndpoints
{
    public static IEndpointRouteBuilder MapOutrasPartesClienteEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/OutrasPartesCliente").WithTags("OutrasPartesCliente").RequireAuthorization();
        MapOutrasPartesClienteRoutes(group);
        return app;
    }

    private static void MapOutrasPartesClienteRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IOutrasPartesClienteService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("OutrasPartesCliente_GetAll").WithDisplayName("Get All OutrasPartesCliente");
        group.MapPost("/Filter", async (Filters.FilterOutrasPartesCliente filtro, string uri, IOutrasPartesClienteService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("OutrasPartesCliente_Filter").WithDisplayName("Filter OutrasPartesCliente");
        group.MapGet("/GetById/{id}", async (int id, string uri, IOutrasPartesClienteService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No OutrasPartesCliente found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OutrasPartesCliente_GetById").WithDisplayName("Get OutrasPartesCliente By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterOutrasPartesCliente? filtro, string uri, IOutrasPartesClienteService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("OutrasPartesCliente_GetListN").WithDisplayName("Get OutrasPartesCliente List N");
        group.MapPost("/AddAndUpdate", async (Models.OutrasPartesCliente regOutrasPartesCliente, string uri, IOutrasPartesClienteValidation validation, IOutrasPartesClienteWriter writer, ICidadeReader cidadeReader, IOutrasPartesClienteService service) =>
        {
            var result = await service.AddAndUpdate(regOutrasPartesCliente, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("OutrasPartesCliente_AddAndUpdate").WithDisplayName("Add or Update OutrasPartesCliente");
        group.MapDelete("/Delete", async (int id, string uri, IOutrasPartesClienteValidation validation, IOutrasPartesClienteWriter writer, ICidadeReader cidadeReader, IOutrasPartesClienteService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OutrasPartesCliente_Delete").WithDisplayName("Delete OutrasPartesCliente");
    }
}