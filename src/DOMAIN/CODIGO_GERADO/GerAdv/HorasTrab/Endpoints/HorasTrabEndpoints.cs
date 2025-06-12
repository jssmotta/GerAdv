#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class HorasTrabEndpoints
{
    public static IEndpointRouteBuilder MapHorasTrabEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/HorasTrab").WithTags("HorasTrab").RequireAuthorization();
        MapHorasTrabRoutes(group);
        return app;
    }

    private static void MapHorasTrabRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IHorasTrabService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("HorasTrab_GetAll").WithDisplayName("Get All HorasTrab");
        group.MapPost("/Filter", async (Filters.FilterHorasTrab filtro, string uri, IHorasTrabService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("HorasTrab_Filter").WithDisplayName("Filter HorasTrab");
        group.MapGet("/GetById/{id}", async (int id, string uri, IHorasTrabService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No HorasTrab found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("HorasTrab_GetById").WithDisplayName("Get HorasTrab By Id");
        group.MapPost("/AddAndUpdate", async (Models.HorasTrab regHorasTrab, string uri, IHorasTrabValidation validation, IHorasTrabWriter writer, IClientesReader clientesReader, IProcessosReader processosReader, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, IServicosReader servicosReader, IHorasTrabService service) =>
        {
            var result = await service.AddAndUpdate(regHorasTrab, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("HorasTrab_AddAndUpdate").WithDisplayName("Add or Update HorasTrab");
        group.MapDelete("/Delete", async (int id, string uri, IHorasTrabValidation validation, IHorasTrabWriter writer, IClientesReader clientesReader, IProcessosReader processosReader, IAdvogadosReader advogadosReader, IFuncionariosReader funcionariosReader, IServicosReader servicosReader, IHorasTrabService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("HorasTrab_Delete").WithDisplayName("Delete HorasTrab");
    }
}