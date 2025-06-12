#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class TipoOrigemSucumbenciaEndpoints
{
    public static IEndpointRouteBuilder MapTipoOrigemSucumbenciaEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/TipoOrigemSucumbencia").WithTags("TipoOrigemSucumbencia").RequireAuthorization();
        MapTipoOrigemSucumbenciaRoutes(group);
        return app;
    }

    private static void MapTipoOrigemSucumbenciaRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ITipoOrigemSucumbenciaService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("TipoOrigemSucumbencia_GetAll").WithDisplayName("Get All TipoOrigemSucumbencia");
        group.MapPost("/Filter", async (Filters.FilterTipoOrigemSucumbencia filtro, string uri, ITipoOrigemSucumbenciaService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoOrigemSucumbencia_Filter").WithDisplayName("Filter TipoOrigemSucumbencia");
        group.MapGet("/GetById/{id}", async (int id, string uri, ITipoOrigemSucumbenciaService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No TipoOrigemSucumbencia found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoOrigemSucumbencia_GetById").WithDisplayName("Get TipoOrigemSucumbencia By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterTipoOrigemSucumbencia? filtro, string uri, ITipoOrigemSucumbenciaService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("TipoOrigemSucumbencia_GetListN").WithDisplayName("Get TipoOrigemSucumbencia List N");
        group.MapPost("/AddAndUpdate", async (Models.TipoOrigemSucumbencia regTipoOrigemSucumbencia, string uri, ITipoOrigemSucumbenciaValidation validation, ITipoOrigemSucumbenciaWriter writer, ITipoOrigemSucumbenciaService service) =>
        {
            var result = await service.AddAndUpdate(regTipoOrigemSucumbencia, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("TipoOrigemSucumbencia_AddAndUpdate").WithDisplayName("Add or Update TipoOrigemSucumbencia");
        group.MapDelete("/Delete", async (int id, string uri, ITipoOrigemSucumbenciaValidation validation, ITipoOrigemSucumbenciaWriter writer, ITipoOrigemSucumbenciaService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TipoOrigemSucumbencia_Delete").WithDisplayName("Delete TipoOrigemSucumbencia");
    }
}