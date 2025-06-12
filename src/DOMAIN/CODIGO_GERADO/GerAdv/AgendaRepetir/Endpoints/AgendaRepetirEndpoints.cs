#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class AgendaRepetirEndpoints
{
    public static IEndpointRouteBuilder MapAgendaRepetirEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/AgendaRepetir").WithTags("AgendaRepetir").RequireAuthorization();
        MapAgendaRepetirRoutes(group);
        return app;
    }

    private static void MapAgendaRepetirRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IAgendaRepetirService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("AgendaRepetir_GetAll").WithDisplayName("Get All AgendaRepetir");
        group.MapPost("/Filter", async (Filters.FilterAgendaRepetir filtro, string uri, IAgendaRepetirService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("AgendaRepetir_Filter").WithDisplayName("Filter AgendaRepetir");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAgendaRepetirService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No AgendaRepetir found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AgendaRepetir_GetById").WithDisplayName("Get AgendaRepetir By Id");
        group.MapPost("/AddAndUpdate", async (Models.AgendaRepetir regAgendaRepetir, string uri, IAgendaRepetirValidation validation, IAgendaRepetirWriter writer, IAdvogadosReader advogadosReader, IClientesReader clientesReader, IFuncionariosReader funcionariosReader, IProcessosReader processosReader, IAgendaRepetirService service) =>
        {
            var result = await service.AddAndUpdate(regAgendaRepetir, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("AgendaRepetir_AddAndUpdate").WithDisplayName("Add or Update AgendaRepetir");
        group.MapDelete("/Delete", async (int id, string uri, IAgendaRepetirValidation validation, IAgendaRepetirWriter writer, IAdvogadosReader advogadosReader, IClientesReader clientesReader, IFuncionariosReader funcionariosReader, IProcessosReader processosReader, IAgendaRepetirService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AgendaRepetir_Delete").WithDisplayName("Delete AgendaRepetir");
    }
}