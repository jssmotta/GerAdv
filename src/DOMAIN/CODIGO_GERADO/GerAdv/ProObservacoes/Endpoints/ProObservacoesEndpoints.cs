#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ProObservacoesEndpoints
{
    public static IEndpointRouteBuilder MapProObservacoesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ProObservacoes").WithTags("ProObservacoes").RequireAuthorization();
        MapProObservacoesRoutes(group);
        return app;
    }

    private static void MapProObservacoesRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IProObservacoesService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProObservacoes_GetAll").WithDisplayName("Get All ProObservacoes");
        group.MapPost("/Filter", async (Filters.FilterProObservacoes filtro, string uri, IProObservacoesService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProObservacoes_Filter").WithDisplayName("Filter ProObservacoes");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProObservacoesService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ProObservacoes found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProObservacoes_GetById").WithDisplayName("Get ProObservacoes By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterProObservacoes? filtro, string uri, IProObservacoesService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("ProObservacoes_GetListN").WithDisplayName("Get ProObservacoes List N");
        group.MapPost("/AddAndUpdate", async (Models.ProObservacoes regProObservacoes, string uri, IProObservacoesValidation validation, IProObservacoesWriter writer, IProcessosReader processosReader, IProObservacoesService service) =>
        {
            var result = await service.AddAndUpdate(regProObservacoes, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProObservacoes_AddAndUpdate").WithDisplayName("Add or Update ProObservacoes");
        group.MapDelete("/Delete", async (int id, string uri, IProObservacoesValidation validation, IProObservacoesWriter writer, IProcessosReader processosReader, IProObservacoesService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProObservacoes_Delete").WithDisplayName("Delete ProObservacoes");
    }
}