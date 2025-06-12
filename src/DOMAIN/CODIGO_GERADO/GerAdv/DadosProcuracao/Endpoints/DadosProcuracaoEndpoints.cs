#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class DadosProcuracaoEndpoints
{
    public static IEndpointRouteBuilder MapDadosProcuracaoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/DadosProcuracao").WithTags("DadosProcuracao").RequireAuthorization();
        MapDadosProcuracaoRoutes(group);
        return app;
    }

    private static void MapDadosProcuracaoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IDadosProcuracaoService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("DadosProcuracao_GetAll").WithDisplayName("Get All DadosProcuracao");
        group.MapPost("/Filter", async (Filters.FilterDadosProcuracao filtro, string uri, IDadosProcuracaoService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("DadosProcuracao_Filter").WithDisplayName("Filter DadosProcuracao");
        group.MapGet("/GetById/{id}", async (int id, string uri, IDadosProcuracaoService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No DadosProcuracao found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("DadosProcuracao_GetById").WithDisplayName("Get DadosProcuracao By Id");
        group.MapPost("/AddAndUpdate", async (Models.DadosProcuracao regDadosProcuracao, string uri, IDadosProcuracaoValidation validation, IDadosProcuracaoWriter writer, IClientesReader clientesReader, IDadosProcuracaoService service) =>
        {
            var result = await service.AddAndUpdate(regDadosProcuracao, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("DadosProcuracao_AddAndUpdate").WithDisplayName("Add or Update DadosProcuracao");
        group.MapDelete("/Delete", async (int id, string uri, IDadosProcuracaoValidation validation, IDadosProcuracaoWriter writer, IClientesReader clientesReader, IDadosProcuracaoService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("DadosProcuracao_Delete").WithDisplayName("Delete DadosProcuracao");
    }
}