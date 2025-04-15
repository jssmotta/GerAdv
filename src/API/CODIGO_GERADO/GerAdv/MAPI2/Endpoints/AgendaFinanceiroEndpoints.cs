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
        group.MapGet("/GetAll", async (int max, string uri, IAgendaFinanceiroValidation validation, IAgendaFinanceiroWriter writer, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, ITipoCompromissoReader tipocompromissoReader, IClientesReader clientesReader, IAreaReader areaReader, IJusticaReader justicaReader, IProcessosReader processosReader, IOperadorReader operadorReader, IPrepostosReader prepostosReader, IAgendaFinanceiroService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("AgendaFinanceiro: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("AgendaFinanceiro_GetAll").WithDisplayName("Get All AgendaFinanceiro");
        group.MapPost("/Filter", async (Filters.FilterAgendaFinanceiro filtro, string uri, IAgendaFinanceiroValidation validation, IAgendaFinanceiroWriter writer, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, ITipoCompromissoReader tipocompromissoReader, IClientesReader clientesReader, IAreaReader areaReader, IJusticaReader justicaReader, IProcessosReader processosReader, IOperadorReader operadorReader, IPrepostosReader prepostosReader, IAgendaFinanceiroService service) =>
        {
            logger.Info("AgendaFinanceiro: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("AgendaFinanceiro_Filter").WithDisplayName("Filter AgendaFinanceiro");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAgendaFinanceiroValidation validation, IAgendaFinanceiroWriter writer, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, ITipoCompromissoReader tipocompromissoReader, IClientesReader clientesReader, IAreaReader areaReader, IJusticaReader justicaReader, IProcessosReader processosReader, IOperadorReader operadorReader, IPrepostosReader prepostosReader, IAgendaFinanceiroService service, CancellationToken token) =>
        {
            logger.Info("AgendaFinanceiro: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No AgendaFinanceiro found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AgendaFinanceiro_GetById").WithDisplayName("Get AgendaFinanceiro By Id");
        group.MapPost("/AddAndUpdate", async (Models.AgendaFinanceiro regAgendaFinanceiro, string uri, IAgendaFinanceiroValidation validation, IAgendaFinanceiroWriter writer, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, ITipoCompromissoReader tipocompromissoReader, IClientesReader clientesReader, IAreaReader areaReader, IJusticaReader justicaReader, IProcessosReader processosReader, IOperadorReader operadorReader, IPrepostosReader prepostosReader, IAgendaFinanceiroService service) =>
        {
            logger.LogInfo("AgendaFinanceiro", "AddAndUpdate", $"regAgendaFinanceiro = {regAgendaFinanceiro}", uri);
            var result = await service.AddAndUpdate(regAgendaFinanceiro, uri);
            if (result == null)
            {
                logger.LogWarn("AgendaFinanceiro", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("AgendaFinanceiro_AddAndUpdate").WithDisplayName("Add or Update AgendaFinanceiro");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IAgendaFinanceiroValidation validation, IAgendaFinanceiroWriter writer, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, ITipoCompromissoReader tipocompromissoReader, IClientesReader clientesReader, IAreaReader areaReader, IJusticaReader justicaReader, IProcessosReader processosReader, IOperadorReader operadorReader, IPrepostosReader prepostosReader, IAgendaFinanceiroService service) =>
        {
            logger.LogInfo("AgendaFinanceiro", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("AgendaFinanceiro", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AgendaFinanceiro_GetColumns").WithDisplayName("Get AgendaFinanceiro Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IAgendaFinanceiroValidation validation, IAgendaFinanceiroWriter writer, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, ITipoCompromissoReader tipocompromissoReader, IClientesReader clientesReader, IAreaReader areaReader, IJusticaReader justicaReader, IProcessosReader processosReader, IOperadorReader operadorReader, IPrepostosReader prepostosReader, IAgendaFinanceiroService service) =>
        {
            logger.LogInfo("AgendaFinanceiro", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("AgendaFinanceiro", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("AgendaFinanceiro_UpdateColumns").WithDisplayName("Update AgendaFinanceiro Columns");
        group.MapDelete("/Delete", async (int id, string uri, IAgendaFinanceiroValidation validation, IAgendaFinanceiroWriter writer, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, ITipoCompromissoReader tipocompromissoReader, IClientesReader clientesReader, IAreaReader areaReader, IJusticaReader justicaReader, IProcessosReader processosReader, IOperadorReader operadorReader, IPrepostosReader prepostosReader, IAgendaFinanceiroService service) =>
        {
            logger.LogInfo("AgendaFinanceiro", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("AgendaFinanceiro", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AgendaFinanceiro_Delete").WithDisplayName("Delete AgendaFinanceiro");
    }
}