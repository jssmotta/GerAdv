#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class AgendaRepetirDiasEndpoints
{
    public static IEndpointRouteBuilder MapAgendaRepetirDiasEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/AgendaRepetirDias").WithTags("AgendaRepetirDias").RequireAuthorization();
        MapAgendaRepetirDiasRoutes(group);
        return app;
    }

    private static void MapAgendaRepetirDiasRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IAgendaRepetirDiasValidation validation, IAgendaRepetirDiasWriter writer, IAgendaRepetirDiasService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("AgendaRepetirDias: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("AgendaRepetirDias_GetAll").WithDisplayName("Get All AgendaRepetirDias");
        group.MapPost("/Filter", async (Filters.FilterAgendaRepetirDias filtro, string uri, IAgendaRepetirDiasValidation validation, IAgendaRepetirDiasWriter writer, IAgendaRepetirDiasService service) =>
        {
            logger.Info("AgendaRepetirDias: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("AgendaRepetirDias_Filter").WithDisplayName("Filter AgendaRepetirDias");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAgendaRepetirDiasValidation validation, IAgendaRepetirDiasWriter writer, IAgendaRepetirDiasService service, CancellationToken token) =>
        {
            logger.Info("AgendaRepetirDias: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No AgendaRepetirDias found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AgendaRepetirDias_GetById").WithDisplayName("Get AgendaRepetirDias By Id");
        group.MapPost("/AddAndUpdate", async (Models.AgendaRepetirDias regAgendaRepetirDias, string uri, IAgendaRepetirDiasValidation validation, IAgendaRepetirDiasWriter writer, IAgendaRepetirDiasService service) =>
        {
            logger.LogInfo("AgendaRepetirDias", "AddAndUpdate", $"regAgendaRepetirDias = {regAgendaRepetirDias}", uri);
            var result = await service.AddAndUpdate(regAgendaRepetirDias, uri);
            if (result == null)
            {
                logger.LogWarn("AgendaRepetirDias", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("AgendaRepetirDias_AddAndUpdate").WithDisplayName("Add or Update AgendaRepetirDias");
        group.MapDelete("/Delete", async (int id, string uri, IAgendaRepetirDiasValidation validation, IAgendaRepetirDiasWriter writer, IAgendaRepetirDiasService service) =>
        {
            logger.LogInfo("AgendaRepetirDias", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("AgendaRepetirDias", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AgendaRepetirDias_Delete").WithDisplayName("Delete AgendaRepetirDias");
    }
}