#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class CidadeEndpoints
{
    public static IEndpointRouteBuilder MapCidadeEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Cidade").WithTags("Cidade").RequireAuthorization();
        MapCidadeRoutes(group);
        return app;
    }

    private static void MapCidadeRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ICidadeValidation validation, ICidadeWriter writer, IUFReader ufReader, ICidadeService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Cidade: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Cidade_GetAll").WithDisplayName("Get All Cidade");
        group.MapPost("/Filter", async (Filters.FilterCidade filtro, string uri, ICidadeValidation validation, ICidadeWriter writer, IUFReader ufReader, ICidadeService service) =>
        {
            logger.Info("Cidade: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Cidade_Filter").WithDisplayName("Filter Cidade");
        group.MapGet("/GetById/{id}", async (int id, string uri, ICidadeValidation validation, ICidadeWriter writer, IUFReader ufReader, ICidadeService service, CancellationToken token) =>
        {
            logger.Info("Cidade: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Cidade found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Cidade_GetById").WithDisplayName("Get Cidade By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, ICidadeValidation validation, ICidadeWriter writer, IUFReader ufReader, ICidadeService service) =>
        {
            logger.Info("Cidade: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Cidade found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Cidade_GetByName").WithDisplayName("Get Cidade By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterCidade? filtro, string uri, ICidadeValidation validation, ICidadeWriter writer, IUFReader ufReader, ICidadeService service) =>
        {
            logger.Info("Cidade: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Cidade_GetListN").WithDisplayName("Get Cidade List N");
        group.MapPost("/AddAndUpdate", async (Models.Cidade regCidade, string uri, ICidadeValidation validation, ICidadeWriter writer, IUFReader ufReader, ICidadeService service) =>
        {
            logger.LogInfo("Cidade", "AddAndUpdate", $"regCidade = {regCidade}", uri);
            var result = await service.AddAndUpdate(regCidade, uri);
            if (result == null)
            {
                logger.LogWarn("Cidade", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Cidade_AddAndUpdate").WithDisplayName("Add or Update Cidade");
        group.MapDelete("/Delete", async (int id, string uri, ICidadeValidation validation, ICidadeWriter writer, IUFReader ufReader, ICidadeService service) =>
        {
            logger.LogInfo("Cidade", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Cidade", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Cidade_Delete").WithDisplayName("Delete Cidade");
    }
}