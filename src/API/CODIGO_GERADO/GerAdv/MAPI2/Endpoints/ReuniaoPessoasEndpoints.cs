#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ReuniaoPessoasEndpoints
{
    public static IEndpointRouteBuilder MapReuniaoPessoasEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ReuniaoPessoas").WithTags("ReuniaoPessoas").RequireAuthorization();
        MapReuniaoPessoasRoutes(group);
        return app;
    }

    private static void MapReuniaoPessoasRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IReuniaoPessoasValidation validation, IReuniaoPessoasWriter writer, IReuniaoReader reuniaoReader, IOperadorReader operadorReader, IReuniaoPessoasService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("ReuniaoPessoas: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ReuniaoPessoas_GetAll").WithDisplayName("Get All ReuniaoPessoas");
        group.MapPost("/Filter", async (Filters.FilterReuniaoPessoas filtro, string uri, IReuniaoPessoasValidation validation, IReuniaoPessoasWriter writer, IReuniaoReader reuniaoReader, IOperadorReader operadorReader, IReuniaoPessoasService service) =>
        {
            logger.Info("ReuniaoPessoas: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ReuniaoPessoas_Filter").WithDisplayName("Filter ReuniaoPessoas");
        group.MapGet("/GetById/{id}", async (int id, string uri, IReuniaoPessoasValidation validation, IReuniaoPessoasWriter writer, IReuniaoReader reuniaoReader, IOperadorReader operadorReader, IReuniaoPessoasService service, CancellationToken token) =>
        {
            logger.Info("ReuniaoPessoas: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ReuniaoPessoas found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ReuniaoPessoas_GetById").WithDisplayName("Get ReuniaoPessoas By Id");
        group.MapPost("/AddAndUpdate", async (Models.ReuniaoPessoas regReuniaoPessoas, string uri, IReuniaoPessoasValidation validation, IReuniaoPessoasWriter writer, IReuniaoReader reuniaoReader, IOperadorReader operadorReader, IReuniaoPessoasService service) =>
        {
            logger.LogInfo("ReuniaoPessoas", "AddAndUpdate", $"regReuniaoPessoas = {regReuniaoPessoas}", uri);
            var result = await service.AddAndUpdate(regReuniaoPessoas, uri);
            if (result == null)
            {
                logger.LogWarn("ReuniaoPessoas", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ReuniaoPessoas_AddAndUpdate").WithDisplayName("Add or Update ReuniaoPessoas");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IReuniaoPessoasValidation validation, IReuniaoPessoasWriter writer, IReuniaoReader reuniaoReader, IOperadorReader operadorReader, IReuniaoPessoasService service) =>
        {
            logger.LogInfo("ReuniaoPessoas", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("ReuniaoPessoas", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ReuniaoPessoas_GetColumns").WithDisplayName("Get ReuniaoPessoas Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IReuniaoPessoasValidation validation, IReuniaoPessoasWriter writer, IReuniaoReader reuniaoReader, IOperadorReader operadorReader, IReuniaoPessoasService service) =>
        {
            logger.LogInfo("ReuniaoPessoas", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("ReuniaoPessoas", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("ReuniaoPessoas_UpdateColumns").WithDisplayName("Update ReuniaoPessoas Columns");
        group.MapDelete("/Delete", async (int id, string uri, IReuniaoPessoasValidation validation, IReuniaoPessoasWriter writer, IReuniaoReader reuniaoReader, IOperadorReader operadorReader, IReuniaoPessoasService service) =>
        {
            logger.LogInfo("ReuniaoPessoas", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("ReuniaoPessoas", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ReuniaoPessoas_Delete").WithDisplayName("Delete ReuniaoPessoas");
    }
}