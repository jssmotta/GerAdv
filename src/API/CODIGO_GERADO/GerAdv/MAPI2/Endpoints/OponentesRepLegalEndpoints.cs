#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class OponentesRepLegalEndpoints
{
    public static IEndpointRouteBuilder MapOponentesRepLegalEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/OponentesRepLegal").WithTags("OponentesRepLegal").RequireAuthorization();
        MapOponentesRepLegalRoutes(group);
        return app;
    }

    private static void MapOponentesRepLegalRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IOponentesRepLegalValidation validation, IOponentesRepLegalWriter writer, IOponentesReader oponentesReader, IOponentesRepLegalService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("OponentesRepLegal: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("OponentesRepLegal_GetAll").WithDisplayName("Get All OponentesRepLegal");
        group.MapPost("/Filter", async (Filters.FilterOponentesRepLegal filtro, string uri, IOponentesRepLegalValidation validation, IOponentesRepLegalWriter writer, IOponentesReader oponentesReader, IOponentesRepLegalService service) =>
        {
            logger.Info("OponentesRepLegal: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("OponentesRepLegal_Filter").WithDisplayName("Filter OponentesRepLegal");
        group.MapGet("/GetById/{id}", async (int id, string uri, IOponentesRepLegalValidation validation, IOponentesRepLegalWriter writer, IOponentesReader oponentesReader, IOponentesRepLegalService service, CancellationToken token) =>
        {
            logger.Info("OponentesRepLegal: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No OponentesRepLegal found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OponentesRepLegal_GetById").WithDisplayName("Get OponentesRepLegal By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IOponentesRepLegalValidation validation, IOponentesRepLegalWriter writer, IOponentesReader oponentesReader, IOponentesRepLegalService service) =>
        {
            logger.Info("OponentesRepLegal: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No OponentesRepLegal found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OponentesRepLegal_GetByName").WithDisplayName("Get OponentesRepLegal By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterOponentesRepLegal? filtro, string uri, IOponentesRepLegalValidation validation, IOponentesRepLegalWriter writer, IOponentesReader oponentesReader, IOponentesRepLegalService service) =>
        {
            logger.Info("OponentesRepLegal: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("OponentesRepLegal_GetListN").WithDisplayName("Get OponentesRepLegal List N");
        group.MapPost("/AddAndUpdate", async (Models.OponentesRepLegal regOponentesRepLegal, string uri, IOponentesRepLegalValidation validation, IOponentesRepLegalWriter writer, IOponentesReader oponentesReader, IOponentesRepLegalService service) =>
        {
            logger.LogInfo("OponentesRepLegal", "AddAndUpdate", $"regOponentesRepLegal = {regOponentesRepLegal}", uri);
            var result = await service.AddAndUpdate(regOponentesRepLegal, uri);
            if (result == null)
            {
                logger.LogWarn("OponentesRepLegal", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("OponentesRepLegal_AddAndUpdate").WithDisplayName("Add or Update OponentesRepLegal");
        group.MapDelete("/Delete", async (int id, string uri, IOponentesRepLegalValidation validation, IOponentesRepLegalWriter writer, IOponentesReader oponentesReader, IOponentesRepLegalService service) =>
        {
            logger.LogInfo("OponentesRepLegal", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("OponentesRepLegal", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OponentesRepLegal_Delete").WithDisplayName("Delete OponentesRepLegal");
    }
}