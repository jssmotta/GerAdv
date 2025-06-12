#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class PoderJudiciarioAssociadoEndpoints
{
    public static IEndpointRouteBuilder MapPoderJudiciarioAssociadoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/PoderJudiciarioAssociado").WithTags("PoderJudiciarioAssociado").RequireAuthorization();
        MapPoderJudiciarioAssociadoRoutes(group);
        return app;
    }

    private static void MapPoderJudiciarioAssociadoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IPoderJudiciarioAssociadoService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("PoderJudiciarioAssociado_GetAll").WithDisplayName("Get All PoderJudiciarioAssociado");
        group.MapPost("/Filter", async (Filters.FilterPoderJudiciarioAssociado filtro, string uri, IPoderJudiciarioAssociadoService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("PoderJudiciarioAssociado_Filter").WithDisplayName("Filter PoderJudiciarioAssociado");
        group.MapGet("/GetById/{id}", async (int id, string uri, IPoderJudiciarioAssociadoService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No PoderJudiciarioAssociado found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("PoderJudiciarioAssociado_GetById").WithDisplayName("Get PoderJudiciarioAssociado By Id");
        group.MapPost("/AddAndUpdate", async (Models.PoderJudiciarioAssociado regPoderJudiciarioAssociado, string uri, IPoderJudiciarioAssociadoValidation validation, IPoderJudiciarioAssociadoWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, ITribunalReader tribunalReader, IForoReader foroReader, ICidadeReader cidadeReader, IPoderJudiciarioAssociadoService service) =>
        {
            var result = await service.AddAndUpdate(regPoderJudiciarioAssociado, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("PoderJudiciarioAssociado_AddAndUpdate").WithDisplayName("Add or Update PoderJudiciarioAssociado");
        group.MapDelete("/Delete", async (int id, string uri, IPoderJudiciarioAssociadoValidation validation, IPoderJudiciarioAssociadoWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, ITribunalReader tribunalReader, IForoReader foroReader, ICidadeReader cidadeReader, IPoderJudiciarioAssociadoService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("PoderJudiciarioAssociado_Delete").WithDisplayName("Delete PoderJudiciarioAssociado");
    }
}