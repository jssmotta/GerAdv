#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ProTipoBaixaEndpoints
{
    public static IEndpointRouteBuilder MapProTipoBaixaEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ProTipoBaixa").WithTags("ProTipoBaixa").RequireAuthorization();
        MapProTipoBaixaRoutes(group);
        return app;
    }

    private static void MapProTipoBaixaRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IProTipoBaixaService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProTipoBaixa_GetAll").WithDisplayName("Get All ProTipoBaixa");
        group.MapPost("/Filter", async (Filters.FilterProTipoBaixa filtro, string uri, IProTipoBaixaService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProTipoBaixa_Filter").WithDisplayName("Filter ProTipoBaixa");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProTipoBaixaService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ProTipoBaixa found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProTipoBaixa_GetById").WithDisplayName("Get ProTipoBaixa By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterProTipoBaixa? filtro, string uri, IProTipoBaixaService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("ProTipoBaixa_GetListN").WithDisplayName("Get ProTipoBaixa List N");
        group.MapPost("/AddAndUpdate", async (Models.ProTipoBaixa regProTipoBaixa, string uri, IProTipoBaixaValidation validation, IProTipoBaixaWriter writer, IProTipoBaixaService service) =>
        {
            var result = await service.AddAndUpdate(regProTipoBaixa, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProTipoBaixa_AddAndUpdate").WithDisplayName("Add or Update ProTipoBaixa");
        group.MapDelete("/Delete", async (int id, string uri, IProTipoBaixaValidation validation, IProTipoBaixaWriter writer, IProTipoBaixaService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProTipoBaixa_Delete").WithDisplayName("Delete ProTipoBaixa");
    }
}