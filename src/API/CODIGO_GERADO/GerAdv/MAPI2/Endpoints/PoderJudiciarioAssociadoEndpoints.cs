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
        group.MapGet("/GetAll", async (int max, string uri, IPoderJudiciarioAssociadoValidation validation, IPoderJudiciarioAssociadoWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, ITribunalReader tribunalReader, IForoReader foroReader, IPoderJudiciarioAssociadoService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("PoderJudiciarioAssociado: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("PoderJudiciarioAssociado_GetAll").WithDisplayName("Get All PoderJudiciarioAssociado");
        group.MapPost("/Filter", async (Filters.FilterPoderJudiciarioAssociado filtro, string uri, IPoderJudiciarioAssociadoValidation validation, IPoderJudiciarioAssociadoWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, ITribunalReader tribunalReader, IForoReader foroReader, IPoderJudiciarioAssociadoService service) =>
        {
            logger.Info("PoderJudiciarioAssociado: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("PoderJudiciarioAssociado_Filter").WithDisplayName("Filter PoderJudiciarioAssociado");
        group.MapGet("/GetById/{id}", async (int id, string uri, IPoderJudiciarioAssociadoValidation validation, IPoderJudiciarioAssociadoWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, ITribunalReader tribunalReader, IForoReader foroReader, IPoderJudiciarioAssociadoService service, CancellationToken token) =>
        {
            logger.Info("PoderJudiciarioAssociado: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No PoderJudiciarioAssociado found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("PoderJudiciarioAssociado_GetById").WithDisplayName("Get PoderJudiciarioAssociado By Id");
        group.MapPost("/AddAndUpdate", async (Models.PoderJudiciarioAssociado regPoderJudiciarioAssociado, string uri, IPoderJudiciarioAssociadoValidation validation, IPoderJudiciarioAssociadoWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, ITribunalReader tribunalReader, IForoReader foroReader, IPoderJudiciarioAssociadoService service) =>
        {
            logger.LogInfo("PoderJudiciarioAssociado", "AddAndUpdate", $"regPoderJudiciarioAssociado = {regPoderJudiciarioAssociado}", uri);
            var result = await service.AddAndUpdate(regPoderJudiciarioAssociado, uri);
            if (result == null)
            {
                logger.LogWarn("PoderJudiciarioAssociado", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("PoderJudiciarioAssociado_AddAndUpdate").WithDisplayName("Add or Update PoderJudiciarioAssociado");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IPoderJudiciarioAssociadoValidation validation, IPoderJudiciarioAssociadoWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, ITribunalReader tribunalReader, IForoReader foroReader, IPoderJudiciarioAssociadoService service) =>
        {
            logger.LogInfo("PoderJudiciarioAssociado", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("PoderJudiciarioAssociado", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("PoderJudiciarioAssociado_GetColumns").WithDisplayName("Get PoderJudiciarioAssociado Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IPoderJudiciarioAssociadoValidation validation, IPoderJudiciarioAssociadoWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, ITribunalReader tribunalReader, IForoReader foroReader, IPoderJudiciarioAssociadoService service) =>
        {
            logger.LogInfo("PoderJudiciarioAssociado", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("PoderJudiciarioAssociado", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("PoderJudiciarioAssociado_UpdateColumns").WithDisplayName("Update PoderJudiciarioAssociado Columns");
        group.MapDelete("/Delete", async (int id, string uri, IPoderJudiciarioAssociadoValidation validation, IPoderJudiciarioAssociadoWriter writer, IJusticaReader justicaReader, IAreaReader areaReader, ITribunalReader tribunalReader, IForoReader foroReader, IPoderJudiciarioAssociadoService service) =>
        {
            logger.LogInfo("PoderJudiciarioAssociado", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("PoderJudiciarioAssociado", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("PoderJudiciarioAssociado_Delete").WithDisplayName("Delete PoderJudiciarioAssociado");
    }
}