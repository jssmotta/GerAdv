﻿#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class Apenso2Endpoints
{
    public static IEndpointRouteBuilder MapApenso2Endpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Apenso2").WithTags("Apenso2").RequireAuthorization();
        MapApenso2Routes(group);
        return app;
    }

    private static void MapApenso2Routes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IApenso2Validation validation, IApenso2Writer writer, IProcessosReader processosReader, IApenso2Service service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Apenso2: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Apenso2_GetAll").WithDisplayName("Get All Apenso2");
        group.MapPost("/Filter", async (Filters.FilterApenso2 filtro, string uri, IApenso2Validation validation, IApenso2Writer writer, IProcessosReader processosReader, IApenso2Service service) =>
        {
            logger.Info("Apenso2: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Apenso2_Filter").WithDisplayName("Filter Apenso2");
        group.MapGet("/GetById/{id}", async (int id, string uri, IApenso2Validation validation, IApenso2Writer writer, IProcessosReader processosReader, IApenso2Service service, CancellationToken token) =>
        {
            logger.Info("Apenso2: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Apenso2 found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Apenso2_GetById").WithDisplayName("Get Apenso2 By Id");
        group.MapPost("/AddAndUpdate", async (Models.Apenso2 regApenso2, string uri, IApenso2Validation validation, IApenso2Writer writer, IProcessosReader processosReader, IApenso2Service service) =>
        {
            logger.LogInfo("Apenso2", "AddAndUpdate", $"regApenso2 = {regApenso2}", uri);
            var result = await service.AddAndUpdate(regApenso2, uri);
            if (result == null)
            {
                logger.LogWarn("Apenso2", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Apenso2_AddAndUpdate").WithDisplayName("Add or Update Apenso2");
        group.MapDelete("/Delete", async (int id, string uri, IApenso2Validation validation, IApenso2Writer writer, IProcessosReader processosReader, IApenso2Service service) =>
        {
            logger.LogInfo("Apenso2", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Apenso2", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Apenso2_Delete").WithDisplayName("Delete Apenso2");
    }
}