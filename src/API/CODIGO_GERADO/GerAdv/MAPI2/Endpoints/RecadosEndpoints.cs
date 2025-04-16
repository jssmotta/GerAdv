#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class RecadosEndpoints
{
    public static IEndpointRouteBuilder MapRecadosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Recados").WithTags("Recados").RequireAuthorization();
        MapRecadosRoutes(group);
        return app;
    }

    private static void MapRecadosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IRecadosValidation validation, IRecadosWriter writer, IProcessosReader processosReader, IClientesReader clientesReader, IHistoricoReader historicoReader, IContatoCRMReader contatocrmReader, ILigacoesReader ligacoesReader, IAgendaReader agendaReader, IRecadosService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Recados: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Recados_GetAll").WithDisplayName("Get All Recados");
        group.MapPost("/Filter", async (Filters.FilterRecados filtro, string uri, IRecadosValidation validation, IRecadosWriter writer, IProcessosReader processosReader, IClientesReader clientesReader, IHistoricoReader historicoReader, IContatoCRMReader contatocrmReader, ILigacoesReader ligacoesReader, IAgendaReader agendaReader, IRecadosService service) =>
        {
            logger.Info("Recados: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Recados_Filter").WithDisplayName("Filter Recados");
        group.MapGet("/GetById/{id}", async (int id, string uri, IRecadosValidation validation, IRecadosWriter writer, IProcessosReader processosReader, IClientesReader clientesReader, IHistoricoReader historicoReader, IContatoCRMReader contatocrmReader, ILigacoesReader ligacoesReader, IAgendaReader agendaReader, IRecadosService service, CancellationToken token) =>
        {
            logger.Info("Recados: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Recados found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Recados_GetById").WithDisplayName("Get Recados By Id");
        group.MapPost("/AddAndUpdate", async (Models.Recados regRecados, string uri, IRecadosValidation validation, IRecadosWriter writer, IProcessosReader processosReader, IClientesReader clientesReader, IHistoricoReader historicoReader, IContatoCRMReader contatocrmReader, ILigacoesReader ligacoesReader, IAgendaReader agendaReader, IRecadosService service) =>
        {
            logger.LogInfo("Recados", "AddAndUpdate", $"regRecados = {regRecados}", uri);
            var result = await service.AddAndUpdate(regRecados, uri);
            if (result == null)
            {
                logger.LogWarn("Recados", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Recados_AddAndUpdate").WithDisplayName("Add or Update Recados");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IRecadosValidation validation, IRecadosWriter writer, IProcessosReader processosReader, IClientesReader clientesReader, IHistoricoReader historicoReader, IContatoCRMReader contatocrmReader, ILigacoesReader ligacoesReader, IAgendaReader agendaReader, IRecadosService service) =>
        {
            logger.LogInfo("Recados", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("Recados", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Recados_GetColumns").WithDisplayName("Get Recados Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IRecadosValidation validation, IRecadosWriter writer, IProcessosReader processosReader, IClientesReader clientesReader, IHistoricoReader historicoReader, IContatoCRMReader contatocrmReader, ILigacoesReader ligacoesReader, IAgendaReader agendaReader, IRecadosService service) =>
        {
            logger.LogInfo("Recados", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("Recados", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("Recados_UpdateColumns").WithDisplayName("Update Recados Columns");
        group.MapDelete("/Delete", async (int id, string uri, IRecadosValidation validation, IRecadosWriter writer, IProcessosReader processosReader, IClientesReader clientesReader, IHistoricoReader historicoReader, IContatoCRMReader contatocrmReader, ILigacoesReader ligacoesReader, IAgendaReader agendaReader, IRecadosService service) =>
        {
            logger.LogInfo("Recados", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Recados", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Recados_Delete").WithDisplayName("Delete Recados");
    }
}