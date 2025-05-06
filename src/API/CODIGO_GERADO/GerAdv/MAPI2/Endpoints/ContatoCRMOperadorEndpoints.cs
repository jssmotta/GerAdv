#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ContatoCRMOperadorEndpoints
{
    public static IEndpointRouteBuilder MapContatoCRMOperadorEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ContatoCRMOperador").WithTags("ContatoCRMOperador").RequireAuthorization();
        MapContatoCRMOperadorRoutes(group);
        return app;
    }

    private static void MapContatoCRMOperadorRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IContatoCRMOperadorValidation validation, IContatoCRMOperadorWriter writer, IContatoCRMReader contatocrmReader, IOperadorReader operadorReader, IContatoCRMOperadorService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("ContatoCRMOperador: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ContatoCRMOperador_GetAll").WithDisplayName("Get All ContatoCRMOperador");
        group.MapPost("/Filter", async (Filters.FilterContatoCRMOperador filtro, string uri, IContatoCRMOperadorValidation validation, IContatoCRMOperadorWriter writer, IContatoCRMReader contatocrmReader, IOperadorReader operadorReader, IContatoCRMOperadorService service) =>
        {
            logger.Info("ContatoCRMOperador: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ContatoCRMOperador_Filter").WithDisplayName("Filter ContatoCRMOperador");
        group.MapGet("/GetById/{id}", async (int id, string uri, IContatoCRMOperadorValidation validation, IContatoCRMOperadorWriter writer, IContatoCRMReader contatocrmReader, IOperadorReader operadorReader, IContatoCRMOperadorService service, CancellationToken token) =>
        {
            logger.Info("ContatoCRMOperador: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ContatoCRMOperador found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ContatoCRMOperador_GetById").WithDisplayName("Get ContatoCRMOperador By Id");
        group.MapPost("/AddAndUpdate", async (Models.ContatoCRMOperador regContatoCRMOperador, string uri, IContatoCRMOperadorValidation validation, IContatoCRMOperadorWriter writer, IContatoCRMReader contatocrmReader, IOperadorReader operadorReader, IContatoCRMOperadorService service) =>
        {
            logger.LogInfo("ContatoCRMOperador", "AddAndUpdate", $"regContatoCRMOperador = {regContatoCRMOperador}", uri);
            var result = await service.AddAndUpdate(regContatoCRMOperador, uri);
            if (result == null)
            {
                logger.LogWarn("ContatoCRMOperador", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ContatoCRMOperador_AddAndUpdate").WithDisplayName("Add or Update ContatoCRMOperador");
        group.MapDelete("/Delete", async (int id, string uri, IContatoCRMOperadorValidation validation, IContatoCRMOperadorWriter writer, IContatoCRMReader contatocrmReader, IOperadorReader operadorReader, IContatoCRMOperadorService service) =>
        {
            logger.LogInfo("ContatoCRMOperador", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("ContatoCRMOperador", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ContatoCRMOperador_Delete").WithDisplayName("Delete ContatoCRMOperador");
    }
}