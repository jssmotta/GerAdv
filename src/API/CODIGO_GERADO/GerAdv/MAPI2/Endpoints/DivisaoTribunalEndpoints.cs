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
        group.MapGet("/GetAll", async (int max, string uri, IDivisaoTribunalValidation validation, IDivisaoTribunalWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IForoReader foroReader, ITribunalReader tribunalReader, IDivisaoTribunalService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("DivisaoTribunal: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("DivisaoTribunal_GetAll").WithDisplayName("Get All DivisaoTribunal");
        group.MapPost("/Filter", async (Filters.FilterDivisaoTribunal filtro, string uri, IDivisaoTribunalValidation validation, IDivisaoTribunalWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IForoReader foroReader, ITribunalReader tribunalReader, IDivisaoTribunalService service) =>
        {
            logger.Info("DivisaoTribunal: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("DivisaoTribunal_Filter").WithDisplayName("Filter DivisaoTribunal");
        group.MapGet("/GetById/{id}", async (int id, string uri, IDivisaoTribunalValidation validation, IDivisaoTribunalWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IForoReader foroReader, ITribunalReader tribunalReader, IDivisaoTribunalService service, CancellationToken token) =>
        {
            logger.Info("DivisaoTribunal: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No DivisaoTribunal found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("DivisaoTribunal_GetById").WithDisplayName("Get DivisaoTribunal By Id");
        group.MapPost("/AddAndUpdate", async (Models.DivisaoTribunal regDivisaoTribunal, string uri, IDivisaoTribunalValidation validation, IDivisaoTribunalWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IForoReader foroReader, ITribunalReader tribunalReader, IDivisaoTribunalService service) =>
        {
            logger.LogInfo("DivisaoTribunal", "AddAndUpdate", $"regDivisaoTribunal = {regDivisaoTribunal}", uri);
            var result = await service.AddAndUpdate(regDivisaoTribunal, uri);
            if (result == null)
            {
                logger.LogWarn("DivisaoTribunal", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("DivisaoTribunal_AddAndUpdate").WithDisplayName("Add or Update DivisaoTribunal");
        group.MapDelete("/Delete", async (int id, string uri, IDivisaoTribunalValidation validation, IDivisaoTribunalWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, IForoReader foroReader, ITribunalReader tribunalReader, IDivisaoTribunalService service) =>
        {
            logger.LogInfo("DivisaoTribunal", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("DivisaoTribunal", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("DivisaoTribunal_Delete").WithDisplayName("Delete DivisaoTribunal");
    }
}