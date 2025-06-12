#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ViaRecebimentoEndpoints
{
    public static IEndpointRouteBuilder MapViaRecebimentoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ViaRecebimento").WithTags("ViaRecebimento").RequireAuthorization();
        MapViaRecebimentoRoutes(group);
        return app;
    }

    private static void MapViaRecebimentoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IViaRecebimentoService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ViaRecebimento_GetAll").WithDisplayName("Get All ViaRecebimento");
        group.MapPost("/Filter", async (Filters.FilterViaRecebimento filtro, string uri, IViaRecebimentoService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ViaRecebimento_Filter").WithDisplayName("Filter ViaRecebimento");
        group.MapGet("/GetById/{id}", async (int id, string uri, IViaRecebimentoService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ViaRecebimento found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ViaRecebimento_GetById").WithDisplayName("Get ViaRecebimento By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterViaRecebimento? filtro, string uri, IViaRecebimentoService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("ViaRecebimento_GetListN").WithDisplayName("Get ViaRecebimento List N");
        group.MapPost("/AddAndUpdate", async (Models.ViaRecebimento regViaRecebimento, string uri, IViaRecebimentoValidation validation, IViaRecebimentoWriter writer, IViaRecebimentoService service) =>
        {
            var result = await service.AddAndUpdate(regViaRecebimento, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ViaRecebimento_AddAndUpdate").WithDisplayName("Add or Update ViaRecebimento");
        group.MapDelete("/Delete", async (int id, string uri, IViaRecebimentoValidation validation, IViaRecebimentoWriter writer, IViaRecebimentoService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ViaRecebimento_Delete").WithDisplayName("Delete ViaRecebimento");
    }
}