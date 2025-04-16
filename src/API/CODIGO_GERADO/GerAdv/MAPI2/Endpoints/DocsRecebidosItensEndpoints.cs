#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class DocsRecebidosItensEndpoints
{
    public static IEndpointRouteBuilder MapDocsRecebidosItensEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/DocsRecebidosItens").WithTags("DocsRecebidosItens").RequireAuthorization();
        MapDocsRecebidosItensRoutes(group);
        return app;
    }

    private static void MapDocsRecebidosItensRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IDocsRecebidosItensValidation validation, IDocsRecebidosItensWriter writer, IContatoCRMReader contatocrmReader, IDocsRecebidosItensService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("DocsRecebidosItens: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("DocsRecebidosItens_GetAll").WithDisplayName("Get All DocsRecebidosItens");
        group.MapPost("/Filter", async (Filters.FilterDocsRecebidosItens filtro, string uri, IDocsRecebidosItensValidation validation, IDocsRecebidosItensWriter writer, IContatoCRMReader contatocrmReader, IDocsRecebidosItensService service) =>
        {
            logger.Info("DocsRecebidosItens: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("DocsRecebidosItens_Filter").WithDisplayName("Filter DocsRecebidosItens");
        group.MapGet("/GetById/{id}", async (int id, string uri, IDocsRecebidosItensValidation validation, IDocsRecebidosItensWriter writer, IContatoCRMReader contatocrmReader, IDocsRecebidosItensService service, CancellationToken token) =>
        {
            logger.Info("DocsRecebidosItens: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No DocsRecebidosItens found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("DocsRecebidosItens_GetById").WithDisplayName("Get DocsRecebidosItens By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IDocsRecebidosItensValidation validation, IDocsRecebidosItensWriter writer, IContatoCRMReader contatocrmReader, IDocsRecebidosItensService service) =>
        {
            logger.Info("DocsRecebidosItens: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No DocsRecebidosItens found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("DocsRecebidosItens_GetByName").WithDisplayName("Get DocsRecebidosItens By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterDocsRecebidosItens? filtro, string uri, IDocsRecebidosItensValidation validation, IDocsRecebidosItensWriter writer, IContatoCRMReader contatocrmReader, IDocsRecebidosItensService service) =>
        {
            logger.Info("DocsRecebidosItens: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("DocsRecebidosItens_GetListN").WithDisplayName("Get DocsRecebidosItens List N");
        group.MapPost("/AddAndUpdate", async (Models.DocsRecebidosItens regDocsRecebidosItens, string uri, IDocsRecebidosItensValidation validation, IDocsRecebidosItensWriter writer, IContatoCRMReader contatocrmReader, IDocsRecebidosItensService service) =>
        {
            logger.LogInfo("DocsRecebidosItens", "AddAndUpdate", $"regDocsRecebidosItens = {regDocsRecebidosItens}", uri);
            var result = await service.AddAndUpdate(regDocsRecebidosItens, uri);
            if (result == null)
            {
                logger.LogWarn("DocsRecebidosItens", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("DocsRecebidosItens_AddAndUpdate").WithDisplayName("Add or Update DocsRecebidosItens");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IDocsRecebidosItensValidation validation, IDocsRecebidosItensWriter writer, IContatoCRMReader contatocrmReader, IDocsRecebidosItensService service) =>
        {
            logger.LogInfo("DocsRecebidosItens", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("DocsRecebidosItens", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("DocsRecebidosItens_GetColumns").WithDisplayName("Get DocsRecebidosItens Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IDocsRecebidosItensValidation validation, IDocsRecebidosItensWriter writer, IContatoCRMReader contatocrmReader, IDocsRecebidosItensService service) =>
        {
            logger.LogInfo("DocsRecebidosItens", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("DocsRecebidosItens", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("DocsRecebidosItens_UpdateColumns").WithDisplayName("Update DocsRecebidosItens Columns");
        group.MapDelete("/Delete", async (int id, string uri, IDocsRecebidosItensValidation validation, IDocsRecebidosItensWriter writer, IContatoCRMReader contatocrmReader, IDocsRecebidosItensService service) =>
        {
            logger.LogInfo("DocsRecebidosItens", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("DocsRecebidosItens", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("DocsRecebidosItens_Delete").WithDisplayName("Delete DocsRecebidosItens");
    }
}