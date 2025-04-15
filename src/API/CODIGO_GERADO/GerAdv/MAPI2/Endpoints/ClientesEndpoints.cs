#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ClientesEndpoints
{
    public static IEndpointRouteBuilder MapClientesEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Clientes").WithTags("Clientes").RequireAuthorization();
        MapClientesRoutes(group);
        return app;
    }

    private static void MapClientesRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IClientesValidation validation, IClientesWriter writer, IRegimeTributacaoReader regimetributacaoReader, IEnquadramentoEmpresaReader enquadramentoempresaReader, IClientesService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Clientes: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Clientes_GetAll").WithDisplayName("Get All Clientes");
        group.MapPost("/Filter", async (Filters.FilterClientes filtro, string uri, IClientesValidation validation, IClientesWriter writer, IRegimeTributacaoReader regimetributacaoReader, IEnquadramentoEmpresaReader enquadramentoempresaReader, IClientesService service) =>
        {
            logger.Info("Clientes: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Clientes_Filter").WithDisplayName("Filter Clientes");
        group.MapGet("/GetById/{id}", async (int id, string uri, IClientesValidation validation, IClientesWriter writer, IRegimeTributacaoReader regimetributacaoReader, IEnquadramentoEmpresaReader enquadramentoempresaReader, IClientesService service, CancellationToken token) =>
        {
            logger.Info("Clientes: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Clientes found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Clientes_GetById").WithDisplayName("Get Clientes By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IClientesValidation validation, IClientesWriter writer, IRegimeTributacaoReader regimetributacaoReader, IEnquadramentoEmpresaReader enquadramentoempresaReader, IClientesService service) =>
        {
            logger.Info("Clientes: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Clientes found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Clientes_GetByName").WithDisplayName("Get Clientes By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterClientes? filtro, string uri, IClientesValidation validation, IClientesWriter writer, IRegimeTributacaoReader regimetributacaoReader, IEnquadramentoEmpresaReader enquadramentoempresaReader, IClientesService service) =>
        {
            logger.Info("Clientes: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Clientes_GetListN").WithDisplayName("Get Clientes List N");
        group.MapPost("/AddAndUpdate", async (Models.Clientes regClientes, string uri, IClientesValidation validation, IClientesWriter writer, IRegimeTributacaoReader regimetributacaoReader, IEnquadramentoEmpresaReader enquadramentoempresaReader, IClientesService service) =>
        {
            logger.LogInfo("Clientes", "AddAndUpdate", $"regClientes = {regClientes}", uri);
            var result = await service.AddAndUpdate(regClientes, uri);
            if (result == null)
            {
                logger.LogWarn("Clientes", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Clientes_AddAndUpdate").WithDisplayName("Add or Update Clientes");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IClientesValidation validation, IClientesWriter writer, IRegimeTributacaoReader regimetributacaoReader, IEnquadramentoEmpresaReader enquadramentoempresaReader, IClientesService service) =>
        {
            logger.LogInfo("Clientes", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("Clientes", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Clientes_GetColumns").WithDisplayName("Get Clientes Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IClientesValidation validation, IClientesWriter writer, IRegimeTributacaoReader regimetributacaoReader, IEnquadramentoEmpresaReader enquadramentoempresaReader, IClientesService service) =>
        {
            logger.LogInfo("Clientes", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("Clientes", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("Clientes_UpdateColumns").WithDisplayName("Update Clientes Columns");
        group.MapDelete("/Delete", async (int id, string uri, IClientesValidation validation, IClientesWriter writer, IRegimeTributacaoReader regimetributacaoReader, IEnquadramentoEmpresaReader enquadramentoempresaReader, IClientesService service) =>
        {
            logger.LogInfo("Clientes", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Clientes", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Clientes_Delete").WithDisplayName("Delete Clientes");
    }
}