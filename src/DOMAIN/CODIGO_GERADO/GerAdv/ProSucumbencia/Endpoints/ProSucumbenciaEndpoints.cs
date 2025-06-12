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
        group.MapGet("/GetAll", async (int max, string uri, IProSucumbenciaService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ProSucumbencia_GetAll").WithDisplayName("Get All ProSucumbencia");
        group.MapPost("/Filter", async (Filters.FilterProSucumbencia filtro, string uri, IProSucumbenciaService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ProSucumbencia_Filter").WithDisplayName("Filter ProSucumbencia");
        group.MapGet("/GetById/{id}", async (int id, string uri, IProSucumbenciaService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No ProSucumbencia found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProSucumbencia_GetById").WithDisplayName("Get ProSucumbencia By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterProSucumbencia? filtro, string uri, IProSucumbenciaService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("ProSucumbencia_GetListN").WithDisplayName("Get ProSucumbencia List N");
        group.MapPost("/AddAndUpdate", async (Models.ProSucumbencia regProSucumbencia, string uri, IProSucumbenciaValidation validation, IProSucumbenciaWriter writer, IProcessosReader processosReader, IInstanciaReader instanciaReader, ITipoOrigemSucumbenciaReader tipoorigemsucumbenciaReader, IProSucumbenciaService service) =>
        {
            var result = await service.AddAndUpdate(regProSucumbencia, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ProSucumbencia_AddAndUpdate").WithDisplayName("Add or Update ProSucumbencia");
        group.MapDelete("/Delete", async (int id, string uri, IProSucumbenciaValidation validation, IProSucumbenciaWriter writer, IProcessosReader processosReader, IInstanciaReader instanciaReader, ITipoOrigemSucumbenciaReader tipoorigemsucumbenciaReader, IProSucumbenciaService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ProSucumbencia_Delete").WithDisplayName("Delete ProSucumbencia");
    }
}