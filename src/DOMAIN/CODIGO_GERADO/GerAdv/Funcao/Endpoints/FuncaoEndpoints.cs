#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class FuncaoEndpoints
{
    public static IEndpointRouteBuilder MapFuncaoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Funcao").WithTags("Funcao").RequireAuthorization();
        MapFuncaoRoutes(group);
        return app;
    }

    private static void MapFuncaoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IFuncaoService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Funcao_GetAll").WithDisplayName("Get All Funcao");
        group.MapPost("/Filter", async (Filters.FilterFuncao filtro, string uri, IFuncaoService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Funcao_Filter").WithDisplayName("Filter Funcao");
        group.MapGet("/GetById/{id}", async (int id, string uri, IFuncaoService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Funcao found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Funcao_GetById").WithDisplayName("Get Funcao By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterFuncao? filtro, string uri, IFuncaoService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Funcao_GetListN").WithDisplayName("Get Funcao List N");
        group.MapPost("/AddAndUpdate", async (Models.Funcao regFuncao, string uri, IFuncaoValidation validation, IFuncaoWriter writer, IFuncaoService service) =>
        {
            var result = await service.AddAndUpdate(regFuncao, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Funcao_AddAndUpdate").WithDisplayName("Add or Update Funcao");
        group.MapDelete("/Delete", async (int id, string uri, IFuncaoValidation validation, IFuncaoWriter writer, IFuncaoService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Funcao_Delete").WithDisplayName("Delete Funcao");
    }
}