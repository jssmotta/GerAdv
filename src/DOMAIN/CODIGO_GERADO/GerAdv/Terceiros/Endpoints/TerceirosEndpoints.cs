#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class TerceirosEndpoints
{
    public static IEndpointRouteBuilder MapTerceirosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Terceiros").WithTags("Terceiros").RequireAuthorization();
        MapTerceirosRoutes(group);
        return app;
    }

    private static void MapTerceirosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ITerceirosService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Terceiros_GetAll").WithDisplayName("Get All Terceiros");
        group.MapPost("/Filter", async (Filters.FilterTerceiros filtro, string uri, ITerceirosService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Terceiros_Filter").WithDisplayName("Filter Terceiros");
        group.MapGet("/GetById/{id}", async (int id, string uri, ITerceirosService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Terceiros found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Terceiros_GetById").WithDisplayName("Get Terceiros By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterTerceiros? filtro, string uri, ITerceirosService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Terceiros_GetListN").WithDisplayName("Get Terceiros List N");
        group.MapPost("/AddAndUpdate", async (Models.Terceiros regTerceiros, string uri, ITerceirosValidation validation, ITerceirosWriter writer, IProcessosReader processosReader, IPosicaoOutrasPartesReader posicaooutraspartesReader, ICidadeReader cidadeReader, ITerceirosService service) =>
        {
            var result = await service.AddAndUpdate(regTerceiros, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Terceiros_AddAndUpdate").WithDisplayName("Add or Update Terceiros");
        group.MapDelete("/Delete", async (int id, string uri, ITerceirosValidation validation, ITerceirosWriter writer, IProcessosReader processosReader, IPosicaoOutrasPartesReader posicaooutraspartesReader, ICidadeReader cidadeReader, ITerceirosService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Terceiros_Delete").WithDisplayName("Delete Terceiros");
    }
}