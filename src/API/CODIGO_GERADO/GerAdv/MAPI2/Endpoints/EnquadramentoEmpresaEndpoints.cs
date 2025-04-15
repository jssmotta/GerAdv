#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class EnquadramentoEmpresaEndpoints
{
    public static IEndpointRouteBuilder MapEnquadramentoEmpresaEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/EnquadramentoEmpresa").WithTags("EnquadramentoEmpresa").RequireAuthorization();
        MapEnquadramentoEmpresaRoutes(group);
        return app;
    }

    private static void MapEnquadramentoEmpresaRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IEnquadramentoEmpresaValidation validation, IEnquadramentoEmpresaWriter writer, IEnquadramentoEmpresaService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("EnquadramentoEmpresa: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("EnquadramentoEmpresa_GetAll").WithDisplayName("Get All EnquadramentoEmpresa");
        group.MapPost("/Filter", async (Filters.FilterEnquadramentoEmpresa filtro, string uri, IEnquadramentoEmpresaValidation validation, IEnquadramentoEmpresaWriter writer, IEnquadramentoEmpresaService service) =>
        {
            logger.Info("EnquadramentoEmpresa: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("EnquadramentoEmpresa_Filter").WithDisplayName("Filter EnquadramentoEmpresa");
        group.MapGet("/GetById/{id}", async (int id, string uri, IEnquadramentoEmpresaValidation validation, IEnquadramentoEmpresaWriter writer, IEnquadramentoEmpresaService service, CancellationToken token) =>
        {
            logger.Info("EnquadramentoEmpresa: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No EnquadramentoEmpresa found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("EnquadramentoEmpresa_GetById").WithDisplayName("Get EnquadramentoEmpresa By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IEnquadramentoEmpresaValidation validation, IEnquadramentoEmpresaWriter writer, IEnquadramentoEmpresaService service) =>
        {
            logger.Info("EnquadramentoEmpresa: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No EnquadramentoEmpresa found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("EnquadramentoEmpresa_GetByName").WithDisplayName("Get EnquadramentoEmpresa By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterEnquadramentoEmpresa? filtro, string uri, IEnquadramentoEmpresaValidation validation, IEnquadramentoEmpresaWriter writer, IEnquadramentoEmpresaService service) =>
        {
            logger.Info("EnquadramentoEmpresa: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("EnquadramentoEmpresa_GetListN").WithDisplayName("Get EnquadramentoEmpresa List N");
        group.MapPost("/AddAndUpdate", async (Models.EnquadramentoEmpresa regEnquadramentoEmpresa, string uri, IEnquadramentoEmpresaValidation validation, IEnquadramentoEmpresaWriter writer, IEnquadramentoEmpresaService service) =>
        {
            logger.LogInfo("EnquadramentoEmpresa", "AddAndUpdate", $"regEnquadramentoEmpresa = {regEnquadramentoEmpresa}", uri);
            var result = await service.AddAndUpdate(regEnquadramentoEmpresa, uri);
            if (result == null)
            {
                logger.LogWarn("EnquadramentoEmpresa", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("EnquadramentoEmpresa_AddAndUpdate").WithDisplayName("Add or Update EnquadramentoEmpresa");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IEnquadramentoEmpresaValidation validation, IEnquadramentoEmpresaWriter writer, IEnquadramentoEmpresaService service) =>
        {
            logger.LogInfo("EnquadramentoEmpresa", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("EnquadramentoEmpresa", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("EnquadramentoEmpresa_GetColumns").WithDisplayName("Get EnquadramentoEmpresa Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IEnquadramentoEmpresaValidation validation, IEnquadramentoEmpresaWriter writer, IEnquadramentoEmpresaService service) =>
        {
            logger.LogInfo("EnquadramentoEmpresa", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("EnquadramentoEmpresa", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("EnquadramentoEmpresa_UpdateColumns").WithDisplayName("Update EnquadramentoEmpresa Columns");
        group.MapDelete("/Delete", async (int id, string uri, IEnquadramentoEmpresaValidation validation, IEnquadramentoEmpresaWriter writer, IEnquadramentoEmpresaService service) =>
        {
            logger.LogInfo("EnquadramentoEmpresa", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("EnquadramentoEmpresa", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("EnquadramentoEmpresa_Delete").WithDisplayName("Delete EnquadramentoEmpresa");
    }
}