#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class LigacoesEndpoints
{
    public static IEndpointRouteBuilder MapLigacoesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Ligacoes").WithTags("Ligacoes").RequireAuthorization();
        MapLigacoesRoutes(group);
        return app;
    }

    private static void MapLigacoesRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ILigacoesService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Ligacoes_GetAll").WithDisplayName("Get All Ligacoes");
        group.MapPost("/Filter", async (Filters.FilterLigacoes filtro, string uri, ILigacoesService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Ligacoes_Filter").WithDisplayName("Filter Ligacoes");
        group.MapGet("/GetById/{id}", async (int id, string uri, ILigacoesService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Ligacoes found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Ligacoes_GetById").WithDisplayName("Get Ligacoes By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterLigacoes? filtro, string uri, ILigacoesService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Ligacoes_GetListN").WithDisplayName("Get Ligacoes List N");
        group.MapPost("/AddAndUpdate", async (Models.Ligacoes regLigacoes, string uri, ILigacoesValidation validation, ILigacoesWriter writer, IClientesReader clientesReader, IRamalReader ramalReader, IProcessosReader processosReader, ILigacoesService service) =>
        {
            var result = await service.AddAndUpdate(regLigacoes, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Ligacoes_AddAndUpdate").WithDisplayName("Add or Update Ligacoes");
        group.MapDelete("/Delete", async (int id, string uri, ILigacoesValidation validation, ILigacoesWriter writer, IClientesReader clientesReader, IRamalReader ramalReader, IProcessosReader processosReader, ILigacoesService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Ligacoes_Delete").WithDisplayName("Delete Ligacoes");
    }
}