#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class AdvogadosEndpoints
{
    public static IEndpointRouteBuilder MapAdvogadosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/Advogados").WithTags("Advogados").RequireAuthorization();
        MapAdvogadosRoutes(group);
        return app;
    }

    private static void MapAdvogadosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IAdvogadosService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("Advogados_GetAll").WithDisplayName("Get All Advogados");
        group.MapPost("/Filter", async (Filters.FilterAdvogados filtro, string uri, IAdvogadosService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("Advogados_Filter").WithDisplayName("Filter Advogados");
        group.MapGet("/GetById/{id}", async (int id, string uri, IAdvogadosService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No Advogados found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Advogados_GetById").WithDisplayName("Get Advogados By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterAdvogados? filtro, string uri, IAdvogadosService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("Advogados_GetListN").WithDisplayName("Get Advogados List N");
        group.MapPost("/AddAndUpdate", async (Models.Advogados regAdvogados, string uri, IAdvogadosValidation validation, IAdvogadosWriter writer, ICargosReader cargosReader, IEscritoriosReader escritoriosReader, ICidadeReader cidadeReader, IAdvogadosService service) =>
        {
            var result = await service.AddAndUpdate(regAdvogados, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("Advogados_AddAndUpdate").WithDisplayName("Add or Update Advogados");
        group.MapDelete("/Delete", async (int id, string uri, IAdvogadosValidation validation, IAdvogadosWriter writer, ICargosReader cargosReader, IEscritoriosReader escritoriosReader, ICidadeReader cidadeReader, IAdvogadosService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("Advogados_Delete").WithDisplayName("Delete Advogados");
    }
}