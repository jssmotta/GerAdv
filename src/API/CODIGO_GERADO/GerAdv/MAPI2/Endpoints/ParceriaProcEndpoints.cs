﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

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