#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ReuniaoEndpoints
{
    public static IEndpointRouteBuilder MapReuniaoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Reuniao").WithTags("Reuniao").RequireAuthorization();
        MapReuniaoRoutes(group);
        return app;
    }

    private static void MapReuniaoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IReuniaoService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Reuniao_GetAll").WithDisplayName("Get All Reuniao");
        group.MapPost("/Filter", async (Filters.FilterReuniao filtro, string uri, IReuniaoService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Reuniao_Filter").WithDisplayName("Filter Reuniao");
        group.MapGet("/GetById/{id}", async (int id, string uri, IReuniaoService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Reuniao found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Reuniao_GetById").WithDisplayName("Get Reuniao By Id");
        group.MapPost("/AddAndUpdate", async (Models.Reuniao regReuniao, string uri, IReuniaoValidation validation, IReuniaoWriter writer, IClientesReader clientesReader, IReuniaoService service) =>
        {
            var result = await service.AddAndUpdate(regReuniao, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Reuniao_AddAndUpdate").WithDisplayName("Add or Update Reuniao");
        group.MapDelete("/Delete", async (int id, string uri, IReuniaoValidation validation, IReuniaoWriter writer, IClientesReader clientesReader, IReuniaoService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Reuniao_Delete").WithDisplayName("Delete Reuniao");
    }
}