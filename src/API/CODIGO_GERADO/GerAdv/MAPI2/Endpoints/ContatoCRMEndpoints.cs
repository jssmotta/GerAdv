#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ContatoCRMEndpoints
{
    public static IEndpointRouteBuilder MapContatoCRMEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ContatoCRM").WithTags("ContatoCRM").RequireAuthorization();
        MapContatoCRMRoutes(group);
        return app;
    }

    private static void MapContatoCRMRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IContatoCRMValidation validation, IContatoCRMWriter writer, IOperadorReader operadorReader, IClientesReader clientesReader, IProcessosReader processosReader, ITipoContatoCRMReader tipocontatocrmReader, IContatoCRMService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("ContatoCRM: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ContatoCRM_GetAll").WithDisplayName("Get All ContatoCRM");
        group.MapPost("/Filter", async (Filters.FilterContatoCRM filtro, string uri, IContatoCRMValidation validation, IContatoCRMWriter writer, IOperadorReader operadorReader, IClientesReader clientesReader, IProcessosReader processosReader, ITipoContatoCRMReader tipocontatocrmReader, IContatoCRMService service) =>
        {
            logger.Info("ContatoCRM: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ContatoCRM_Filter").WithDisplayName("Filter ContatoCRM");
        group.MapGet("/GetById/{id}", async (int id, string uri, IContatoCRMValidation validation, IContatoCRMWriter writer, IOperadorReader operadorReader, IClientesReader clientesReader, IProcessosReader processosReader, ITipoContatoCRMReader tipocontatocrmReader, IContatoCRMService service, CancellationToken token) =>
        {
            logger.Info("ContatoCRM: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ContatoCRM found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ContatoCRM_GetById").WithDisplayName("Get ContatoCRM By Id");
        group.MapPost("/AddAndUpdate", async (Models.ContatoCRM regContatoCRM, string uri, IContatoCRMValidation validation, IContatoCRMWriter writer, IOperadorReader operadorReader, IClientesReader clientesReader, IProcessosReader processosReader, ITipoContatoCRMReader tipocontatocrmReader, IContatoCRMService service) =>
        {
            logger.LogInfo("ContatoCRM", "AddAndUpdate", $"regContatoCRM = {regContatoCRM}", uri);
            var result = await service.AddAndUpdate(regContatoCRM, uri);
            if (result == null)
            {
                logger.LogWarn("ContatoCRM", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ContatoCRM_AddAndUpdate").WithDisplayName("Add or Update ContatoCRM");
        group.MapDelete("/Delete", async (int id, string uri, IContatoCRMValidation validation, IContatoCRMWriter writer, IOperadorReader operadorReader, IClientesReader clientesReader, IProcessosReader processosReader, ITipoContatoCRMReader tipocontatocrmReader, IContatoCRMService service) =>
        {
            logger.LogInfo("ContatoCRM", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("ContatoCRM", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ContatoCRM_Delete").WithDisplayName("Delete ContatoCRM");
    }
}