#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class DocsRecebidosItensEndpoints
{
    public static IEndpointRouteBuilder MapDocsRecebidosItensEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/DocsRecebidosItens").WithTags("DocsRecebidosItens").RequireAuthorization();
        MapDocsRecebidosItensRoutes(group);
        return app;
    }

    private static void MapDocsRecebidosItensRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IDocsRecebidosItensService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("DocsRecebidosItens_GetAll").WithDisplayName("Get All DocsRecebidosItens");
        group.MapPost("/Filter", async (Filters.FilterDocsRecebidosItens filtro, string uri, IDocsRecebidosItensService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("DocsRecebidosItens_Filter").WithDisplayName("Filter DocsRecebidosItens");
        group.MapGet("/GetById/{id}", async (int id, string uri, IDocsRecebidosItensService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No DocsRecebidosItens found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("DocsRecebidosItens_GetById").WithDisplayName("Get DocsRecebidosItens By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterDocsRecebidosItens? filtro, string uri, IDocsRecebidosItensService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("DocsRecebidosItens_GetListN").WithDisplayName("Get DocsRecebidosItens List N");
        group.MapPost("/AddAndUpdate", async (Models.DocsRecebidosItens regDocsRecebidosItens, string uri, IDocsRecebidosItensValidation validation, IDocsRecebidosItensWriter writer, IContatoCRMReader contatocrmReader, IDocsRecebidosItensService service) =>
        {
            var result = await service.AddAndUpdate(regDocsRecebidosItens, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("DocsRecebidosItens_AddAndUpdate").WithDisplayName("Add or Update DocsRecebidosItens");
        group.MapDelete("/Delete", async (int id, string uri, IDocsRecebidosItensValidation validation, IDocsRecebidosItensWriter writer, IContatoCRMReader contatocrmReader, IDocsRecebidosItensService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("DocsRecebidosItens_Delete").WithDisplayName("Delete DocsRecebidosItens");
    }
}