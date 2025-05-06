#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ProObservacoesEndpoints
{
    public static IEndpointRouteBuilder MapProObservacoesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ProObservacoes").WithTags("ProObservacoes").RequireAuthorization();
        MapProObservacoesRoutes(group);
        return app;
    }

    private static void MapProObservacoesRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IProObservacoesValidation validation, IProObservacoesWriter writer, IProcessosReader processosReader, IProObservacoesService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("ProObservacoes: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProObservacoes_GetAll").WithDisplayName("Get All ProObservacoes");
        group.MapPost("/Filter", async (Filters.FilterProObservacoes filtro, string uri, IProObservacoesValidation validation, IProObservacoesWriter writer, IProcessosReader processosReader, IProObservacoesService service) =>
        {
            logger.Info("ProObservacoes: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProObservacoes_Filter").WithDisplayName("Filter ProObservacoes");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProObservacoesValidation validation, IProObservacoesWriter writer, IProcessosReader processosReader, IProObservacoesService service, CancellationToken token) =>
        {
            logger.Info("ProObservacoes: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ProObservacoes found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProObservacoes_GetById").WithDisplayName("Get ProObservacoes By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IProObservacoesValidation validation, IProObservacoesWriter writer, IProcessosReader processosReader, IProObservacoesService service) =>
        {
            logger.Info("ProObservacoes: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No ProObservacoes found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProObservacoes_GetByName").WithDisplayName("Get ProObservacoes By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterProObservacoes? filtro, string uri, IProObservacoesValidation validation, IProObservacoesWriter writer, IProcessosReader processosReader, IProObservacoesService service) =>
        {
            logger.Info("ProObservacoes: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("ProObservacoes_GetListN").WithDisplayName("Get ProObservacoes List N");
        group.MapPost("/AddAndUpdate", async (Models.ProObservacoes regProObservacoes, string uri, IProObservacoesValidation validation, IProObservacoesWriter writer, IProcessosReader processosReader, IProObservacoesService service) =>
        {
            logger.LogInfo("ProObservacoes", "AddAndUpdate", $"regProObservacoes = {regProObservacoes}", uri);
            var result = await service.AddAndUpdate(regProObservacoes, uri);
            if (result == null)
            {
                logger.LogWarn("ProObservacoes", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProObservacoes_AddAndUpdate").WithDisplayName("Add or Update ProObservacoes");
        group.MapDelete("/Delete", async (int id, string uri, IProObservacoesValidation validation, IProObservacoesWriter writer, IProcessosReader processosReader, IProObservacoesService service) =>
        {
            logger.LogInfo("ProObservacoes", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("ProObservacoes", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProObservacoes_Delete").WithDisplayName("Delete ProObservacoes");
    }
}