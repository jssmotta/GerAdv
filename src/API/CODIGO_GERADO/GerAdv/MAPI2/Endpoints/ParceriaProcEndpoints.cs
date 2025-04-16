#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ParceriaProcEndpoints
{
    public static IEndpointRouteBuilder MapParceriaProcEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ParceriaProc").WithTags("ParceriaProc").RequireAuthorization();
        MapParceriaProcRoutes(group);
        return app;
    }

    private static void MapParceriaProcRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IParceriaProcValidation validation, IParceriaProcWriter writer, IAdvogadosReader advogadosReader, IProcessosReader processosReader, IParceriaProcService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("ParceriaProc: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ParceriaProc_GetAll").WithDisplayName("Get All ParceriaProc");
        group.MapPost("/Filter", async (Filters.FilterParceriaProc filtro, string uri, IParceriaProcValidation validation, IParceriaProcWriter writer, IAdvogadosReader advogadosReader, IProcessosReader processosReader, IParceriaProcService service) =>
        {
            logger.Info("ParceriaProc: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ParceriaProc_Filter").WithDisplayName("Filter ParceriaProc");
        group.MapGet("/GetById/{id}", async (int id, string uri, IParceriaProcValidation validation, IParceriaProcWriter writer, IAdvogadosReader advogadosReader, IProcessosReader processosReader, IParceriaProcService service, CancellationToken token) =>
        {
            logger.Info("ParceriaProc: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ParceriaProc found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ParceriaProc_GetById").WithDisplayName("Get ParceriaProc By Id");
        group.MapPost("/AddAndUpdate", async (Models.ParceriaProc regParceriaProc, string uri, IParceriaProcValidation validation, IParceriaProcWriter writer, IAdvogadosReader advogadosReader, IProcessosReader processosReader, IParceriaProcService service) =>
        {
            logger.LogInfo("ParceriaProc", "AddAndUpdate", $"regParceriaProc = {regParceriaProc}", uri);
            var result = await service.AddAndUpdate(regParceriaProc, uri);
            if (result == null)
            {
                logger.LogWarn("ParceriaProc", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ParceriaProc_AddAndUpdate").WithDisplayName("Add or Update ParceriaProc");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IParceriaProcValidation validation, IParceriaProcWriter writer, IAdvogadosReader advogadosReader, IProcessosReader processosReader, IParceriaProcService service) =>
        {
            logger.LogInfo("ParceriaProc", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("ParceriaProc", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ParceriaProc_GetColumns").WithDisplayName("Get ParceriaProc Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IParceriaProcValidation validation, IParceriaProcWriter writer, IAdvogadosReader advogadosReader, IProcessosReader processosReader, IParceriaProcService service) =>
        {
            logger.LogInfo("ParceriaProc", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("ParceriaProc", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("ParceriaProc_UpdateColumns").WithDisplayName("Update ParceriaProc Columns");
        group.MapDelete("/Delete", async (int id, string uri, IParceriaProcValidation validation, IParceriaProcWriter writer, IAdvogadosReader advogadosReader, IProcessosReader processosReader, IParceriaProcService service) =>
        {
            logger.LogInfo("ParceriaProc", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("ParceriaProc", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ParceriaProc_Delete").WithDisplayName("Delete ParceriaProc");
    }
}