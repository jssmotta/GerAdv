#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class NECompromissosEndpoints
{
    public static IEndpointRouteBuilder MapNECompromissosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/NECompromissos").WithTags("NECompromissos").RequireAuthorization();
        MapNECompromissosRoutes(group);
        return app;
    }

    private static void MapNECompromissosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, INECompromissosValidation validation, INECompromissosWriter writer, ITipoCompromissoReader tipocompromissoReader, INECompromissosService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("NECompromissos: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("NECompromissos_GetAll").WithDisplayName("Get All NECompromissos");
        group.MapPost("/Filter", async (Filters.FilterNECompromissos filtro, string uri, INECompromissosValidation validation, INECompromissosWriter writer, ITipoCompromissoReader tipocompromissoReader, INECompromissosService service) =>
        {
            logger.Info("NECompromissos: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("NECompromissos_Filter").WithDisplayName("Filter NECompromissos");
        group.MapGet("/GetById/{id}", async (int id, string uri, INECompromissosValidation validation, INECompromissosWriter writer, ITipoCompromissoReader tipocompromissoReader, INECompromissosService service, CancellationToken token) =>
        {
            logger.Info("NECompromissos: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No NECompromissos found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("NECompromissos_GetById").WithDisplayName("Get NECompromissos By Id");
        group.MapPost("/AddAndUpdate", async (Models.NECompromissos regNECompromissos, string uri, INECompromissosValidation validation, INECompromissosWriter writer, ITipoCompromissoReader tipocompromissoReader, INECompromissosService service) =>
        {
            logger.LogInfo("NECompromissos", "AddAndUpdate", $"regNECompromissos = {regNECompromissos}", uri);
            var result = await service.AddAndUpdate(regNECompromissos, uri);
            if (result == null)
            {
                logger.LogWarn("NECompromissos", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("NECompromissos_AddAndUpdate").WithDisplayName("Add or Update NECompromissos");
        group.MapDelete("/Delete", async (int id, string uri, INECompromissosValidation validation, INECompromissosWriter writer, ITipoCompromissoReader tipocompromissoReader, INECompromissosService service) =>
        {
            logger.LogInfo("NECompromissos", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("NECompromissos", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("NECompromissos_Delete").WithDisplayName("Delete NECompromissos");
    }
}