#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class ProSucumbenciaEndpoints
{
    public static IEndpointRouteBuilder MapProSucumbenciaEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/ProSucumbencia").WithTags("ProSucumbencia").RequireAuthorization();
        MapProSucumbenciaRoutes(group);
        return app;
    }

    private static void MapProSucumbenciaRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IProSucumbenciaValidation validation, IProSucumbenciaWriter writer, IProcessosReader processosReader, IInstanciaReader instanciaReader, ITipoOrigemSucumbenciaReader tipoorigemsucumbenciaReader, IProSucumbenciaService service) =>
        {
            if (max <= 0)
            {
                max = BaseConsts.PMaxItens;
            }

            logger.Info("ProSucumbencia: GetAll called with max = {0}, {1}", max, uri);
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProSucumbencia_GetAll").WithDisplayName("Get All ProSucumbencia");
        group.MapPost("/Filter", async (Filters.FilterProSucumbencia filtro, string uri, IProSucumbenciaValidation validation, IProSucumbenciaWriter writer, IProcessosReader processosReader, IInstanciaReader instanciaReader, ITipoOrigemSucumbenciaReader tipoorigemsucumbenciaReader, IProSucumbenciaService service) =>
        {
            logger.Info("ProSucumbencia: Filter called with filtro = {0}, {1}", filtro, uri);
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProSucumbencia_Filter").WithDisplayName("Filter ProSucumbencia");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProSucumbenciaValidation validation, IProSucumbenciaWriter writer, IProcessosReader processosReader, IInstanciaReader instanciaReader, ITipoOrigemSucumbenciaReader tipoorigemsucumbenciaReader, IProSucumbenciaService service, CancellationToken token) =>
        {
            logger.Info("ProSucumbencia: GetById called with id = {0}, {1}", id, uri);
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ProSucumbencia found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProSucumbencia_GetById").WithDisplayName("Get ProSucumbencia By Id");
        group.MapGet("/GetByName/{name}", async (string name, string uri, IProSucumbenciaValidation validation, IProSucumbenciaWriter writer, IProcessosReader processosReader, IInstanciaReader instanciaReader, ITipoOrigemSucumbenciaReader tipoorigemsucumbenciaReader, IProSucumbenciaService service) =>
        {
            logger.Info("ProSucumbencia: GetByName called with name = {0}, {1}", name, uri);
            var result = await service.GetByName(name, uri);
            if (result == null)
            {
                logger.Warn("GetByName: No ProSucumbencia found with name = {0}, {1}", name, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProSucumbencia_GetByName").WithDisplayName("Get ProSucumbencia By Name");
        group.MapPost("/GetListN", async (int max, Filters.FilterProSucumbencia? filtro, string uri, IProSucumbenciaValidation validation, IProSucumbenciaWriter writer, IProcessosReader processosReader, IInstanciaReader instanciaReader, ITipoOrigemSucumbenciaReader tipoorigemsucumbenciaReader, IProSucumbenciaService service) =>
        {
            logger.Info("ProSucumbencia: GetListN called, max {0}, filtro {1}, {2}", max, filtro, uri);
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("ProSucumbencia_GetListN").WithDisplayName("Get ProSucumbencia List N");
        group.MapPost("/AddAndUpdate", async (Models.ProSucumbencia regProSucumbencia, string uri, IProSucumbenciaValidation validation, IProSucumbenciaWriter writer, IProcessosReader processosReader, IInstanciaReader instanciaReader, ITipoOrigemSucumbenciaReader tipoorigemsucumbenciaReader, IProSucumbenciaService service) =>
        {
            logger.LogInfo("ProSucumbencia", "AddAndUpdate", $"regProSucumbencia = {regProSucumbencia}", uri);
            var result = await service.AddAndUpdate(regProSucumbencia, uri);
            if (result == null)
            {
                logger.LogWarn("ProSucumbencia", "AddAndUpdate", "Failed to add or update record", uri);
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProSucumbencia_AddAndUpdate").WithDisplayName("Add or Update ProSucumbencia");
        group.MapDelete("/Delete", async (int id, string uri, IProSucumbenciaValidation validation, IProSucumbenciaWriter writer, IProcessosReader processosReader, IInstanciaReader instanciaReader, ITipoOrigemSucumbenciaReader tipoorigemsucumbenciaReader, IProSucumbenciaService service) =>
        {
            logger.LogInfo("ProSucumbencia", "Delete", $"id = {id}", uri);
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                logger.LogWarn("ProSucumbencia", "Delete", $"No record found with id = {id}", uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProSucumbencia_Delete").WithDisplayName("Delete ProSucumbencia");
    }
}