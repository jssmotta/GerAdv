#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class LivroCaixaClientesEndpoints
{
    public static IEndpointRouteBuilder MapLivroCaixaClientesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/LivroCaixaClientes").WithTags("LivroCaixaClientes").RequireAuthorization();
        MapLivroCaixaClientesRoutes(group);
        return app;
    }

    private static void MapLivroCaixaClientesRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ILivroCaixaClientesService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("LivroCaixaClientes_GetAll").WithDisplayName("Get All LivroCaixaClientes");
        group.MapPost("/Filter", async (Filters.FilterLivroCaixaClientes filtro, string uri, ILivroCaixaClientesService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("LivroCaixaClientes_Filter").WithDisplayName("Filter LivroCaixaClientes");
        group.MapGet("/GetById/{id}", async (int id, string uri, ILivroCaixaClientesService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No LivroCaixaClientes found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("LivroCaixaClientes_GetById").WithDisplayName("Get LivroCaixaClientes By Id");
        group.MapPost("/AddAndUpdate", async (Models.LivroCaixaClientes regLivroCaixaClientes, string uri, ILivroCaixaClientesValidation validation, ILivroCaixaClientesWriter writer, ILivroCaixaReader livrocaixaReader, IClientesReader clientesReader, ILivroCaixaClientesService service) =>
        {
            var result = await service.AddAndUpdate(regLivroCaixaClientes, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("LivroCaixaClientes_AddAndUpdate").WithDisplayName("Add or Update LivroCaixaClientes");
        group.MapDelete("/Delete", async (int id, string uri, ILivroCaixaClientesValidation validation, ILivroCaixaClientesWriter writer, ILivroCaixaReader livrocaixaReader, IClientesReader clientesReader, ILivroCaixaClientesService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("LivroCaixaClientes_Delete").WithDisplayName("Delete LivroCaixaClientes");
    }
}