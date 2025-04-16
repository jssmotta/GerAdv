#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ViaRecebimentoEndpoints
{
    public static IEndpointRouteBuilder MapViaRecebimentoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ViaRecebimento").WithTags("ViaRecebimento").RequireAuthorization();
        MapViaRecebimentoRoutes(group);
        return app;
    }

    private static void MapViaRecebimentoRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IViaRecebimentoValidation validation, IViaRecebimentoWriter writer, IViaRecebimentoService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("ViaRecebimento: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ViaRecebimento_GetAll").WithDisplayName("Get All ViaRecebimento");
        group.MapPost("/Filter", async (Filters.FilterViaRecebimento filtro, string uri, IViaRecebimentoValidation validation, IViaRecebimentoWriter writer, IViaRecebimentoService service) =>
        {
            logger.Info("ViaRecebimento: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ViaRecebimento_Filter").WithDisplayName("Filter ViaRecebimento");
        group.MapGet("/GetById/{id}", async (int id, string uri, IViaRecebimentoValidation validation, IViaRecebimentoWriter writer, IViaRecebimentoService service, CancellationToken token) =>
        {
            logger.Info("ViaRecebimento: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ViaRecebimento found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ViaRecebimento_GetById").WithDisplayName("Get ViaRecebimento By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IViaRecebimentoValidation validation, IViaRecebimentoWriter writer, IViaRecebimentoService service) =>
        {
            logger.Info("ViaRecebimento: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No ViaRecebimento found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ViaRecebimento_GetByName").WithDisplayName("Get ViaRecebimento By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterViaRecebimento? filtro, string uri, IViaRecebimentoValidation validation, IViaRecebimentoWriter writer, IViaRecebimentoService service) =>
        {
            logger.Info("ViaRecebimento: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("ViaRecebimento_GetListN").WithDisplayName("Get ViaRecebimento List N");
        group.MapPost("/AddAndUpdate", async (Models.ViaRecebimento regViaRecebimento, string uri, IViaRecebimentoValidation validation, IViaRecebimentoWriter writer, IViaRecebimentoService service) =>
        {
            logger.LogInfo("ViaRecebimento", "AddAndUpdate", $"regViaRecebimento = {regViaRecebimento}", uri);
            var result = await service.AddAndUpdate(regViaRecebimento, uri);
            if (result == null)
            {
                logger.LogWarn("ViaRecebimento", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ViaRecebimento_AddAndUpdate").WithDisplayName("Add or Update ViaRecebimento");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IViaRecebimentoValidation validation, IViaRecebimentoWriter writer, IViaRecebimentoService service) =>
        {
            logger.LogInfo("ViaRecebimento", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("ViaRecebimento", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ViaRecebimento_GetColumns").WithDisplayName("Get ViaRecebimento Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IViaRecebimentoValidation validation, IViaRecebimentoWriter writer, IViaRecebimentoService service) =>
        {
            logger.LogInfo("ViaRecebimento", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("ViaRecebimento", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("ViaRecebimento_UpdateColumns").WithDisplayName("Update ViaRecebimento Columns");
        group.MapDelete("/Delete", async (int id, string uri, IViaRecebimentoValidation validation, IViaRecebimentoWriter writer, IViaRecebimentoService service) =>
        {
            logger.LogInfo("ViaRecebimento", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("ViaRecebimento", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ViaRecebimento_Delete").WithDisplayName("Delete ViaRecebimento");
    }
}