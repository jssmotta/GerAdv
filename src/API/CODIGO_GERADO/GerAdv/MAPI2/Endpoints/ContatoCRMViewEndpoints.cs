#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ContatoCRMViewEndpoints
{
    public static IEndpointRouteBuilder MapContatoCRMViewEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ContatoCRMView").WithTags("ContatoCRMView").RequireAuthorization();
        MapContatoCRMViewRoutes(group);
        return app;
    }

    private static void MapContatoCRMViewRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IContatoCRMViewValidation validation, IContatoCRMViewWriter writer, IContatoCRMViewService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("ContatoCRMView: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ContatoCRMView_GetAll").WithDisplayName("Get All ContatoCRMView");
        group.MapPost("/Filter", async (Filters.FilterContatoCRMView filtro, string uri, IContatoCRMViewValidation validation, IContatoCRMViewWriter writer, IContatoCRMViewService service) =>
        {
            logger.Info("ContatoCRMView: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ContatoCRMView_Filter").WithDisplayName("Filter ContatoCRMView");
        group.MapGet("/GetById/{id}", async (int id, string uri, IContatoCRMViewValidation validation, IContatoCRMViewWriter writer, IContatoCRMViewService service, CancellationToken token) =>
        {
            logger.Info("ContatoCRMView: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ContatoCRMView found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ContatoCRMView_GetById").WithDisplayName("Get ContatoCRMView By Id");
        group.MapPost("/AddAndUpdate", async (Models.ContatoCRMView regContatoCRMView, string uri, IContatoCRMViewValidation validation, IContatoCRMViewWriter writer, IContatoCRMViewService service) =>
        {
            logger.LogInfo("ContatoCRMView", "AddAndUpdate", $"regContatoCRMView = {regContatoCRMView}", uri);
            var result = await service.AddAndUpdate(regContatoCRMView, uri);
            if (result == null)
            {
                logger.LogWarn("ContatoCRMView", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ContatoCRMView_AddAndUpdate").WithDisplayName("Add or Update ContatoCRMView");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IContatoCRMViewValidation validation, IContatoCRMViewWriter writer, IContatoCRMViewService service) =>
        {
            logger.LogInfo("ContatoCRMView", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("ContatoCRMView", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ContatoCRMView_GetColumns").WithDisplayName("Get ContatoCRMView Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IContatoCRMViewValidation validation, IContatoCRMViewWriter writer, IContatoCRMViewService service) =>
        {
            logger.LogInfo("ContatoCRMView", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("ContatoCRMView", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("ContatoCRMView_UpdateColumns").WithDisplayName("Update ContatoCRMView Columns");
        group.MapDelete("/Delete", async (int id, string uri, IContatoCRMViewValidation validation, IContatoCRMViewWriter writer, IContatoCRMViewService service) =>
        {
            logger.LogInfo("ContatoCRMView", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("ContatoCRMView", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ContatoCRMView_Delete").WithDisplayName("Delete ContatoCRMView");
    }
}