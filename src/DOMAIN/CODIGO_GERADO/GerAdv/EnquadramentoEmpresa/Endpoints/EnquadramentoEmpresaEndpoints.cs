#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class EnquadramentoEmpresaEndpoints
{
    public static IEndpointRouteBuilder MapEnquadramentoEmpresaEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/EnquadramentoEmpresa").WithTags("EnquadramentoEmpresa").RequireAuthorization();
        MapEnquadramentoEmpresaRoutes(group);
        return app;
    }

    private static void MapEnquadramentoEmpresaRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, IEnquadramentoEmpresaService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("EnquadramentoEmpresa_GetAll").WithDisplayName("Get All EnquadramentoEmpresa");
        group.MapPost("/Filter", async (Filters.FilterEnquadramentoEmpresa filtro, string uri, IEnquadramentoEmpresaService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("EnquadramentoEmpresa_Filter").WithDisplayName("Filter EnquadramentoEmpresa");
        group.MapGet("/GetById/{id}", async (int id, string uri, IEnquadramentoEmpresaService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No EnquadramentoEmpresa found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("EnquadramentoEmpresa_GetById").WithDisplayName("Get EnquadramentoEmpresa By Id");
        group.MapPost("/GetListN", async (int max, Filters.FilterEnquadramentoEmpresa? filtro, string uri, IEnquadramentoEmpresaService service) =>
        {
            var result = await service.GetListN(max, filtro, uri);
            return Results.Ok(result);
        }).WithName("EnquadramentoEmpresa_GetListN").WithDisplayName("Get EnquadramentoEmpresa List N");
        group.MapPost("/AddAndUpdate", async (Models.EnquadramentoEmpresa regEnquadramentoEmpresa, string uri, IEnquadramentoEmpresaValidation validation, IEnquadramentoEmpresaWriter writer, IEnquadramentoEmpresaService service) =>
        {
            var result = await service.AddAndUpdate(regEnquadramentoEmpresa, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("EnquadramentoEmpresa_AddAndUpdate").WithDisplayName("Add or Update EnquadramentoEmpresa");
        group.MapDelete("/Delete", async (int id, string uri, IEnquadramentoEmpresaValidation validation, IEnquadramentoEmpresaWriter writer, IEnquadramentoEmpresaService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("EnquadramentoEmpresa_Delete").WithDisplayName("Delete EnquadramentoEmpresa");
    }
}