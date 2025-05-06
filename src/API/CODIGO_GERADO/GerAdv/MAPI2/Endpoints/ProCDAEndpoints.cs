#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ProCDAEndpoints
{
    public static IEndpointRouteBuilder MapProCDAEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ProCDA").WithTags("ProCDA").RequireAuthorization();
        MapProCDARoutes(group);
        return app;
    }

    private static void MapProCDARoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IProCDAValidation validation, IProCDAWriter writer, IProcessosReader processosReader, IProCDAService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("ProCDA: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProCDA_GetAll").WithDisplayName("Get All ProCDA");
        group.MapPost("/Filter", async (Filters.FilterProCDA filtro, string uri, IProCDAValidation validation, IProCDAWriter writer, IProcessosReader processosReader, IProCDAService service) =>
        {
            logger.Info("ProCDA: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProCDA_Filter").WithDisplayName("Filter ProCDA");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProCDAValidation validation, IProCDAWriter writer, IProcessosReader processosReader, IProCDAService service, CancellationToken token) =>
        {
            logger.Info("ProCDA: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ProCDA found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProCDA_GetById").WithDisplayName("Get ProCDA By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IProCDAValidation validation, IProCDAWriter writer, IProcessosReader processosReader, IProCDAService service) =>
        {
            logger.Info("ProCDA: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No ProCDA found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProCDA_GetByName").WithDisplayName("Get ProCDA By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterProCDA? filtro, string uri, IProCDAValidation validation, IProCDAWriter writer, IProcessosReader processosReader, IProCDAService service) =>
        {
            logger.Info("ProCDA: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("ProCDA_GetListN").WithDisplayName("Get ProCDA List N");
        group.MapPost("/AddAndUpdate", async (Models.ProCDA regProCDA, string uri, IProCDAValidation validation, IProCDAWriter writer, IProcessosReader processosReader, IProCDAService service) =>
        {
            logger.LogInfo("ProCDA", "AddAndUpdate", $"regProCDA = {regProCDA}", uri);
            var result = await service.AddAndUpdate(regProCDA, uri);
            if (result == null)
            {
                logger.LogWarn("ProCDA", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProCDA_AddAndUpdate").WithDisplayName("Add or Update ProCDA");
        group.MapDelete("/Delete", async (int id, string uri, IProCDAValidation validation, IProCDAWriter writer, IProcessosReader processosReader, IProCDAService service) =>
        {
            logger.LogInfo("ProCDA", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("ProCDA", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProCDA_Delete").WithDisplayName("Delete ProCDA");
    }
}