#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class OutrasPartesClienteEndpoints
{
    public static IEndpointRouteBuilder MapOutrasPartesClienteEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/OutrasPartesCliente").WithTags("OutrasPartesCliente").RequireAuthorization();
        MapOutrasPartesClienteRoutes(group);
        return app;
    }

    private static void MapOutrasPartesClienteRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IOutrasPartesClienteValidation validation, IOutrasPartesClienteWriter writer, IOutrasPartesClienteService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("OutrasPartesCliente: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("OutrasPartesCliente_GetAll").WithDisplayName("Get All OutrasPartesCliente");
        group.MapPost("/Filter", async (Filters.FilterOutrasPartesCliente filtro, string uri, IOutrasPartesClienteValidation validation, IOutrasPartesClienteWriter writer, IOutrasPartesClienteService service) =>
        {
            logger.Info("OutrasPartesCliente: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("OutrasPartesCliente_Filter").WithDisplayName("Filter OutrasPartesCliente");
        group.MapGet("/GetById/{id}", async (int id, string uri, IOutrasPartesClienteValidation validation, IOutrasPartesClienteWriter writer, IOutrasPartesClienteService service, CancellationToken token) =>
        {
            logger.Info("OutrasPartesCliente: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No OutrasPartesCliente found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OutrasPartesCliente_GetById").WithDisplayName("Get OutrasPartesCliente By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IOutrasPartesClienteValidation validation, IOutrasPartesClienteWriter writer, IOutrasPartesClienteService service) =>
        {
            logger.Info("OutrasPartesCliente: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No OutrasPartesCliente found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OutrasPartesCliente_GetByName").WithDisplayName("Get OutrasPartesCliente By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterOutrasPartesCliente? filtro, string uri, IOutrasPartesClienteValidation validation, IOutrasPartesClienteWriter writer, IOutrasPartesClienteService service) =>
        {
            logger.Info("OutrasPartesCliente: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("OutrasPartesCliente_GetListN").WithDisplayName("Get OutrasPartesCliente List N");
        group.MapPost("/AddAndUpdate", async (Models.OutrasPartesCliente regOutrasPartesCliente, string uri, IOutrasPartesClienteValidation validation, IOutrasPartesClienteWriter writer, IOutrasPartesClienteService service) =>
        {
            logger.LogInfo("OutrasPartesCliente", "AddAndUpdate", $"regOutrasPartesCliente = {regOutrasPartesCliente}", uri);
            var result = await service.AddAndUpdate(regOutrasPartesCliente, uri);
            if (result == null)
            {
                logger.LogWarn("OutrasPartesCliente", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("OutrasPartesCliente_AddAndUpdate").WithDisplayName("Add or Update OutrasPartesCliente");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IOutrasPartesClienteValidation validation, IOutrasPartesClienteWriter writer, IOutrasPartesClienteService service) =>
        {
            logger.LogInfo("OutrasPartesCliente", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("OutrasPartesCliente", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OutrasPartesCliente_GetColumns").WithDisplayName("Get OutrasPartesCliente Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IOutrasPartesClienteValidation validation, IOutrasPartesClienteWriter writer, IOutrasPartesClienteService service) =>
        {
            logger.LogInfo("OutrasPartesCliente", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("OutrasPartesCliente", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("OutrasPartesCliente_UpdateColumns").WithDisplayName("Update OutrasPartesCliente Columns");
        group.MapDelete("/Delete", async (int id, string uri, IOutrasPartesClienteValidation validation, IOutrasPartesClienteWriter writer, IOutrasPartesClienteService service) =>
        {
            logger.LogInfo("OutrasPartesCliente", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("OutrasPartesCliente", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("OutrasPartesCliente_Delete").WithDisplayName("Delete OutrasPartesCliente");
    }
}