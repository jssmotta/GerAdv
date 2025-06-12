#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class LivroCaixaEndpoints
{
    public static IEndpointRouteBuilder MapLivroCaixaEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/LivroCaixa").WithTags("LivroCaixa").RequireAuthorization();
        MapLivroCaixaRoutes(group);
        return app;
    }

    private static void MapLivroCaixaRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ILivroCaixaService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("LivroCaixa_GetAll").WithDisplayName("Get All LivroCaixa");
        group.MapPost("/Filter", async (Filters.FilterLivroCaixa filtro, string uri, ILivroCaixaService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("LivroCaixa_Filter").WithDisplayName("Filter LivroCaixa");
        group.MapGet("/GetById/{id}", async (int id, string uri, ILivroCaixaService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No LivroCaixa found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("LivroCaixa_GetById").WithDisplayName("Get LivroCaixa By Id");
        group.MapPost("/AddAndUpdate", async (Models.LivroCaixa regLivroCaixa, string uri, ILivroCaixaValidation validation, ILivroCaixaWriter writer, IProcessosReader processosReader, ILivroCaixaService service) =>
        {
            var result = await service.AddAndUpdate(regLivroCaixa, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("LivroCaixa_AddAndUpdate").WithDisplayName("Add or Update LivroCaixa");
        group.MapDelete("/Delete", async (int id, string uri, ILivroCaixaValidation validation, ILivroCaixaWriter writer, IProcessosReader processosReader, ILivroCaixaService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("LivroCaixa_Delete").WithDisplayName("Delete LivroCaixa");
    }
}