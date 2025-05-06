#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class HistoricoEndpoints
{
    public static IEndpointRouteBuilder MapHistoricoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Historico").WithTags("Historico").RequireAuthorization();
        MapHistoricoRoutes(group);
        return app;
    }

    private static void MapHistoricoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IHistoricoValidation validation, IHistoricoWriter writer, IProcessosReader processosReader, IPrecatoriaReader precatoriaReader, IApensoReader apensoReader, IFaseReader faseReader, IStatusAndamentoReader statusandamentoReader, IHistoricoService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Historico: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Historico_GetAll").WithDisplayName("Get All Historico");
        group.MapPost("/Filter", async (Filters.FilterHistorico filtro, string uri, IHistoricoValidation validation, IHistoricoWriter writer, IProcessosReader processosReader, IPrecatoriaReader precatoriaReader, IApensoReader apensoReader, IFaseReader faseReader, IStatusAndamentoReader statusandamentoReader, IHistoricoService service) =>
        {
            logger.Info("Historico: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Historico_Filter").WithDisplayName("Filter Historico");
        group.MapGet("/GetById/{id}", async (int id, string uri, IHistoricoValidation validation, IHistoricoWriter writer, IProcessosReader processosReader, IPrecatoriaReader precatoriaReader, IApensoReader apensoReader, IFaseReader faseReader, IStatusAndamentoReader statusandamentoReader, IHistoricoService service, CancellationToken token) =>
        {
            logger.Info("Historico: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Historico found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Historico_GetById").WithDisplayName("Get Historico By Id");
        group.MapPost("/AddAndUpdate", async (Models.Historico regHistorico, string uri, IHistoricoValidation validation, IHistoricoWriter writer, IProcessosReader processosReader, IPrecatoriaReader precatoriaReader, IApensoReader apensoReader, IFaseReader faseReader, IStatusAndamentoReader statusandamentoReader, IHistoricoService service) =>
        {
            logger.LogInfo("Historico", "AddAndUpdate", $"regHistorico = {regHistorico}", uri);
            var result = await service.AddAndUpdate(regHistorico, uri);
            if (result == null)
            {
                logger.LogWarn("Historico", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Historico_AddAndUpdate").WithDisplayName("Add or Update Historico");
        group.MapDelete("/Delete", async (int id, string uri, IHistoricoValidation validation, IHistoricoWriter writer, IProcessosReader processosReader, IPrecatoriaReader precatoriaReader, IApensoReader apensoReader, IFaseReader faseReader, IStatusAndamentoReader statusandamentoReader, IHistoricoService service) =>
        {
            logger.LogInfo("Historico", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Historico", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Historico_Delete").WithDisplayName("Delete Historico");
    }
}