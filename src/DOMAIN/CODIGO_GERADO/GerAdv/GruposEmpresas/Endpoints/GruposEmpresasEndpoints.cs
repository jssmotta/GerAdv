#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class GruposEmpresasEndpoints
{
    public static IEndpointRouteBuilder MapGruposEmpresasEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/GruposEmpresas").WithTags("GruposEmpresas").RequireAuthorization();
        MapGruposEmpresasRoutes(group);
        return app;
    }

    private static void MapGruposEmpresasRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IGruposEmpresasService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("GruposEmpresas_GetAll").WithDisplayName("Get All GruposEmpresas");
        group.MapPost("/Filter", async (Filters.FilterGruposEmpresas filtro, string uri, IGruposEmpresasService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("GruposEmpresas_Filter").WithDisplayName("Filter GruposEmpresas");
        group.MapGet("/GetById/{id}", async (int id, string uri, IGruposEmpresasService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No GruposEmpresas found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GruposEmpresas_GetById").WithDisplayName("Get GruposEmpresas By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterGruposEmpresas? filtro, string uri, IGruposEmpresasService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("GruposEmpresas_GetListN").WithDisplayName("Get GruposEmpresas List N");
        group.MapPost("/AddAndUpdate", async (Models.GruposEmpresas regGruposEmpresas, string uri, IGruposEmpresasValidation validation, IGruposEmpresasWriter writer, IOponentesReader oponentesReader, IClientesReader clientesReader, IGruposEmpresasService service) =>
        {
            var result = await service.AddAndUpdate(regGruposEmpresas, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("GruposEmpresas_AddAndUpdate").WithDisplayName("Add or Update GruposEmpresas");
        group.MapDelete("/Delete", async (int id, string uri, IGruposEmpresasValidation validation, IGruposEmpresasWriter writer, IOponentesReader oponentesReader, IClientesReader clientesReader, IGruposEmpresasService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GruposEmpresas_Delete").WithDisplayName("Delete GruposEmpresas");
    }
}