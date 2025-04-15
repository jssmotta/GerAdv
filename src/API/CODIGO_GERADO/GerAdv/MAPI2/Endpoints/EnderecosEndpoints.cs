#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class EnderecosEndpoints
{
    public static IEndpointRouteBuilder MapEnderecosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Enderecos").WithTags("Enderecos").RequireAuthorization();
        MapEnderecosRoutes(group);
        return app;
    }

    private static void MapEnderecosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IEnderecosValidation validation, IEnderecosWriter writer, IEnderecosService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Enderecos: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Enderecos_GetAll").WithDisplayName("Get All Enderecos");
        group.MapPost("/Filter", async (Filters.FilterEnderecos filtro, string uri, IEnderecosValidation validation, IEnderecosWriter writer, IEnderecosService service) =>
        {
            logger.Info("Enderecos: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Enderecos_Filter").WithDisplayName("Filter Enderecos");
        group.MapGet("/GetById/{id}", async (int id, string uri, IEnderecosValidation validation, IEnderecosWriter writer, IEnderecosService service, CancellationToken token) =>
        {
            logger.Info("Enderecos: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Enderecos found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Enderecos_GetById").WithDisplayName("Get Enderecos By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IEnderecosValidation validation, IEnderecosWriter writer, IEnderecosService service) =>
        {
            logger.Info("Enderecos: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Enderecos found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Enderecos_GetByName").WithDisplayName("Get Enderecos By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterEnderecos? filtro, string uri, IEnderecosValidation validation, IEnderecosWriter writer, IEnderecosService service) =>
        {
            logger.Info("Enderecos: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Enderecos_GetListN").WithDisplayName("Get Enderecos List N");
        group.MapPost("/AddAndUpdate", async (Models.Enderecos regEnderecos, string uri, IEnderecosValidation validation, IEnderecosWriter writer, IEnderecosService service) =>
        {
            logger.LogInfo("Enderecos", "AddAndUpdate", $"regEnderecos = {regEnderecos}", uri);
            var result = await service.AddAndUpdate(regEnderecos, uri);
            if (result == null)
            {
                logger.LogWarn("Enderecos", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Enderecos_AddAndUpdate").WithDisplayName("Add or Update Enderecos");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IEnderecosValidation validation, IEnderecosWriter writer, IEnderecosService service) =>
        {
            logger.LogInfo("Enderecos", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("Enderecos", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Enderecos_GetColumns").WithDisplayName("Get Enderecos Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IEnderecosValidation validation, IEnderecosWriter writer, IEnderecosService service) =>
        {
            logger.LogInfo("Enderecos", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("Enderecos", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("Enderecos_UpdateColumns").WithDisplayName("Update Enderecos Columns");
        group.MapDelete("/Delete", async (int id, string uri, IEnderecosValidation validation, IEnderecosWriter writer, IEnderecosService service) =>
        {
            logger.LogInfo("Enderecos", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Enderecos", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Enderecos_Delete").WithDisplayName("Delete Enderecos");
    }
}