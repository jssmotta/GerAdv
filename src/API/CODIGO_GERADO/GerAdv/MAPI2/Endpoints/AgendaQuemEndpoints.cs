#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class AgendaQuemEndpoints
{
    public static IEndpointRouteBuilder MapAgendaQuemEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/AgendaQuem").WithTags("AgendaQuem").RequireAuthorization();
        MapAgendaQuemRoutes(group);
        return app;
    }

    private static void MapAgendaQuemRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IAgendaQuemValidation validation, IAgendaQuemWriter writer, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, IPrepostosReader prepostosReader, IAgendaQuemService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("AgendaQuem: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("AgendaQuem_GetAll").WithDisplayName("Get All AgendaQuem");
        group.MapPost("/Filter", async (Filters.FilterAgendaQuem filtro, string uri, IAgendaQuemValidation validation, IAgendaQuemWriter writer, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, IPrepostosReader prepostosReader, IAgendaQuemService service) =>
        {
            logger.Info("AgendaQuem: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("AgendaQuem_Filter").WithDisplayName("Filter AgendaQuem");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAgendaQuemValidation validation, IAgendaQuemWriter writer, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, IPrepostosReader prepostosReader, IAgendaQuemService service, CancellationToken token) =>
        {
            logger.Info("AgendaQuem: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No AgendaQuem found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AgendaQuem_GetById").WithDisplayName("Get AgendaQuem By Id");
        group.MapPost("/AddAndUpdate", async (Models.AgendaQuem regAgendaQuem, string uri, IAgendaQuemValidation validation, IAgendaQuemWriter writer, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, IPrepostosReader prepostosReader, IAgendaQuemService service) =>
        {
            logger.LogInfo("AgendaQuem", "AddAndUpdate", $"regAgendaQuem = {regAgendaQuem}", uri);
            var result = await service.AddAndUpdate(regAgendaQuem, uri);
            if (result == null)
            {
                logger.LogWarn("AgendaQuem", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("AgendaQuem_AddAndUpdate").WithDisplayName("Add or Update AgendaQuem");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IAgendaQuemValidation validation, IAgendaQuemWriter writer, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, IPrepostosReader prepostosReader, IAgendaQuemService service) =>
        {
            logger.LogInfo("AgendaQuem", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("AgendaQuem", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AgendaQuem_GetColumns").WithDisplayName("Get AgendaQuem Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IAgendaQuemValidation validation, IAgendaQuemWriter writer, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, IPrepostosReader prepostosReader, IAgendaQuemService service) =>
        {
            logger.LogInfo("AgendaQuem", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("AgendaQuem", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("AgendaQuem_UpdateColumns").WithDisplayName("Update AgendaQuem Columns");
        group.MapDelete("/Delete", async (int id, string uri, IAgendaQuemValidation validation, IAgendaQuemWriter writer, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, IPrepostosReader prepostosReader, IAgendaQuemService service) =>
        {
            logger.LogInfo("AgendaQuem", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("AgendaQuem", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("AgendaQuem_Delete").WithDisplayName("Delete AgendaQuem");
    }
}