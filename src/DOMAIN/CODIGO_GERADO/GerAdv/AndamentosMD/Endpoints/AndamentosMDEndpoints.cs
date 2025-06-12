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
        group.MapGet("/GetAll", async (int max, string uri, IAndamentosMDService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("AndamentosMD_GetAll").WithDisplayName("Get All AndamentosMD");
        group.MapPost("/Filter", async (Filters.FilterAndamentosMD filtro, string uri, IAndamentosMDService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("AndamentosMD_Filter").WithDisplayName("Filter AndamentosMD");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAndamentosMDService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No AndamentosMD found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AndamentosMD_GetById").WithDisplayName("Get AndamentosMD By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterAndamentosMD? filtro, string uri, IAndamentosMDService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("AndamentosMD_GetListN").WithDisplayName("Get AndamentosMD List N");
        group.MapPost("/AddAndUpdate", async (Models.AndamentosMD regAndamentosMD, string uri, IAndamentosMDValidation validation, IAndamentosMDWriter writer, IProcessosReader processosReader, IAndamentosMDService service) =>
        {
            var result = await service.AddAndUpdate(regAndamentosMD, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("AndamentosMD_AddAndUpdate").WithDisplayName("Add or Update AndamentosMD");
        group.MapDelete("/Delete", async (int id, string uri, IAndamentosMDValidation validation, IAndamentosMDWriter writer, IProcessosReader processosReader, IAndamentosMDService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AndamentosMD_Delete").WithDisplayName("Delete AndamentosMD");
    }
}