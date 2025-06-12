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
        group.MapGet("/GetAll", async (int max, string uri, IOponentesRepLegalService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("OponentesRepLegal_GetAll").WithDisplayName("Get All OponentesRepLegal");
        group.MapPost("/Filter", async (Filters.FilterOponentesRepLegal filtro, string uri, IOponentesRepLegalService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("OponentesRepLegal_Filter").WithDisplayName("Filter OponentesRepLegal");
        group.MapGet("/GetById/{id}", async (int id, string uri, IOponentesRepLegalService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No OponentesRepLegal found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OponentesRepLegal_GetById").WithDisplayName("Get OponentesRepLegal By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterOponentesRepLegal? filtro, string uri, IOponentesRepLegalService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("OponentesRepLegal_GetListN").WithDisplayName("Get OponentesRepLegal List N");
        group.MapPost("/AddAndUpdate", async (Models.OponentesRepLegal regOponentesRepLegal, string uri, IOponentesRepLegalValidation validation, IOponentesRepLegalWriter writer, IOponentesReader oponentesReader, ICidadeReader cidadeReader, IOponentesRepLegalService service) =>
        {
            var result = await service.AddAndUpdate(regOponentesRepLegal, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("OponentesRepLegal_AddAndUpdate").WithDisplayName("Add or Update OponentesRepLegal");
        group.MapDelete("/Delete", async (int id, string uri, IOponentesRepLegalValidation validation, IOponentesRepLegalWriter writer, IOponentesReader oponentesReader, ICidadeReader cidadeReader, IOponentesRepLegalService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OponentesRepLegal_Delete").WithDisplayName("Delete OponentesRepLegal");
    }
}