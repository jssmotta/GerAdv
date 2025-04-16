#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class SetorEndpoints
{
    public static IEndpointRouteBuilder MapSetorEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Setor").WithTags("Setor").RequireAuthorization();
        MapSetorRoutes(group);
        return app;
    }

    private static void MapSetorRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ISetorValidation validation, ISetorWriter writer, ISetorService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Setor: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Setor_GetAll").WithDisplayName("Get All Setor");
        group.MapPost("/Filter", async (Filters.FilterSetor filtro, string uri, ISetorValidation validation, ISetorWriter writer, ISetorService service) =>
        {
            logger.Info("Setor: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Setor_Filter").WithDisplayName("Filter Setor");
        group.MapGet("/GetById/{id}", async (int id, string uri, ISetorValidation validation, ISetorWriter writer, ISetorService service, CancellationToken token) =>
        {
            logger.Info("Setor: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Setor found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Setor_GetById").WithDisplayName("Get Setor By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, ISetorValidation validation, ISetorWriter writer, ISetorService service) =>
        {
            logger.Info("Setor: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Setor found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Setor_GetByName").WithDisplayName("Get Setor By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterSetor? filtro, string uri, ISetorValidation validation, ISetorWriter writer, ISetorService service) =>
        {
            logger.Info("Setor: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Setor_GetListN").WithDisplayName("Get Setor List N");
        group.MapPost("/AddAndUpdate", async (Models.Setor regSetor, string uri, ISetorValidation validation, ISetorWriter writer, ISetorService service) =>
        {
            logger.LogInfo("Setor", "AddAndUpdate", $"regSetor = {regSetor}", uri);
            var result = await service.AddAndUpdate(regSetor, uri);
            if (result == null)
            {
                logger.LogWarn("Setor", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Setor_AddAndUpdate").WithDisplayName("Add or Update Setor");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, ISetorValidation validation, ISetorWriter writer, ISetorService service) =>
        {
            logger.LogInfo("Setor", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("Setor", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Setor_GetColumns").WithDisplayName("Get Setor Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, ISetorValidation validation, ISetorWriter writer, ISetorService service) =>
        {
            logger.LogInfo("Setor", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("Setor", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("Setor_UpdateColumns").WithDisplayName("Update Setor Columns");
        group.MapDelete("/Delete", async (int id, string uri, ISetorValidation validation, ISetorWriter writer, ISetorService service) =>
        {
            logger.LogInfo("Setor", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Setor", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Setor_Delete").WithDisplayName("Delete Setor");
    }
}