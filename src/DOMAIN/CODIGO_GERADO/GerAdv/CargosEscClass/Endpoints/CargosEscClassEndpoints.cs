#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class CargosEscClassEndpoints
{
    public static IEndpointRouteBuilder MapCargosEscClassEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/CargosEscClass").WithTags("CargosEscClass").RequireAuthorization();
        MapCargosEscClassRoutes(group);
        return app;
    }

    private static void MapCargosEscClassRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ICargosEscClassService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("CargosEscClass_GetAll").WithDisplayName("Get All CargosEscClass");
        group.MapPost("/Filter", async (Filters.FilterCargosEscClass filtro, string uri, ICargosEscClassService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("CargosEscClass_Filter").WithDisplayName("Filter CargosEscClass");
        group.MapGet("/GetById/{id}", async (int id, string uri, ICargosEscClassService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No CargosEscClass found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("CargosEscClass_GetById").WithDisplayName("Get CargosEscClass By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterCargosEscClass? filtro, string uri, ICargosEscClassService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("CargosEscClass_GetListN").WithDisplayName("Get CargosEscClass List N");
        group.MapPost("/AddAndUpdate", async (Models.CargosEscClass regCargosEscClass, string uri, ICargosEscClassValidation validation, ICargosEscClassWriter writer, ICargosEscClassService service) =>
        {
            var result = await service.AddAndUpdate(regCargosEscClass, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("CargosEscClass_AddAndUpdate").WithDisplayName("Add or Update CargosEscClass");
        group.MapDelete("/Delete", async (int id, string uri, ICargosEscClassValidation validation, ICargosEscClassWriter writer, ICargosEscClassService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("CargosEscClass_Delete").WithDisplayName("Delete CargosEscClass");
    }
}