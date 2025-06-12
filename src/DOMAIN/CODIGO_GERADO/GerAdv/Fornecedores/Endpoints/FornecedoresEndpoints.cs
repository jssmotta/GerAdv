#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class FornecedoresEndpoints
{
    public static IEndpointRouteBuilder MapFornecedoresEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Fornecedores").WithTags("Fornecedores").RequireAuthorization();
        MapFornecedoresRoutes(group);
        return app;
    }

    private static void MapFornecedoresRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IFornecedoresService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Fornecedores_GetAll").WithDisplayName("Get All Fornecedores");
        group.MapPost("/Filter", async (Filters.FilterFornecedores filtro, string uri, IFornecedoresService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Fornecedores_Filter").WithDisplayName("Filter Fornecedores");
        group.MapGet("/GetById/{id}", async (int id, string uri, IFornecedoresService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Fornecedores found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Fornecedores_GetById").WithDisplayName("Get Fornecedores By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterFornecedores? filtro, string uri, IFornecedoresService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Fornecedores_GetListN").WithDisplayName("Get Fornecedores List N");
        group.MapPost("/AddAndUpdate", async (Models.Fornecedores regFornecedores, string uri, IFornecedoresValidation validation, IFornecedoresWriter writer, ICidadeReader cidadeReader, IFornecedoresService service) =>
        {
            var result = await service.AddAndUpdate(regFornecedores, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Fornecedores_AddAndUpdate").WithDisplayName("Add or Update Fornecedores");
        group.MapDelete("/Delete", async (int id, string uri, IFornecedoresValidation validation, IFornecedoresWriter writer, ICidadeReader cidadeReader, IFornecedoresService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Fornecedores_Delete").WithDisplayName("Delete Fornecedores");
    }
}