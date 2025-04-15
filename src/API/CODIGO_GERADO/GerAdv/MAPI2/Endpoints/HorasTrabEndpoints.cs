#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class HorasTrabEndpoints
{
    public static IEndpointRouteBuilder MapHorasTrabEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/HorasTrab").WithTags("HorasTrab").RequireAuthorization();
        MapHorasTrabRoutes(group);
        return app;
    }

    private static void MapHorasTrabRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IHorasTrabValidation validation, IHorasTrabWriter writer, IClientesReader clientesReader, IProcessosReader processosReader, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, IServicosReader servicosReader, IHorasTrabService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("HorasTrab: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("HorasTrab_GetAll").WithDisplayName("Get All HorasTrab");
        group.MapPost("/Filter", async (Filters.FilterHorasTrab filtro, string uri, IHorasTrabValidation validation, IHorasTrabWriter writer, IClientesReader clientesReader, IProcessosReader processosReader, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, IServicosReader servicosReader, IHorasTrabService service) =>
        {
            logger.Info("HorasTrab: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("HorasTrab_Filter").WithDisplayName("Filter HorasTrab");
        group.MapGet("/GetById/{id}", async (int id, string uri, IHorasTrabValidation validation, IHorasTrabWriter writer, IClientesReader clientesReader, IProcessosReader processosReader, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, IServicosReader servicosReader, IHorasTrabService service, CancellationToken token) =>
        {
            logger.Info("HorasTrab: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No HorasTrab found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("HorasTrab_GetById").WithDisplayName("Get HorasTrab By Id");
        group.MapPost("/AddAndUpdate", async (Models.HorasTrab regHorasTrab, string uri, IHorasTrabValidation validation, IHorasTrabWriter writer, IClientesReader clientesReader, IProcessosReader processosReader, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, IServicosReader servicosReader, IHorasTrabService service) =>
        {
            logger.LogInfo("HorasTrab", "AddAndUpdate", $"regHorasTrab = {regHorasTrab}", uri);
            var result = await service.AddAndUpdate(regHorasTrab, uri);
            if (result == null)
            {
                logger.LogWarn("HorasTrab", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("HorasTrab_AddAndUpdate").WithDisplayName("Add or Update HorasTrab");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IHorasTrabValidation validation, IHorasTrabWriter writer, IClientesReader clientesReader, IProcessosReader processosReader, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, IServicosReader servicosReader, IHorasTrabService service) =>
        {
            logger.LogInfo("HorasTrab", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("HorasTrab", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("HorasTrab_GetColumns").WithDisplayName("Get HorasTrab Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IHorasTrabValidation validation, IHorasTrabWriter writer, IClientesReader clientesReader, IProcessosReader processosReader, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, IServicosReader servicosReader, IHorasTrabService service) =>
        {
            logger.LogInfo("HorasTrab", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("HorasTrab", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("HorasTrab_UpdateColumns").WithDisplayName("Update HorasTrab Columns");
        group.MapDelete("/Delete", async (int id, string uri, IHorasTrabValidation validation, IHorasTrabWriter writer, IClientesReader clientesReader, IProcessosReader processosReader, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, IServicosReader servicosReader, IHorasTrabService service) =>
        {
            logger.LogInfo("HorasTrab", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("HorasTrab", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("HorasTrab_Delete").WithDisplayName("Delete HorasTrab");
    }
}