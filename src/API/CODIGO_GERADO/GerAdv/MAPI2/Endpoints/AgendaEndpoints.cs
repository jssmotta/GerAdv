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
        group.MapGet("/GetAll", async (int max, string uri, IAgendaValidation validation, IAgendaWriter writer, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, ITipoCompromissoReader tipocompromissoReader, IClientesReader clientesReader, IAreaReader areaReader, IJusticaReader justicaReader, IProcessosReader processosReader, IOperadorReader operadorReader, IPrepostosReader prepostosReader, IAgendaService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Agenda: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Agenda_GetAll").WithDisplayName("Get All Agenda");
        group.MapPost("/Filter", async (Filters.FilterAgenda filtro, string uri, IAgendaValidation validation, IAgendaWriter writer, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, ITipoCompromissoReader tipocompromissoReader, IClientesReader clientesReader, IAreaReader areaReader, IJusticaReader justicaReader, IProcessosReader processosReader, IOperadorReader operadorReader, IPrepostosReader prepostosReader, IAgendaService service) =>
        {
            logger.Info("Agenda: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Agenda_Filter").WithDisplayName("Filter Agenda");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAgendaValidation validation, IAgendaWriter writer, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, ITipoCompromissoReader tipocompromissoReader, IClientesReader clientesReader, IAreaReader areaReader, IJusticaReader justicaReader, IProcessosReader processosReader, IOperadorReader operadorReader, IPrepostosReader prepostosReader, IAgendaService service, CancellationToken token) =>
        {
            logger.Info("Agenda: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Agenda found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Agenda_GetById").WithDisplayName("Get Agenda By Id");
        group.MapPost("/AddAndUpdate", async (Models.Agenda regAgenda, string uri, IAgendaValidation validation, IAgendaWriter writer, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, ITipoCompromissoReader tipocompromissoReader, IClientesReader clientesReader, IAreaReader areaReader, IJusticaReader justicaReader, IProcessosReader processosReader, IOperadorReader operadorReader, IPrepostosReader prepostosReader, IAgendaService service) =>
        {
            logger.LogInfo("Agenda", "AddAndUpdate", $"regAgenda = {regAgenda}", uri);
            var result = await service.AddAndUpdate(regAgenda, uri);
            if (result == null)
            {
                logger.LogWarn("Agenda", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Agenda_AddAndUpdate").WithDisplayName("Add or Update Agenda");
        group.MapDelete("/Delete", async (int id, string uri, IAgendaValidation validation, IAgendaWriter writer, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, ITipoCompromissoReader tipocompromissoReader, IClientesReader clientesReader, IAreaReader areaReader, IJusticaReader justicaReader, IProcessosReader processosReader, IOperadorReader operadorReader, IPrepostosReader prepostosReader, IAgendaService service) =>
        {
            logger.LogInfo("Agenda", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Agenda", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Agenda_Delete").WithDisplayName("Delete Agenda");
    }
}