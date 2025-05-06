#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class InstanciaEndpoints
{
    public static IEndpointRouteBuilder MapInstanciaEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Instancia").WithTags("Instancia").RequireAuthorization();
        MapInstanciaRoutes(group);
        return app;
    }

    private static void MapInstanciaRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IInstanciaValidation validation, IInstanciaWriter writer, IProcessosReader processosReader, IAcaoReader acaoReader, IForoReader foroReader, ITipoRecursoReader tiporecursoReader, IInstanciaService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("Instancia: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Instancia_GetAll").WithDisplayName("Get All Instancia");
        group.MapPost("/Filter", async (Filters.FilterInstancia filtro, string uri, IInstanciaValidation validation, IInstanciaWriter writer, IProcessosReader processosReader, IAcaoReader acaoReader, IForoReader foroReader, ITipoRecursoReader tiporecursoReader, IInstanciaService service) =>
        {
            logger.Info("Instancia: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Instancia_Filter").WithDisplayName("Filter Instancia");
        group.MapGet("/GetById/{id}", async (int id, string uri, IInstanciaValidation validation, IInstanciaWriter writer, IProcessosReader processosReader, IAcaoReader acaoReader, IForoReader foroReader, ITipoRecursoReader tiporecursoReader, IInstanciaService service, CancellationToken token) =>
        {
            logger.Info("Instancia: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Instancia found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Instancia_GetById").WithDisplayName("Get Instancia By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IInstanciaValidation validation, IInstanciaWriter writer, IProcessosReader processosReader, IAcaoReader acaoReader, IForoReader foroReader, ITipoRecursoReader tiporecursoReader, IInstanciaService service) =>
        {
            logger.Info("Instancia: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No Instancia found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Instancia_GetByName").WithDisplayName("Get Instancia By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterInstancia? filtro, string uri, IInstanciaValidation validation, IInstanciaWriter writer, IProcessosReader processosReader, IAcaoReader acaoReader, IForoReader foroReader, ITipoRecursoReader tiporecursoReader, IInstanciaService service) =>
        {
            logger.Info("Instancia: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Instancia_GetListN").WithDisplayName("Get Instancia List N");
        group.MapPost("/AddAndUpdate", async (Models.Instancia regInstancia, string uri, IInstanciaValidation validation, IInstanciaWriter writer, IProcessosReader processosReader, IAcaoReader acaoReader, IForoReader foroReader, ITipoRecursoReader tiporecursoReader, IInstanciaService service) =>
        {
            logger.LogInfo("Instancia", "AddAndUpdate", $"regInstancia = {regInstancia}", uri);
            var result = await service.AddAndUpdate(regInstancia, uri);
            if (result == null)
            {
                logger.LogWarn("Instancia", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Instancia_AddAndUpdate").WithDisplayName("Add or Update Instancia");
        group.MapDelete("/Delete", async (int id, string uri, IInstanciaValidation validation, IInstanciaWriter writer, IProcessosReader processosReader, IAcaoReader acaoReader, IForoReader foroReader, ITipoRecursoReader tiporecursoReader, IInstanciaService service) =>
        {
            logger.LogInfo("Instancia", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("Instancia", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Instancia_Delete").WithDisplayName("Delete Instancia");
    }
}