#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class SituacaoEndpoints
{
    public static IEndpointRouteBuilder MapSituacaoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Situacao").WithTags("Situacao").RequireAuthorization();
        MapSituacaoRoutes(group);
        return app;
    }

    private static void MapSituacaoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ISituacaoService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Situacao_GetAll").WithDisplayName("Get All Situacao");
        group.MapPost("/Filter", async (Filters.FilterSituacao filtro, string uri, ISituacaoService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Situacao_Filter").WithDisplayName("Filter Situacao");
        group.MapGet("/GetById/{id}", async (int id, string uri, ISituacaoService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Situacao found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Situacao_GetById").WithDisplayName("Get Situacao By Id");
        group.MapPost("/AddAndUpdate", async (Models.Situacao regSituacao, string uri, ISituacaoValidation validation, ISituacaoWriter writer, ISituacaoService service) =>
        {
            var result = await service.AddAndUpdate(regSituacao, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Situacao_AddAndUpdate").WithDisplayName("Add or Update Situacao");
        group.MapDelete("/Delete", async (int id, string uri, ISituacaoValidation validation, ISituacaoWriter writer, ISituacaoService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Situacao_Delete").WithDisplayName("Delete Situacao");
    }
}