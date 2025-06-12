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
        group.MapGet("/GetAll", async (int max, string uri, IProCDAService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProCDA_GetAll").WithDisplayName("Get All ProCDA");
        group.MapPost("/Filter", async (Filters.FilterProCDA filtro, string uri, IProCDAService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProCDA_Filter").WithDisplayName("Filter ProCDA");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProCDAService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ProCDA found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProCDA_GetById").WithDisplayName("Get ProCDA By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterProCDA? filtro, string uri, IProCDAService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("ProCDA_GetListN").WithDisplayName("Get ProCDA List N");
        group.MapPost("/AddAndUpdate", async (Models.ProCDA regProCDA, string uri, IProCDAValidation validation, IProCDAWriter writer, IProcessosReader processosReader, IProCDAService service) =>
        {
            var result = await service.AddAndUpdate(regProCDA, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProCDA_AddAndUpdate").WithDisplayName("Add or Update ProCDA");
        group.MapDelete("/Delete", async (int id, string uri, IProCDAValidation validation, IProCDAWriter writer, IProcessosReader processosReader, IProCDAService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProCDA_Delete").WithDisplayName("Delete ProCDA");
    }
}