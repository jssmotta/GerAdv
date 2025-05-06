#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class EMPClassRiscosEndpoints
{
    public static IEndpointRouteBuilder MapEMPClassRiscosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/EMPClassRiscos").WithTags("EMPClassRiscos").RequireAuthorization();
        MapEMPClassRiscosRoutes(group);
        return app;
    }

    private static void MapEMPClassRiscosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IEMPClassRiscosValidation validation, IEMPClassRiscosWriter writer, IEMPClassRiscosService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("EMPClassRiscos: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("EMPClassRiscos_GetAll").WithDisplayName("Get All EMPClassRiscos");
        group.MapPost("/Filter", async (Filters.FilterEMPClassRiscos filtro, string uri, IEMPClassRiscosValidation validation, IEMPClassRiscosWriter writer, IEMPClassRiscosService service) =>
        {
            logger.Info("EMPClassRiscos: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("EMPClassRiscos_Filter").WithDisplayName("Filter EMPClassRiscos");
        group.MapGet("/GetById/{id}", async (int id, string uri, IEMPClassRiscosValidation validation, IEMPClassRiscosWriter writer, IEMPClassRiscosService service, CancellationToken token) =>
        {
            logger.Info("EMPClassRiscos: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No EMPClassRiscos found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("EMPClassRiscos_GetById").WithDisplayName("Get EMPClassRiscos By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IEMPClassRiscosValidation validation, IEMPClassRiscosWriter writer, IEMPClassRiscosService service) =>
        {
            logger.Info("EMPClassRiscos: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No EMPClassRiscos found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("EMPClassRiscos_GetByName").WithDisplayName("Get EMPClassRiscos By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterEMPClassRiscos? filtro, string uri, IEMPClassRiscosValidation validation, IEMPClassRiscosWriter writer, IEMPClassRiscosService service) =>
        {
            logger.Info("EMPClassRiscos: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("EMPClassRiscos_GetListN").WithDisplayName("Get EMPClassRiscos List N");
        group.MapPost("/AddAndUpdate", async (Models.EMPClassRiscos regEMPClassRiscos, string uri, IEMPClassRiscosValidation validation, IEMPClassRiscosWriter writer, IEMPClassRiscosService service) =>
        {
            logger.LogInfo("EMPClassRiscos", "AddAndUpdate", $"regEMPClassRiscos = {regEMPClassRiscos}", uri);
            var result = await service.AddAndUpdate(regEMPClassRiscos, uri);
            if (result == null)
            {
                logger.LogWarn("EMPClassRiscos", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("EMPClassRiscos_AddAndUpdate").WithDisplayName("Add or Update EMPClassRiscos");
        group.MapDelete("/Delete", async (int id, string uri, IEMPClassRiscosValidation validation, IEMPClassRiscosWriter writer, IEMPClassRiscosService service) =>
        {
            logger.LogInfo("EMPClassRiscos", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("EMPClassRiscos", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("EMPClassRiscos_Delete").WithDisplayName("Delete EMPClassRiscos");
    }
}