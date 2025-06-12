#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class AgendaEndpoints
{
    public static IEndpointRouteBuilder MapAgendaEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Agenda").WithTags("Agenda").RequireAuthorization();
        MapAgendaRoutes(group);
        return app;
    }

    private static void MapAgendaRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IAgendaService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Agenda_GetAll").WithDisplayName("Get All Agenda");
        group.MapPost("/Filter", async (Filters.FilterAgenda filtro, string uri, IAgendaService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Agenda_Filter").WithDisplayName("Filter Agenda");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAgendaService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Agenda found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Agenda_GetById").WithDisplayName("Get Agenda By Id");
        group.MapPost("/AddAndUpdate", async (Models.Agenda regAgenda, string uri, IAgendaValidation validation, IAgendaWriter writer, ICidadeReader cidadeReader, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, ITipoCompromissoReader tipocompromissoReader, IClientesReader clientesReader, IAreaReader areaReader, IJusticaReader justicaReader, IProcessosReader processosReader, IOperadorReader operadorReader, IPrepostosReader prepostosReader, IAgendaService service) =>
        {
            var result = await service.AddAndUpdate(regAgenda, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Agenda_AddAndUpdate").WithDisplayName("Add or Update Agenda");
        group.MapDelete("/Delete", async (int id, string uri, IAgendaValidation validation, IAgendaWriter writer, ICidadeReader cidadeReader, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, ITipoCompromissoReader tipocompromissoReader, IClientesReader clientesReader, IAreaReader areaReader, IJusticaReader justicaReader, IProcessosReader processosReader, IOperadorReader operadorReader, IPrepostosReader prepostosReader, IAgendaService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Agenda_Delete").WithDisplayName("Delete Agenda");
    }
}