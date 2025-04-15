#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class AdvogadosEndpoints
{
    public static IEndpointRouteBuilder MapAdvogadosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Advogados").WithTags("Advogados").RequireAuthorization();
        MapAdvogadosRoutes(group);
        return app;
    }

    private static void MapAdvogadosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IAdvogadosValidation validation, IAdvogadosWriter writer, ICargosReader cargosReader, IEscritoriosReader escritoriosReader, IAdvogadosService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Advogados: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Advogados_GetAll").WithDisplayName("Get All Advogados");
        group.MapPost("/Filter", async (Filters.FilterAdvogados filtro, string uri, IAdvogadosValidation validation, IAdvogadosWriter writer, ICargosReader cargosReader, IEscritoriosReader escritoriosReader, IAdvogadosService service) =>
        {
            logger.Info("Advogados: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Advogados_Filter").WithDisplayName("Filter Advogados");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAdvogadosValidation validation, IAdvogadosWriter writer, ICargosReader cargosReader, IEscritoriosReader escritoriosReader, IAdvogadosService service, CancellationToken token) =>
        {
            logger.Info("Advogados: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Advogados found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Advogados_GetById").WithDisplayName("Get Advogados By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IAdvogadosValidation validation, IAdvogadosWriter writer, ICargosReader cargosReader, IEscritoriosReader escritoriosReader, IAdvogadosService service) =>
        {
            logger.Info("Advogados: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Advogados found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Advogados_GetByName").WithDisplayName("Get Advogados By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterAdvogados? filtro, string uri, IAdvogadosValidation validation, IAdvogadosWriter writer, ICargosReader cargosReader, IEscritoriosReader escritoriosReader, IAdvogadosService service) =>
        {
            logger.Info("Advogados: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Advogados_GetListN").WithDisplayName("Get Advogados List N");
        group.MapPost("/AddAndUpdate", async (Models.Advogados regAdvogados, string uri, IAdvogadosValidation validation, IAdvogadosWriter writer, ICargosReader cargosReader, IEscritoriosReader escritoriosReader, IAdvogadosService service) =>
        {
            logger.LogInfo("Advogados", "AddAndUpdate", $"regAdvogados = {regAdvogados}", uri);
            var result = await service.AddAndUpdate(regAdvogados, uri);
            if (result == null)
            {
                logger.LogWarn("Advogados", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Advogados_AddAndUpdate").WithDisplayName("Add or Update Advogados");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IAdvogadosValidation validation, IAdvogadosWriter writer, ICargosReader cargosReader, IEscritoriosReader escritoriosReader, IAdvogadosService service) =>
        {
            logger.LogInfo("Advogados", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("Advogados", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Advogados_GetColumns").WithDisplayName("Get Advogados Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IAdvogadosValidation validation, IAdvogadosWriter writer, ICargosReader cargosReader, IEscritoriosReader escritoriosReader, IAdvogadosService service) =>
        {
            logger.LogInfo("Advogados", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("Advogados", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("Advogados_UpdateColumns").WithDisplayName("Update Advogados Columns");
        group.MapDelete("/Delete", async (int id, string uri, IAdvogadosValidation validation, IAdvogadosWriter writer, ICargosReader cargosReader, IEscritoriosReader escritoriosReader, IAdvogadosService service) =>
        {
            logger.LogInfo("Advogados", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Advogados", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Advogados_Delete").WithDisplayName("Delete Advogados");
    }
}