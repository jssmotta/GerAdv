#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class EnderecosEndpoints
{
    public static IEndpointRouteBuilder MapEnderecosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Enderecos").WithTags("Enderecos").RequireAuthorization();
        MapEnderecosRoutes(group);
        return app;
    }

    private static void MapEnderecosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IEnderecosService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Enderecos_GetAll").WithDisplayName("Get All Enderecos");
        group.MapPost("/Filter", async (Filters.FilterEnderecos filtro, string uri, IEnderecosService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Enderecos_Filter").WithDisplayName("Filter Enderecos");
        group.MapGet("/GetById/{id}", async (int id, string uri, IEnderecosService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Enderecos found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Enderecos_GetById").WithDisplayName("Get Enderecos By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterEnderecos? filtro, string uri, IEnderecosService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Enderecos_GetListN").WithDisplayName("Get Enderecos List N");
        group.MapPost("/AddAndUpdate", async (Models.Enderecos regEnderecos, string uri, IEnderecosValidation validation, IEnderecosWriter writer, ICidadeReader cidadeReader, IEnderecosService service) =>
        {
            var result = await service.AddAndUpdate(regEnderecos, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Enderecos_AddAndUpdate").WithDisplayName("Add or Update Enderecos");
        group.MapDelete("/Delete", async (int id, string uri, IEnderecosValidation validation, IEnderecosWriter writer, ICidadeReader cidadeReader, IEnderecosService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Enderecos_Delete").WithDisplayName("Delete Enderecos");
    }
}