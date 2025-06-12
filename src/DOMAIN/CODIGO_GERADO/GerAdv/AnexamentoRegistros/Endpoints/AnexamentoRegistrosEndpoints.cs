#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class AnexamentoRegistrosEndpoints
{
    public static IEndpointRouteBuilder MapAnexamentoRegistrosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/AnexamentoRegistros").WithTags("AnexamentoRegistros").RequireAuthorization();
        MapAnexamentoRegistrosRoutes(group);
        return app;
    }

    private static void MapAnexamentoRegistrosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IAnexamentoRegistrosService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("AnexamentoRegistros_GetAll").WithDisplayName("Get All AnexamentoRegistros");
        group.MapPost("/Filter", async (Filters.FilterAnexamentoRegistros filtro, string uri, IAnexamentoRegistrosService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("AnexamentoRegistros_Filter").WithDisplayName("Filter AnexamentoRegistros");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAnexamentoRegistrosService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No AnexamentoRegistros found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AnexamentoRegistros_GetById").WithDisplayName("Get AnexamentoRegistros By Id");
        group.MapPost("/AddAndUpdate", async (Models.AnexamentoRegistros regAnexamentoRegistros, string uri, IAnexamentoRegistrosValidation validation, IAnexamentoRegistrosWriter writer, IClientesReader clientesReader, IAnexamentoRegistrosService service) =>
        {
            var result = await service.AddAndUpdate(regAnexamentoRegistros, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("AnexamentoRegistros_AddAndUpdate").WithDisplayName("Add or Update AnexamentoRegistros");
        group.MapDelete("/Delete", async (int id, string uri, IAnexamentoRegistrosValidation validation, IAnexamentoRegistrosWriter writer, IClientesReader clientesReader, IAnexamentoRegistrosService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AnexamentoRegistros_Delete").WithDisplayName("Delete AnexamentoRegistros");
    }
}