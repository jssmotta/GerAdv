#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class FuncionariosEndpoints
{
    public static IEndpointRouteBuilder MapFuncionariosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Funcionarios").WithTags("Funcionarios").RequireAuthorization();
        MapFuncionariosRoutes(group);
        return app;
    }

    private static void MapFuncionariosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IFuncionariosValidation validation, IFuncionariosWriter writer, ICargosReader cargosReader, IFuncaoReader funcaoReader, IFuncionariosService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Funcionarios: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Funcionarios_GetAll").WithDisplayName("Get All Funcionarios");
        group.MapPost("/Filter", async (Filters.FilterFuncionarios filtro, string uri, IFuncionariosValidation validation, IFuncionariosWriter writer, ICargosReader cargosReader, IFuncaoReader funcaoReader, IFuncionariosService service) =>
        {
            logger.Info("Funcionarios: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Funcionarios_Filter").WithDisplayName("Filter Funcionarios");
        group.MapGet("/GetById/{id}", async (int id, string uri, IFuncionariosValidation validation, IFuncionariosWriter writer, ICargosReader cargosReader, IFuncaoReader funcaoReader, IFuncionariosService service, CancellationToken token) =>
        {
            logger.Info("Funcionarios: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Funcionarios found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Funcionarios_GetById").WithDisplayName("Get Funcionarios By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IFuncionariosValidation validation, IFuncionariosWriter writer, ICargosReader cargosReader, IFuncaoReader funcaoReader, IFuncionariosService service) =>
        {
            logger.Info("Funcionarios: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Funcionarios found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Funcionarios_GetByName").WithDisplayName("Get Funcionarios By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterFuncionarios? filtro, string uri, IFuncionariosValidation validation, IFuncionariosWriter writer, ICargosReader cargosReader, IFuncaoReader funcaoReader, IFuncionariosService service) =>
        {
            logger.Info("Funcionarios: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Funcionarios_GetListN").WithDisplayName("Get Funcionarios List N");
        group.MapPost("/AddAndUpdate", async (Models.Funcionarios regFuncionarios, string uri, IFuncionariosValidation validation, IFuncionariosWriter writer, ICargosReader cargosReader, IFuncaoReader funcaoReader, IFuncionariosService service) =>
        {
            logger.LogInfo("Funcionarios", "AddAndUpdate", $"regFuncionarios = {regFuncionarios}", uri);
            var result = await service.AddAndUpdate(regFuncionarios, uri);
            if (result == null)
            {
                logger.LogWarn("Funcionarios", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Funcionarios_AddAndUpdate").WithDisplayName("Add or Update Funcionarios");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IFuncionariosValidation validation, IFuncionariosWriter writer, ICargosReader cargosReader, IFuncaoReader funcaoReader, IFuncionariosService service) =>
        {
            logger.LogInfo("Funcionarios", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("Funcionarios", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Funcionarios_GetColumns").WithDisplayName("Get Funcionarios Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IFuncionariosValidation validation, IFuncionariosWriter writer, ICargosReader cargosReader, IFuncaoReader funcaoReader, IFuncionariosService service) =>
        {
            logger.LogInfo("Funcionarios", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("Funcionarios", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("Funcionarios_UpdateColumns").WithDisplayName("Update Funcionarios Columns");
        group.MapDelete("/Delete", async (int id, string uri, IFuncionariosValidation validation, IFuncionariosWriter writer, ICargosReader cargosReader, IFuncaoReader funcaoReader, IFuncionariosService service) =>
        {
            logger.LogInfo("Funcionarios", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Funcionarios", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Funcionarios_Delete").WithDisplayName("Delete Funcionarios");
    }
}