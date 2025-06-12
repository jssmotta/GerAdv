#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class AcaoEndpoints
{
    public static IEndpointRouteBuilder MapAcaoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Acao").WithTags("Acao").RequireAuthorization();
        MapAcaoRoutes(group);
        return app;
    }

    private static void MapAcaoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IAcaoService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Acao_GetAll").WithDisplayName("Get All Acao");
        group.MapPost("/Filter", async (Filters.FilterAcao filtro, string uri, IAcaoService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Acao_Filter").WithDisplayName("Filter Acao");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAcaoService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Acao found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Acao_GetById").WithDisplayName("Get Acao By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterAcao? filtro, string uri, IAcaoService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Acao_GetListN").WithDisplayName("Get Acao List N");
        group.MapPost("/AddAndUpdate", async (Models.Acao regAcao, string uri, IAcaoValidation validation, IAcaoWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IAcaoService service) =>
        {
            var result = await service.AddAndUpdate(regAcao, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Acao_AddAndUpdate").WithDisplayName("Add or Update Acao");
        group.MapDelete("/Delete", async (int id, string uri, IAcaoValidation validation, IAcaoWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IAcaoService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Acao_Delete").WithDisplayName("Delete Acao");
    }
}