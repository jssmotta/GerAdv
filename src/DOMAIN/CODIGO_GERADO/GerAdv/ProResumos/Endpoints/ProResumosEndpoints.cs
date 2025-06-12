#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ProResumosEndpoints
{
    public static IEndpointRouteBuilder MapProResumosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ProResumos").WithTags("ProResumos").RequireAuthorization();
        MapProResumosRoutes(group);
        return app;
    }

    private static void MapProResumosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IProResumosService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProResumos_GetAll").WithDisplayName("Get All ProResumos");
        group.MapPost("/Filter", async (Filters.FilterProResumos filtro, string uri, IProResumosService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProResumos_Filter").WithDisplayName("Filter ProResumos");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProResumosService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ProResumos found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProResumos_GetById").WithDisplayName("Get ProResumos By Id");
        group.MapPost("/AddAndUpdate", async (Models.ProResumos regProResumos, string uri, IProResumosValidation validation, IProResumosWriter writer, IProcessosReader processosReader, IProResumosService service) =>
        {
            var result = await service.AddAndUpdate(regProResumos, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProResumos_AddAndUpdate").WithDisplayName("Add or Update ProResumos");
        group.MapDelete("/Delete", async (int id, string uri, IProResumosValidation validation, IProResumosWriter writer, IProcessosReader processosReader, IProResumosService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProResumos_Delete").WithDisplayName("Delete ProResumos");
    }
}