#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class BensMateriaisEndpoints
{
    public static IEndpointRouteBuilder MapBensMateriaisEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/BensMateriais").WithTags("BensMateriais").RequireAuthorization();
        MapBensMateriaisRoutes(group);
        return app;
    }

    private static void MapBensMateriaisRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IBensMateriaisValidation validation, IBensMateriaisWriter writer, IBensClassificacaoReader bensclassificacaoReader, IFornecedoresReader fornecedoresReader, IBensMateriaisService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("BensMateriais: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("BensMateriais_GetAll").WithDisplayName("Get All BensMateriais");
        group.MapPost("/Filter", async (Filters.FilterBensMateriais filtro, string uri, IBensMateriaisValidation validation, IBensMateriaisWriter writer, IBensClassificacaoReader bensclassificacaoReader, IFornecedoresReader fornecedoresReader, IBensMateriaisService service) =>
        {
            logger.Info("BensMateriais: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("BensMateriais_Filter").WithDisplayName("Filter BensMateriais");
        group.MapGet("/GetById/{id}", async (int id, string uri, IBensMateriaisValidation validation, IBensMateriaisWriter writer, IBensClassificacaoReader bensclassificacaoReader, IFornecedoresReader fornecedoresReader, IBensMateriaisService service, CancellationToken token) =>
        {
            logger.Info("BensMateriais: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No BensMateriais found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("BensMateriais_GetById").WithDisplayName("Get BensMateriais By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IBensMateriaisValidation validation, IBensMateriaisWriter writer, IBensClassificacaoReader bensclassificacaoReader, IFornecedoresReader fornecedoresReader, IBensMateriaisService service) =>
        {
            logger.Info("BensMateriais: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No BensMateriais found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("BensMateriais_GetByName").WithDisplayName("Get BensMateriais By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterBensMateriais? filtro, string uri, IBensMateriaisValidation validation, IBensMateriaisWriter writer, IBensClassificacaoReader bensclassificacaoReader, IFornecedoresReader fornecedoresReader, IBensMateriaisService service) =>
        {
            logger.Info("BensMateriais: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("BensMateriais_GetListN").WithDisplayName("Get BensMateriais List N");
        group.MapPost("/AddAndUpdate", async (Models.BensMateriais regBensMateriais, string uri, IBensMateriaisValidation validation, IBensMateriaisWriter writer, IBensClassificacaoReader bensclassificacaoReader, IFornecedoresReader fornecedoresReader, IBensMateriaisService service) =>
        {
            logger.LogInfo("BensMateriais", "AddAndUpdate", $"regBensMateriais = {regBensMateriais}", uri);
            var result = await service.AddAndUpdate(regBensMateriais, uri);
            if (result == null)
            {
                logger.LogWarn("BensMateriais", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("BensMateriais_AddAndUpdate").WithDisplayName("Add or Update BensMateriais");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IBensMateriaisValidation validation, IBensMateriaisWriter writer, IBensClassificacaoReader bensclassificacaoReader, IFornecedoresReader fornecedoresReader, IBensMateriaisService service) =>
        {
            logger.LogInfo("BensMateriais", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("BensMateriais", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("BensMateriais_GetColumns").WithDisplayName("Get BensMateriais Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IBensMateriaisValidation validation, IBensMateriaisWriter writer, IBensClassificacaoReader bensclassificacaoReader, IFornecedoresReader fornecedoresReader, IBensMateriaisService service) =>
        {
            logger.LogInfo("BensMateriais", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("BensMateriais", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("BensMateriais_UpdateColumns").WithDisplayName("Update BensMateriais Columns");
        group.MapDelete("/Delete", async (int id, string uri, IBensMateriaisValidation validation, IBensMateriaisWriter writer, IBensClassificacaoReader bensclassificacaoReader, IFornecedoresReader fornecedoresReader, IBensMateriaisService service) =>
        {
            logger.LogInfo("BensMateriais", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("BensMateriais", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("BensMateriais_Delete").WithDisplayName("Delete BensMateriais");
    }
}