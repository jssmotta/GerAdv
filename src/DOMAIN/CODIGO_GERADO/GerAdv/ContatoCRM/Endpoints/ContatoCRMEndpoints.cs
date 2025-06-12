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
        group.MapGet("/GetAll", async (int max, string uri, IContatoCRMService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("ContatoCRM_GetAll").WithDisplayName("Get All ContatoCRM");
        group.MapPost("/Filter", async (Filters.FilterContatoCRM filtro, string uri, IContatoCRMService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("ContatoCRM_Filter").WithDisplayName("Filter ContatoCRM");
        group.MapGet("/GetById/{id}", async (int id, string uri, IContatoCRMService service, CancellationToken token) =>
        {
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
            var result = await service.AddAndUpdate(regContatoCRM, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("ContatoCRM_AddAndUpdate").WithDisplayName("Add or Update ContatoCRM");
        group.MapDelete("/Delete", async (int id, string uri, IContatoCRMValidation validation, IContatoCRMWriter writer, IOperadorReader operadorReader, IClientesReader clientesReader, IProcessosReader processosReader, ITipoContatoCRMReader tipocontatocrmReader, IContatoCRMService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("ContatoCRM_Delete").WithDisplayName("Delete ContatoCRM");
    }
}