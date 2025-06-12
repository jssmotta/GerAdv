#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class DivisaoTribunalEndpoints
{
    public static IEndpointRouteBuilder MapDivisaoTribunalEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/DivisaoTribunal").WithTags("DivisaoTribunal").RequireAuthorization();
        MapDivisaoTribunalRoutes(group);
        return app;
    }

    private static void MapDivisaoTribunalRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IDivisaoTribunalService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("DivisaoTribunal_GetAll").WithDisplayName("Get All DivisaoTribunal");
        group.MapPost("/Filter", async (Filters.FilterDivisaoTribunal filtro, string uri, IDivisaoTribunalService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("DivisaoTribunal_Filter").WithDisplayName("Filter DivisaoTribunal");
        group.MapGet("/GetById/{id}", async (int id, string uri, IDivisaoTribunalService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No DivisaoTribunal found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("DivisaoTribunal_GetById").WithDisplayName("Get DivisaoTribunal By Id");
        group.MapPost("/AddAndUpdate", async (Models.DivisaoTribunal regDivisaoTribunal, string uri, IDivisaoTribunalValidation validation, IDivisaoTribunalWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, ICidadeReader cidadeReader, IForoReader foroReader, ITribunalReader tribunalReader, IDivisaoTribunalService service) =>
        {
            var result = await service.AddAndUpdate(regDivisaoTribunal, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("DivisaoTribunal_AddAndUpdate").WithDisplayName("Add or Update DivisaoTribunal");
        group.MapDelete("/Delete", async (int id, string uri, IDivisaoTribunalValidation validation, IDivisaoTribunalWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, ICidadeReader cidadeReader, IForoReader foroReader, ITribunalReader tribunalReader, IDivisaoTribunalService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("DivisaoTribunal_Delete").WithDisplayName("Delete DivisaoTribunal");
    }
}