#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class GruposEmpresasCliEndpoints
{
    public static IEndpointRouteBuilder MapGruposEmpresasCliEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/GruposEmpresasCli").WithTags("GruposEmpresasCli").RequireAuthorization();
        MapGruposEmpresasCliRoutes(group);
        return app;
    }

    private static void MapGruposEmpresasCliRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IGruposEmpresasCliService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("GruposEmpresasCli_GetAll").WithDisplayName("Get All GruposEmpresasCli");
        group.MapPost("/Filter", async (Filters.FilterGruposEmpresasCli filtro, string uri, IGruposEmpresasCliService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("GruposEmpresasCli_Filter").WithDisplayName("Filter GruposEmpresasCli");
        group.MapGet("/GetById/{id}", async (int id, string uri, IGruposEmpresasCliService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No GruposEmpresasCli found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GruposEmpresasCli_GetById").WithDisplayName("Get GruposEmpresasCli By Id");
        group.MapPost("/AddAndUpdate", async (Models.GruposEmpresasCli regGruposEmpresasCli, string uri, IGruposEmpresasCliValidation validation, IGruposEmpresasCliWriter writer, IGruposEmpresasReader gruposempresasReader, IClientesReader clientesReader, IGruposEmpresasCliService service) =>
        {
            var result = await service.AddAndUpdate(regGruposEmpresasCli, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("GruposEmpresasCli_AddAndUpdate").WithDisplayName("Add or Update GruposEmpresasCli");
        group.MapDelete("/Delete", async (int id, string uri, IGruposEmpresasCliValidation validation, IGruposEmpresasCliWriter writer, IGruposEmpresasReader gruposempresasReader, IClientesReader clientesReader, IGruposEmpresasCliService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("GruposEmpresasCli_Delete").WithDisplayName("Delete GruposEmpresasCli");
    }
}