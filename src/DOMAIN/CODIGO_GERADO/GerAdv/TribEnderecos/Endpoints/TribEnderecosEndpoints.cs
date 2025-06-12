#pragma warning disable IDE0130 // Namespace does not match folder structure

namespace MenphisSI.GerAdv;
#pragma warning restore IDE0130 // Namespace does not match folder structure

public static class TribEnderecosEndpoints
{
    public static IEndpointRouteBuilder MapTribEnderecosEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/v2/{uri}/TribEnderecos").WithTags("TribEnderecos").RequireAuthorization();
        MapTribEnderecosRoutes(group);
        return app;
    }

    private static void MapTribEnderecosRoutes(RouteGroupBuilder group)
    {
        var logger = LogManager.GetCurrentClassLogger();
        group.MapGet("/GetAll", async (int max, string uri, ITribEnderecosService service) =>
        {
            var result = await service.GetAll(max, uri);
            return Results.Ok(result);
        }).WithName("TribEnderecos_GetAll").WithDisplayName("Get All TribEnderecos");
        group.MapPost("/Filter", async (Filters.FilterTribEnderecos filtro, string uri, ITribEnderecosService service) =>
        {
            var result = await service.Filter(filtro, uri);
            return Results.Ok(result);
        }).WithName("TribEnderecos_Filter").WithDisplayName("Filter TribEnderecos");
        group.MapGet("/GetById/{id}", async (int id, string uri, ITribEnderecosService service, CancellationToken token) =>
        {
            var result = await service.GetById(id, uri, token);
            if (result == null)
            {
                logger.Warn("GetById: No TribEnderecos found with id = {0}, {1}", id, uri);
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TribEnderecos_GetById").WithDisplayName("Get TribEnderecos By Id");
        group.MapPost("/AddAndUpdate", async (Models.TribEnderecos regTribEnderecos, string uri, ITribEnderecosValidation validation, ITribEnderecosWriter writer, ITribunalReader tribunalReader, ICidadeReader cidadeReader, ITribEnderecosService service) =>
        {
            var result = await service.AddAndUpdate(regTribEnderecos, uri);
            if (result == null)
            {
                return Results.BadRequest();
            }

            return Results.Ok(result);
        }).WithName("TribEnderecos_AddAndUpdate").WithDisplayName("Add or Update TribEnderecos");
        group.MapDelete("/Delete", async (int id, string uri, ITribEnderecosValidation validation, ITribEnderecosWriter writer, ITribunalReader tribunalReader, ICidadeReader cidadeReader, ITribEnderecosService service) =>
        {
            var result = await service.Delete(id, uri);
            if (result == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(result);
        }).WithName("TribEnderecos_Delete").WithDisplayName("Delete TribEnderecos");
    }
}