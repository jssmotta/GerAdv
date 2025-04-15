#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class CargosEscClassEndpoints
{
    public static IEndpointRouteBuilder MapCargosEscClassEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/CargosEscClass").WithTags("CargosEscClass").RequireAuthorization();
        MapCargosEscClassRoutes(group);
        return app;
    }

    private static void MapCargosEscClassRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ICargosEscClassValidation validation, ICargosEscClassWriter writer, ICargosEscClassService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("CargosEscClass: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("CargosEscClass_GetAll").WithDisplayName("Get All CargosEscClass");
        group.MapPost("/Filter", async (Filters.FilterCargosEscClass filtro, string uri, ICargosEscClassValidation validation, ICargosEscClassWriter writer, ICargosEscClassService service) =>
        {
            logger.Info("CargosEscClass: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("CargosEscClass_Filter").WithDisplayName("Filter CargosEscClass");
        group.MapGet("/GetById/{id}", async (int id, string uri, ICargosEscClassValidation validation, ICargosEscClassWriter writer, ICargosEscClassService service, CancellationToken token) =>
        {
            logger.Info("CargosEscClass: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No CargosEscClass found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("CargosEscClass_GetById").WithDisplayName("Get CargosEscClass By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, ICargosEscClassValidation validation, ICargosEscClassWriter writer, ICargosEscClassService service) =>
        {
            logger.Info("CargosEscClass: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No CargosEscClass found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("CargosEscClass_GetByName").WithDisplayName("Get CargosEscClass By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterCargosEscClass? filtro, string uri, ICargosEscClassValidation validation, ICargosEscClassWriter writer, ICargosEscClassService service) =>
        {
            logger.Info("CargosEscClass: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("CargosEscClass_GetListN").WithDisplayName("Get CargosEscClass List N");
        group.MapPost("/AddAndUpdate", async (Models.CargosEscClass regCargosEscClass, string uri, ICargosEscClassValidation validation, ICargosEscClassWriter writer, ICargosEscClassService service) =>
        {
            logger.LogInfo("CargosEscClass", "AddAndUpdate", $"regCargosEscClass = {regCargosEscClass}", uri);
            var result = await service.AddAndUpdate(regCargosEscClass, uri);
            if (result == null)
            {
                logger.LogWarn("CargosEscClass", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("CargosEscClass_AddAndUpdate").WithDisplayName("Add or Update CargosEscClass");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, ICargosEscClassValidation validation, ICargosEscClassWriter writer, ICargosEscClassService service) =>
        {
            logger.LogInfo("CargosEscClass", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("CargosEscClass", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("CargosEscClass_GetColumns").WithDisplayName("Get CargosEscClass Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, ICargosEscClassValidation validation, ICargosEscClassWriter writer, ICargosEscClassService service) =>
        {
            logger.LogInfo("CargosEscClass", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("CargosEscClass", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("CargosEscClass_UpdateColumns").WithDisplayName("Update CargosEscClass Columns");
        group.MapDelete("/Delete", async (int id, string uri, ICargosEscClassValidation validation, ICargosEscClassWriter writer, ICargosEscClassService service) =>
        {
            logger.LogInfo("CargosEscClass", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("CargosEscClass", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("CargosEscClass_Delete").WithDisplayName("Delete CargosEscClass");
    }
}