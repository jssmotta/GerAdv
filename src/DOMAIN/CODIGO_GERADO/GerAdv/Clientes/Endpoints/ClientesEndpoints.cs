#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ClientesEndpoints
{
    public static IEndpointRouteBuilder MapClientesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Clientes").WithTags("Clientes").RequireAuthorization();
        MapClientesRoutes(group);
        return app;
    }

    private static void MapClientesRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IClientesService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Clientes_GetAll").WithDisplayName("Get All Clientes");
        group.MapPost("/Filter", async (Filters.FilterClientes filtro, string uri, IClientesService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Clientes_Filter").WithDisplayName("Filter Clientes");
        group.MapGet("/GetById/{id}", async (int id, string uri, IClientesService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Clientes found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Clientes_GetById").WithDisplayName("Get Clientes By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterClientes? filtro, string uri, IClientesService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Clientes_GetListN").WithDisplayName("Get Clientes List N");
        group.MapPost("/AddAndUpdate", async (Models.Clientes regClientes, string uri, IClientesValidation validation, IClientesWriter writer, ICidadeReader cidadeReader, IRegimeTributacaoReader regimetributacaoReader, IEnquadramentoEmpresaReader enquadramentoempresaReader, IClientesService service) =>
        {
            var result = await service.AddAndUpdate(regClientes, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Clientes_AddAndUpdate").WithDisplayName("Add or Update Clientes");
        group.MapDelete("/Delete", async (int id, string uri, IClientesValidation validation, IClientesWriter writer, ICidadeReader cidadeReader, IRegimeTributacaoReader regimetributacaoReader, IEnquadramentoEmpresaReader enquadramentoempresaReader, IClientesService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Clientes_Delete").WithDisplayName("Delete Clientes");
    }
}