#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class OperadorGrupoEndpoints
{
    public static IEndpointRouteBuilder MapOperadorGrupoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/OperadorGrupo").WithTags("OperadorGrupo").RequireAuthorization();
        MapOperadorGrupoRoutes(group);
        return app;
    }

    private static void MapOperadorGrupoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IOperadorGrupoService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("OperadorGrupo_GetAll").WithDisplayName("Get All OperadorGrupo");
        group.MapPost("/Filter", async (Filters.FilterOperadorGrupo filtro, string uri, IOperadorGrupoService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("OperadorGrupo_Filter").WithDisplayName("Filter OperadorGrupo");
        group.MapGet("/GetById/{id}", async (int id, string uri, IOperadorGrupoService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No OperadorGrupo found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OperadorGrupo_GetById").WithDisplayName("Get OperadorGrupo By Id");
        group.MapPost("/AddAndUpdate", async (Models.OperadorGrupo regOperadorGrupo, string uri, IOperadorGrupoValidation validation, IOperadorGrupoWriter writer, IOperadorReader operadorReader, IOperadorGrupoService service) =>
        {
            var result = await service.AddAndUpdate(regOperadorGrupo, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("OperadorGrupo_AddAndUpdate").WithDisplayName("Add or Update OperadorGrupo");
        group.MapDelete("/Delete", async (int id, string uri, IOperadorGrupoValidation validation, IOperadorGrupoWriter writer, IOperadorReader operadorReader, IOperadorGrupoService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OperadorGrupo_Delete").WithDisplayName("Delete OperadorGrupo");
    }
}