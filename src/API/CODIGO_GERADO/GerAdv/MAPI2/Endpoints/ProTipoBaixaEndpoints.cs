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
        group.MapGet("/GetAll", async (int max, string uri, IProTipoBaixaValidation validation, IProTipoBaixaWriter writer, IProTipoBaixaService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("ProTipoBaixa: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProTipoBaixa_GetAll").WithDisplayName("Get All ProTipoBaixa");
        group.MapPost("/Filter", async (Filters.FilterProTipoBaixa filtro, string uri, IProTipoBaixaValidation validation, IProTipoBaixaWriter writer, IProTipoBaixaService service) =>
        {
            logger.Info("ProTipoBaixa: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProTipoBaixa_Filter").WithDisplayName("Filter ProTipoBaixa");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProTipoBaixaValidation validation, IProTipoBaixaWriter writer, IProTipoBaixaService service, CancellationToken token) =>
        {
            logger.Info("ProTipoBaixa: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ProTipoBaixa found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProTipoBaixa_GetById").WithDisplayName("Get ProTipoBaixa By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IProTipoBaixaValidation validation, IProTipoBaixaWriter writer, IProTipoBaixaService service) =>
        {
            logger.Info("ProTipoBaixa: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No ProTipoBaixa found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProTipoBaixa_GetByName").WithDisplayName("Get ProTipoBaixa By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterProTipoBaixa? filtro, string uri, IProTipoBaixaValidation validation, IProTipoBaixaWriter writer, IProTipoBaixaService service) =>
        {
            logger.Info("ProTipoBaixa: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("ProTipoBaixa_GetListN").WithDisplayName("Get ProTipoBaixa List N");
        group.MapPost("/AddAndUpdate", async (Models.ProTipoBaixa regProTipoBaixa, string uri, IProTipoBaixaValidation validation, IProTipoBaixaWriter writer, IProTipoBaixaService service) =>
        {
            logger.LogInfo("ProTipoBaixa", "AddAndUpdate", $"regProTipoBaixa = {regProTipoBaixa}", uri);
            var result = await service.AddAndUpdate(regProTipoBaixa, uri);
            if (result == null)
            {
                logger.LogWarn("ProTipoBaixa", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProTipoBaixa_AddAndUpdate").WithDisplayName("Add or Update ProTipoBaixa");
        group.MapDelete("/Delete", async (int id, string uri, IProTipoBaixaValidation validation, IProTipoBaixaWriter writer, IProTipoBaixaService service) =>
        {
            logger.LogInfo("ProTipoBaixa", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("ProTipoBaixa", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProTipoBaixa_Delete").WithDisplayName("Delete ProTipoBaixa");
    }
}