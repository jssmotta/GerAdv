#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class StatusAndamentoEndpoints
{
    public static IEndpointRouteBuilder MapStatusAndamentoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/StatusAndamento").WithTags("StatusAndamento").RequireAuthorization();
        MapStatusAndamentoRoutes(group);
        return app;
    }

    private static void MapStatusAndamentoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IStatusAndamentoService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("StatusAndamento_GetAll").WithDisplayName("Get All StatusAndamento");
        group.MapPost("/Filter", async (Filters.FilterStatusAndamento filtro, string uri, IStatusAndamentoService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("StatusAndamento_Filter").WithDisplayName("Filter StatusAndamento");
        group.MapGet("/GetById/{id}", async (int id, string uri, IStatusAndamentoService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No StatusAndamento found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("StatusAndamento_GetById").WithDisplayName("Get StatusAndamento By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterStatusAndamento? filtro, string uri, IStatusAndamentoService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("StatusAndamento_GetListN").WithDisplayName("Get StatusAndamento List N");
        group.MapPost("/AddAndUpdate", async (Models.StatusAndamento regStatusAndamento, string uri, IStatusAndamentoValidation validation, IStatusAndamentoWriter writer, IStatusAndamentoService service) =>
        {
            var result = await service.AddAndUpdate(regStatusAndamento, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("StatusAndamento_AddAndUpdate").WithDisplayName("Add or Update StatusAndamento");
        group.MapDelete("/Delete", async (int id, string uri, IStatusAndamentoValidation validation, IStatusAndamentoWriter writer, IStatusAndamentoService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("StatusAndamento_Delete").WithDisplayName("Delete StatusAndamento");
    }
}