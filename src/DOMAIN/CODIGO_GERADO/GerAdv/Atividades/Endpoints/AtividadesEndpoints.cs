#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class AtividadesEndpoints
{
    public static IEndpointRouteBuilder MapAtividadesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Atividades").WithTags("Atividades").RequireAuthorization();
        MapAtividadesRoutes(group);
        return app;
    }

    private static void MapAtividadesRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IAtividadesService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Atividades_GetAll").WithDisplayName("Get All Atividades");
        group.MapPost("/Filter", async (Filters.FilterAtividades filtro, string uri, IAtividadesService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Atividades_Filter").WithDisplayName("Filter Atividades");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAtividadesService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Atividades found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Atividades_GetById").WithDisplayName("Get Atividades By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterAtividades? filtro, string uri, IAtividadesService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Atividades_GetListN").WithDisplayName("Get Atividades List N");
        group.MapPost("/AddAndUpdate", async (Models.Atividades regAtividades, string uri, IAtividadesValidation validation, IAtividadesWriter writer, IAtividadesService service) =>
        {
            var result = await service.AddAndUpdate(regAtividades, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Atividades_AddAndUpdate").WithDisplayName("Add or Update Atividades");
        group.MapDelete("/Delete", async (int id, string uri, IAtividadesValidation validation, IAtividadesWriter writer, IAtividadesService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Atividades_Delete").WithDisplayName("Delete Atividades");
    }
}