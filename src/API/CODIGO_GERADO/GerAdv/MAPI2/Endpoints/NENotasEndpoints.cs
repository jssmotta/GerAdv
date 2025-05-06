#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class NENotasEndpoints
{
    public static IEndpointRouteBuilder MapNENotasEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/NENotas").WithTags("NENotas").RequireAuthorization();
        MapNENotasRoutes(group);
        return app;
    }

    private static void MapNENotasRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, INENotasValidation validation, INENotasWriter writer, IApensoReader apensoReader, IPrecatoriaReader precatoriaReader, IInstanciaReader instanciaReader, IProcessosReader processosReader, INENotasService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("NENotas: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("NENotas_GetAll").WithDisplayName("Get All NENotas");
        group.MapPost("/Filter", async (Filters.FilterNENotas filtro, string uri, INENotasValidation validation, INENotasWriter writer, IApensoReader apensoReader, IPrecatoriaReader precatoriaReader, IInstanciaReader instanciaReader, IProcessosReader processosReader, INENotasService service) =>
        {
            logger.Info("NENotas: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("NENotas_Filter").WithDisplayName("Filter NENotas");
        group.MapGet("/GetById/{id}", async (int id, string uri, INENotasValidation validation, INENotasWriter writer, IApensoReader apensoReader, IPrecatoriaReader precatoriaReader, IInstanciaReader instanciaReader, IProcessosReader processosReader, INENotasService service, CancellationToken token) =>
        {
            logger.Info("NENotas: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No NENotas found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("NENotas_GetById").WithDisplayName("Get NENotas By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, INENotasValidation validation, INENotasWriter writer, IApensoReader apensoReader, IPrecatoriaReader precatoriaReader, IInstanciaReader instanciaReader, IProcessosReader processosReader, INENotasService service) =>
        {
            logger.Info("NENotas: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No NENotas found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("NENotas_GetByName").WithDisplayName("Get NENotas By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterNENotas? filtro, string uri, INENotasValidation validation, INENotasWriter writer, IApensoReader apensoReader, IPrecatoriaReader precatoriaReader, IInstanciaReader instanciaReader, IProcessosReader processosReader, INENotasService service) =>
        {
            logger.Info("NENotas: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("NENotas_GetListN").WithDisplayName("Get NENotas List N");
        group.MapPost("/AddAndUpdate", async (Models.NENotas regNENotas, string uri, INENotasValidation validation, INENotasWriter writer, IApensoReader apensoReader, IPrecatoriaReader precatoriaReader, IInstanciaReader instanciaReader, IProcessosReader processosReader, INENotasService service) =>
        {
            logger.LogInfo("NENotas", "AddAndUpdate", $"regNENotas = {regNENotas}", uri);
            var result = await service.AddAndUpdate(regNENotas, uri);
            if (result == null)
            {
                logger.LogWarn("NENotas", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("NENotas_AddAndUpdate").WithDisplayName("Add or Update NENotas");
        group.MapDelete("/Delete", async (int id, string uri, INENotasValidation validation, INENotasWriter writer, IApensoReader apensoReader, IPrecatoriaReader precatoriaReader, IInstanciaReader instanciaReader, IProcessosReader processosReader, INENotasService service) =>
        {
            logger.LogInfo("NENotas", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("NENotas", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("NENotas_Delete").WithDisplayName("Delete NENotas");
    }
}