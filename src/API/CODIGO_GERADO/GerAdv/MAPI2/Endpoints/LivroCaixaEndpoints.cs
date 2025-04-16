#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class LivroCaixaEndpoints
{
    public static IEndpointRouteBuilder MapLivroCaixaEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/LivroCaixa").WithTags("LivroCaixa").RequireAuthorization();
        MapLivroCaixaRoutes(group);
        return app;
    }

    private static void MapLivroCaixaRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ILivroCaixaValidation validation, ILivroCaixaWriter writer, IProcessosReader processosReader, ILivroCaixaService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("LivroCaixa: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("LivroCaixa_GetAll").WithDisplayName("Get All LivroCaixa");
        group.MapPost("/Filter", async (Filters.FilterLivroCaixa filtro, string uri, ILivroCaixaValidation validation, ILivroCaixaWriter writer, IProcessosReader processosReader, ILivroCaixaService service) =>
        {
            logger.Info("LivroCaixa: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("LivroCaixa_Filter").WithDisplayName("Filter LivroCaixa");
        group.MapGet("/GetById/{id}", async (int id, string uri, ILivroCaixaValidation validation, ILivroCaixaWriter writer, IProcessosReader processosReader, ILivroCaixaService service, CancellationToken token) =>
        {
            logger.Info("LivroCaixa: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No LivroCaixa found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("LivroCaixa_GetById").WithDisplayName("Get LivroCaixa By Id");
        group.MapPost("/AddAndUpdate", async (Models.LivroCaixa regLivroCaixa, string uri, ILivroCaixaValidation validation, ILivroCaixaWriter writer, IProcessosReader processosReader, ILivroCaixaService service) =>
        {
            logger.LogInfo("LivroCaixa", "AddAndUpdate", $"regLivroCaixa = {regLivroCaixa}", uri);
            var result = await service.AddAndUpdate(regLivroCaixa, uri);
            if (result == null)
            {
                logger.LogWarn("LivroCaixa", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("LivroCaixa_AddAndUpdate").WithDisplayName("Add or Update LivroCaixa");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, ILivroCaixaValidation validation, ILivroCaixaWriter writer, IProcessosReader processosReader, ILivroCaixaService service) =>
        {
            logger.LogInfo("LivroCaixa", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("LivroCaixa", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("LivroCaixa_GetColumns").WithDisplayName("Get LivroCaixa Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, ILivroCaixaValidation validation, ILivroCaixaWriter writer, IProcessosReader processosReader, ILivroCaixaService service) =>
        {
            logger.LogInfo("LivroCaixa", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("LivroCaixa", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("LivroCaixa_UpdateColumns").WithDisplayName("Update LivroCaixa Columns");
        group.MapDelete("/Delete", async (int id, string uri, ILivroCaixaValidation validation, ILivroCaixaWriter writer, IProcessosReader processosReader, ILivroCaixaService service) =>
        {
            logger.LogInfo("LivroCaixa", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("LivroCaixa", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("LivroCaixa_Delete").WithDisplayName("Delete LivroCaixa");
    }
}