#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class EnderecoSistemaEndpoints
{
    public static IEndpointRouteBuilder MapEnderecoSistemaEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/EnderecoSistema").WithTags("EnderecoSistema").RequireAuthorization();
        MapEnderecoSistemaRoutes(group);
        return app;
    }

    private static void MapEnderecoSistemaRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IEnderecoSistemaValidation validation, IEnderecoSistemaWriter writer, ITipoEnderecoSistemaReader tipoenderecosistemaReader, IProcessosReader processosReader, IEnderecoSistemaService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("EnderecoSistema: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("EnderecoSistema_GetAll").WithDisplayName("Get All EnderecoSistema");
        group.MapPost("/Filter", async (Filters.FilterEnderecoSistema filtro, string uri, IEnderecoSistemaValidation validation, IEnderecoSistemaWriter writer, ITipoEnderecoSistemaReader tipoenderecosistemaReader, IProcessosReader processosReader, IEnderecoSistemaService service) =>
        {
            logger.Info("EnderecoSistema: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("EnderecoSistema_Filter").WithDisplayName("Filter EnderecoSistema");
        group.MapGet("/GetById/{id}", async (int id, string uri, IEnderecoSistemaValidation validation, IEnderecoSistemaWriter writer, ITipoEnderecoSistemaReader tipoenderecosistemaReader, IProcessosReader processosReader, IEnderecoSistemaService service, CancellationToken token) =>
        {
            logger.Info("EnderecoSistema: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No EnderecoSistema found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("EnderecoSistema_GetById").WithDisplayName("Get EnderecoSistema By Id");
        group.MapPost("/AddAndUpdate", async (Models.EnderecoSistema regEnderecoSistema, string uri, IEnderecoSistemaValidation validation, IEnderecoSistemaWriter writer, ITipoEnderecoSistemaReader tipoenderecosistemaReader, IProcessosReader processosReader, IEnderecoSistemaService service) =>
        {
            logger.LogInfo("EnderecoSistema", "AddAndUpdate", $"regEnderecoSistema = {regEnderecoSistema}", uri);
            var result = await service.AddAndUpdate(regEnderecoSistema, uri);
            if (result == null)
            {
                logger.LogWarn("EnderecoSistema", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("EnderecoSistema_AddAndUpdate").WithDisplayName("Add or Update EnderecoSistema");
        group.MapPost("/GetColumns", async (GetColumns parameters, string uri, IEnderecoSistemaValidation validation, IEnderecoSistemaWriter writer, ITipoEnderecoSistemaReader tipoenderecosistemaReader, IProcessosReader processosReader, IEnderecoSistemaService service) =>
        {
            logger.LogInfo("EnderecoSistema", "GetColumns", $"id = {parameters.Id}", $"columns = {parameters.Columns}", uri);
            var result = await service.GetColumns(parameters, uri);
            if (result == null)
            {
                logger.LogWarn("EnderecoSistema", "GetColumns", $"No columns found for id = {parameters.Id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("EnderecoSistema_GetColumns").WithDisplayName("Get EnderecoSistema Columns");
        group.MapPost("/UpdateColumns", async (UpdateColumnsRequest parameters, string uri, IEnderecoSistemaValidation validation, IEnderecoSistemaWriter writer, ITipoEnderecoSistemaReader tipoenderecosistemaReader, IProcessosReader processosReader, IEnderecoSistemaService service) =>
        {
            logger.LogInfo("EnderecoSistema", "UpdateColumns", $"id = {parameters.Id}", $"parameters = {parameters}", uri);
            var result = await service.UpdateColumns(parameters, uri);
            if (!result)
            {
                logger.LogWarn("EnderecoSistema", "UpdateColumns", $"Failed to update columns for id = {parameters.Id}", uri);
                return Results.BadRequest();
            }

            return Results.Ok();
        }).WithName("EnderecoSistema_UpdateColumns").WithDisplayName("Update EnderecoSistema Columns");
        group.MapDelete("/Delete", async (int id, string uri, IEnderecoSistemaValidation validation, IEnderecoSistemaWriter writer, ITipoEnderecoSistemaReader tipoenderecosistemaReader, IProcessosReader processosReader, IEnderecoSistemaService service) =>
        {
            logger.LogInfo("EnderecoSistema", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("EnderecoSistema", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("EnderecoSistema_Delete").WithDisplayName("Delete EnderecoSistema");
    }
}