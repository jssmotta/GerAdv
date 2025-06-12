#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class UFEndpoints
{
    public static IEndpointRouteBuilder MapUFEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/UF").WithTags("UF").RequireAuthorization();
        MapUFRoutes(group);
        return app;
    }

    private static void MapUFRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IUFService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("UF_GetAll").WithDisplayName("Get All UF");
        group.MapPost("/Filter", async (Filters.FilterUF filtro, string uri, IUFService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("UF_Filter").WithDisplayName("Filter UF");
        group.MapGet("/GetById/{id}", async (int id, string uri, IUFService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No UF found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("UF_GetById").WithDisplayName("Get UF By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterUF? filtro, string uri, IUFService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("UF_GetListN").WithDisplayName("Get UF List N");
        group.MapPost("/AddAndUpdate", async (Models.UF regUF, string uri, IUFValidation validation, IUFWriter writer, IPaisesReader paisesReader, IUFService service) =>
        {
            var result = await service.AddAndUpdate(regUF, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("UF_AddAndUpdate").WithDisplayName("Add or Update UF");
        group.MapDelete("/Delete", async (int id, string uri, IUFValidation validation, IUFWriter writer, IPaisesReader paisesReader, IUFService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("UF_Delete").WithDisplayName("Delete UF");
    }
}