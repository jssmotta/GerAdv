#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class AgendaFinanceiroEndpoints
{
    public static IEndpointRouteBuilder MapAgendaFinanceiroEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/AgendaFinanceiro").WithTags("AgendaFinanceiro").RequireAuthorization();
        MapAgendaFinanceiroRoutes(group);
        return app;
    }

    private static void MapAgendaFinanceiroRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IAgendaFinanceiroService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("AgendaFinanceiro_GetAll").WithDisplayName("Get All AgendaFinanceiro");
        group.MapPost("/Filter", async (Filters.FilterAgendaFinanceiro filtro, string uri, IAgendaFinanceiroService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("AgendaFinanceiro_Filter").WithDisplayName("Filter AgendaFinanceiro");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAgendaFinanceiroService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No AgendaFinanceiro found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AgendaFinanceiro_GetById").WithDisplayName("Get AgendaFinanceiro By Id");
        group.MapPost("/AddAndUpdate", async (Models.AgendaFinanceiro regAgendaFinanceiro, string uri, IAgendaFinanceiroValidation validation, IAgendaFinanceiroWriter writer, ICidadeReader cidadeReader, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, ITipoCompromissoReader tipocompromissoReader, IClientesReader clientesReader, IAreaReader areaReader, IJusticaReader justicaReader, IProcessosReader processosReader, IOperadorReader operadorReader, IPrepostosReader prepostosReader, IAgendaFinanceiroService service) =>
        {
            var result = await service.AddAndUpdate(regAgendaFinanceiro, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("AgendaFinanceiro_AddAndUpdate").WithDisplayName("Add or Update AgendaFinanceiro");
        group.MapDelete("/Delete", async (int id, string uri, IAgendaFinanceiroValidation validation, IAgendaFinanceiroWriter writer, ICidadeReader cidadeReader, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, ITipoCompromissoReader tipocompromissoReader, IClientesReader clientesReader, IAreaReader areaReader, IJusticaReader justicaReader, IProcessosReader processosReader, IOperadorReader operadorReader, IPrepostosReader prepostosReader, IAgendaFinanceiroService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AgendaFinanceiro_Delete").WithDisplayName("Delete AgendaFinanceiro");
    }
}