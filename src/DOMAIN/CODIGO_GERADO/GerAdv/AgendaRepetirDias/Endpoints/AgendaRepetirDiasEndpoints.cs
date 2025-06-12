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
        group.MapGet("/GetAll", async (int max, string uri, IAgendaRepetirDiasService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("AgendaRepetirDias_GetAll").WithDisplayName("Get All AgendaRepetirDias");
        group.MapPost("/Filter", async (Filters.FilterAgendaRepetirDias filtro, string uri, IAgendaRepetirDiasService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("AgendaRepetirDias_Filter").WithDisplayName("Filter AgendaRepetirDias");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAgendaRepetirDiasService service, CancellationToken token) =>
        {
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
            var result = await service.AddAndUpdate(regAgendaRepetirDias, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("AgendaRepetirDias_AddAndUpdate").WithDisplayName("Add or Update AgendaRepetirDias");
        group.MapDelete("/Delete", async (int id, string uri, IAgendaRepetirDiasValidation validation, IAgendaRepetirDiasWriter writer, IAgendaRepetirDiasService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AgendaRepetirDias_Delete").WithDisplayName("Delete AgendaRepetirDias");
    }
}