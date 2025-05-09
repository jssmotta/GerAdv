﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class EndTitEndpoints
{
    public static IEndpointRouteBuilder MapEndTitEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/EndTit").WithTags("EndTit").RequireAuthorization();
        MapEndTitRoutes(group);
        return app;
    }

    private static void MapEndTitRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IEndTitValidation validation, IEndTitWriter writer, IEndTitService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("EndTit: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("EndTit_GetAll").WithDisplayName("Get All EndTit");
        group.MapPost("/Filter", async (Filters.FilterEndTit filtro, string uri, IEndTitValidation validation, IEndTitWriter writer, IEndTitService service) =>
        {
            logger.Info("EndTit: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("EndTit_Filter").WithDisplayName("Filter EndTit");
        group.MapGet("/GetById/{id}", async (int id, string uri, IEndTitValidation validation, IEndTitWriter writer, IEndTitService service, CancellationToken token) =>
        {
            logger.Info("EndTit: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No EndTit found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("EndTit_GetById").WithDisplayName("Get EndTit By Id");
        group.MapPost("/AddAndUpdate", async (Models.EndTit regEndTit, string uri, IEndTitValidation validation, IEndTitWriter writer, IEndTitService service) =>
        {
            logger.LogInfo("EndTit", "AddAndUpdate", $"regEndTit = {regEndTit}", uri);
            var result = await service.AddAndUpdate(regEndTit, uri);
            if (result == null)
            {
                logger.LogWarn("EndTit", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("EndTit_AddAndUpdate").WithDisplayName("Add or Update EndTit");
        group.MapDelete("/Delete", async (int id, string uri, IEndTitValidation validation, IEndTitWriter writer, IEndTitService service) =>
        {
            logger.LogInfo("EndTit", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("EndTit", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("EndTit_Delete").WithDisplayName("Delete EndTit");
    }
}