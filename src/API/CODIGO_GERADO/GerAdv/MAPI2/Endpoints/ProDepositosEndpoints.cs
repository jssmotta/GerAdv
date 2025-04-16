#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ProDepositosEndpoints
{
    public static IEndpointRouteBuilder MapProDepositosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ProDepositos").WithTags("ProDepositos").RequireAuthorization();
        MapProDepositosRoutes(group);
        return app;
    }

    private static void MapProDepositosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IProDepositosValidation validation, IProDepositosWriter writer, IProcessosReader processosReader, IFaseReader faseReader, ITipoProDespositoReader tipoprodespositoReader, IProDepositosService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("ProDepositos: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProDepositos_GetAll").WithDisplayName("Get All ProDepositos");
        group.MapPost("/Filter", async (Filters.FilterProDepositos filtro, string uri, IProDepositosValidation validation, IProDepositosWriter writer, IProcessosReader processosReader, IFaseReader faseReader, ITipoProDespositoReader tipoprodespositoReader, IProDepositosService service) =>
        {
            logger.Info("ProDepositos: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProDepositos_Filter").WithDisplayName("Filter ProDepositos");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProDepositosValidation validation, IProDepositosWriter writer, IProcessosReader processosReader, IFaseReader faseReader, ITipoProDespositoReader tipoprodespositoReader, IProDepositosService service, CancellationToken token) =>
        {
            logger.Info("ProDepositos: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ProDepositos found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProDepositos_GetById").WithDisplayName("Get ProDepositos By Id");
        group.MapPost("/AddAndUpdate", async (Models.ProDepositos regProDepositos, string uri, IProDepositosValidation validation, IProDepositosWriter writer, IProcessosReader processosReader, IFaseReader faseReader, ITipoProDespositoReader tipoprodespositoReader, IProDepositosService service) =>
        {
            logger.LogInfo("ProDepositos", "AddAndUpdate", $"regProDepositos = {regProDepositos}", uri);
            var result = await service.AddAndUpdate(regProDepositos, uri);
            if (result == null)
            {
                logger.LogWarn("ProDepositos", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProDepositos_AddAndUpdate").WithDisplayName("Add or Update ProDepositos");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IProDepositosValidation validation, IProDepositosWriter writer, IProcessosReader processosReader, IFaseReader faseReader, ITipoProDespositoReader tipoprodespositoReader, IProDepositosService service) =>
        {
            logger.LogInfo("ProDepositos", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("ProDepositos", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProDepositos_GetColumns").WithDisplayName("Get ProDepositos Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IProDepositosValidation validation, IProDepositosWriter writer, IProcessosReader processosReader, IFaseReader faseReader, ITipoProDespositoReader tipoprodespositoReader, IProDepositosService service) =>
        {
            logger.LogInfo("ProDepositos", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("ProDepositos", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("ProDepositos_UpdateColumns").WithDisplayName("Update ProDepositos Columns");
        group.MapDelete("/Delete", async (int id, string uri, IProDepositosValidation validation, IProDepositosWriter writer, IProcessosReader processosReader, IFaseReader faseReader, ITipoProDespositoReader tipoprodespositoReader, IProDepositosService service) =>
        {
            logger.LogInfo("ProDepositos", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("ProDepositos", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProDepositos_Delete").WithDisplayName("Delete ProDepositos");
    }
}