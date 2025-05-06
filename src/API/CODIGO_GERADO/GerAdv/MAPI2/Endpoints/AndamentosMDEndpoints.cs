#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class AndamentosMDEndpoints
{
    public static IEndpointRouteBuilder MapAndamentosMDEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/AndamentosMD").WithTags("AndamentosMD").RequireAuthorization();
        MapAndamentosMDRoutes(group);
        return app;
    }

    private static void MapAndamentosMDRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IAndamentosMDValidation validation, IAndamentosMDWriter writer, IProcessosReader processosReader, IAndamentosMDService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("AndamentosMD: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("AndamentosMD_GetAll").WithDisplayName("Get All AndamentosMD");
        group.MapPost("/Filter", async (Filters.FilterAndamentosMD filtro, string uri, IAndamentosMDValidation validation, IAndamentosMDWriter writer, IProcessosReader processosReader, IAndamentosMDService service) =>
        {
            logger.Info("AndamentosMD: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("AndamentosMD_Filter").WithDisplayName("Filter AndamentosMD");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAndamentosMDValidation validation, IAndamentosMDWriter writer, IProcessosReader processosReader, IAndamentosMDService service, CancellationToken token) =>
        {
            logger.Info("AndamentosMD: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No AndamentosMD found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AndamentosMD_GetById").WithDisplayName("Get AndamentosMD By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IAndamentosMDValidation validation, IAndamentosMDWriter writer, IProcessosReader processosReader, IAndamentosMDService service) =>
        {
            logger.Info("AndamentosMD: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No AndamentosMD found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AndamentosMD_GetByName").WithDisplayName("Get AndamentosMD By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterAndamentosMD? filtro, string uri, IAndamentosMDValidation validation, IAndamentosMDWriter writer, IProcessosReader processosReader, IAndamentosMDService service) =>
        {
            logger.Info("AndamentosMD: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("AndamentosMD_GetListN").WithDisplayName("Get AndamentosMD List N");
        group.MapPost("/AddAndUpdate", async (Models.AndamentosMD regAndamentosMD, string uri, IAndamentosMDValidation validation, IAndamentosMDWriter writer, IProcessosReader processosReader, IAndamentosMDService service) =>
        {
            logger.LogInfo("AndamentosMD", "AddAndUpdate", $"regAndamentosMD = {regAndamentosMD}", uri);
            var result = await service.AddAndUpdate(regAndamentosMD, uri);
            if (result == null)
            {
                logger.LogWarn("AndamentosMD", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("AndamentosMD_AddAndUpdate").WithDisplayName("Add or Update AndamentosMD");
        group.MapDelete("/Delete", async (int id, string uri, IAndamentosMDValidation validation, IAndamentosMDWriter writer, IProcessosReader processosReader, IAndamentosMDService service) =>
        {
            logger.LogInfo("AndamentosMD", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("AndamentosMD", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AndamentosMD_Delete").WithDisplayName("Delete AndamentosMD");
    }
}