#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ProcessosObsReportEndpoints
{
    public static IEndpointRouteBuilder MapProcessosObsReportEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ProcessosObsReport").WithTags("ProcessosObsReport").RequireAuthorization();
        MapProcessosObsReportRoutes(group);
        return app;
    }

    private static void MapProcessosObsReportRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IProcessosObsReportValidation validation, IProcessosObsReportWriter writer, IProcessosReader processosReader, IHistoricoReader historicoReader, IProcessosObsReportService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("ProcessosObsReport: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProcessosObsReport_GetAll").WithDisplayName("Get All ProcessosObsReport");
        group.MapPost("/Filter", async (Filters.FilterProcessosObsReport filtro, string uri, IProcessosObsReportValidation validation, IProcessosObsReportWriter writer, IProcessosReader processosReader, IHistoricoReader historicoReader, IProcessosObsReportService service) =>
        {
            logger.Info("ProcessosObsReport: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProcessosObsReport_Filter").WithDisplayName("Filter ProcessosObsReport");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProcessosObsReportValidation validation, IProcessosObsReportWriter writer, IProcessosReader processosReader, IHistoricoReader historicoReader, IProcessosObsReportService service, CancellationToken token) =>
        {
            logger.Info("ProcessosObsReport: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ProcessosObsReport found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProcessosObsReport_GetById").WithDisplayName("Get ProcessosObsReport By Id");
        group.MapPost("/AddAndUpdate", async (Models.ProcessosObsReport regProcessosObsReport, string uri, IProcessosObsReportValidation validation, IProcessosObsReportWriter writer, IProcessosReader processosReader, IHistoricoReader historicoReader, IProcessosObsReportService service) =>
        {
            logger.LogInfo("ProcessosObsReport", "AddAndUpdate", $"regProcessosObsReport = {regProcessosObsReport}", uri);
            var result = await service.AddAndUpdate(regProcessosObsReport, uri);
            if (result == null)
            {
                logger.LogWarn("ProcessosObsReport", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProcessosObsReport_AddAndUpdate").WithDisplayName("Add or Update ProcessosObsReport");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IProcessosObsReportValidation validation, IProcessosObsReportWriter writer, IProcessosReader processosReader, IHistoricoReader historicoReader, IProcessosObsReportService service) =>
        {
            logger.LogInfo("ProcessosObsReport", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("ProcessosObsReport", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProcessosObsReport_GetColumns").WithDisplayName("Get ProcessosObsReport Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IProcessosObsReportValidation validation, IProcessosObsReportWriter writer, IProcessosReader processosReader, IHistoricoReader historicoReader, IProcessosObsReportService service) =>
        {
            logger.LogInfo("ProcessosObsReport", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("ProcessosObsReport", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("ProcessosObsReport_UpdateColumns").WithDisplayName("Update ProcessosObsReport Columns");
        group.MapDelete("/Delete", async (int id, string uri, IProcessosObsReportValidation validation, IProcessosObsReportWriter writer, IProcessosReader processosReader, IHistoricoReader historicoReader, IProcessosObsReportService service) =>
        {
            logger.LogInfo("ProcessosObsReport", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("ProcessosObsReport", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProcessosObsReport_Delete").WithDisplayName("Delete ProcessosObsReport");
    }
}